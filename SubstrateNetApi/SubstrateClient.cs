﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Threading;
using Newtonsoft.Json.Linq;
using NLog;
using StreamJsonRpc;
using SubstrateNetApi.Exceptions;
using SubstrateNetApi.Model.Calls;
using SubstrateNetApi.Model.Extrinsics;
using SubstrateNetApi.Model.Meta;
using SubstrateNetApi.Model.Rpc;
using SubstrateNetApi.Model.Types;
using SubstrateNetApi.Model.Types.Base;
using SubstrateNetApi.Model.Types.Primitive;
using SubstrateNetApi.Model.Types.Struct;
using SubstrateNetApi.Modules;
using SubstrateNetApi.TypeConverters;

[assembly: InternalsVisibleTo("SubstrateNetApiTests")]

namespace SubstrateNetApi
{
    /// <summary> A substrate client. </summary>
    /// <remarks> 19.09.2020. </remarks>
    /// <seealso cref="IDisposable" />
    public class SubstrateClient : IDisposable
    {
        /// <summary> The logger. </summary>
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        private readonly ExtrinsicJsonConverter _extrinsicJsonConverter = new ExtrinsicJsonConverter();

        private readonly ExtrinsicStatusJsonConverter
            _extrinsicStatusJsonConverter = new ExtrinsicStatusJsonConverter();

        /// <summary> The request token sources. </summary>
        private readonly ConcurrentDictionary<CancellationTokenSource, string> _requestTokenSourceDict;

        /// <summary> The type converters. </summary>
        private readonly Dictionary<string, ITypeConverter> _typeConverters = new Dictionary<string, ITypeConverter>();

        /// <summary> _URI of the resource. </summary>
        private readonly Uri _uri;

        /// <summary> The connect token source. </summary>
        private CancellationTokenSource _connectTokenSource;

        /// <summary> The JSON RPC. </summary>
        private JsonRpc _jsonRpc;

        /// <summary> The socket. </summary>
        private ClientWebSocket _socket;

        /// <summary> Constructor. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <param name="uri"> URI of the resource. </param>
        public SubstrateClient(Uri uri)
        {
            _uri = uri;

            System = new Modules.System(this);
            Chain = new Chain(this);
            State = new State(this);
            Author = new Author(this);

            // types used by the client need to be registred
            RegisterTypeConverter(new GenericTypeConverter<Bool>());
            RegisterTypeConverter(new GenericTypeConverter<U8>());
            RegisterTypeConverter(new GenericTypeConverter<U16>());
            RegisterTypeConverter(new GenericTypeConverter<U32>());
            RegisterTypeConverter(new GenericTypeConverter<U64>());
            RegisterTypeConverter(new GenericTypeConverter<BlockNumber>());
            RegisterTypeConverter(new GenericTypeConverter<AccountId>());
            RegisterTypeConverter(new GenericTypeConverter<AccountInfo>());
            RegisterTypeConverter(new GenericTypeConverter<AccountData>());
            RegisterTypeConverter(new GenericTypeConverter<Hash>());
            RegisterTypeConverter(new GenericTypeConverter<BaseVec<U8>>());
            RegisterTypeConverter(new GenericTypeConverter<BaseVec<U32>>());
            RegisterTypeConverter(new GenericTypeConverter<BaseVec<Hash>>());
            RegisterTypeConverter(new GenericTypeConverter<BaseVec<AccountId>>());

            //RegisterTypeConverter(new AccountInfoTypeConverter());

            _requestTokenSourceDict = new ConcurrentDictionary<CancellationTokenSource, string>();
        }

        /// <summary> Gets or sets information describing the meta. </summary>
        /// <value> Information describing the meta. </value>
        public MetaData MetaData { get; private set; }

        /// <summary> Gets or sets information describing the runtime version. </summary>
        /// <value> Information describing the runtime version. </value>
        public RuntimeVersion RuntimeVersion { get; private set; }

        /// <summary> Gets or sets the genesis hash. </summary>
        /// <value> The genesis hash. </value>
        public Hash GenesisHash { get; private set; }

        /// <summary> Gets the system. </summary>
        /// <value> The system. </value>
        public Modules.System System { get; }

        /// <summary> Gets the chain. </summary>
        /// <value> The chain. </value>
        public Chain Chain { get; }

        /// <summary> Gets the state. </summary>
        /// <value> The state. </value>
        public State State { get; }

        /// <summary> Gets the author. </summary>
        /// <value> The author. </value>
        public Author Author { get; }

        public SubscriptionListener Listener { get; } = new SubscriptionListener();

        /// <summary> Gets a value indicating whether this object is connected. </summary>
        /// <value> True if this object is connected, false if not. </value>
        public bool IsConnected => _socket?.State == WebSocketState.Open;

        /// <summary> Registers the type converter described by converter. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <exception cref="ConverterAlreadyRegisteredException">
        ///     Thrown when a Converter Already
        ///     Registered error condition occurs.
        /// </exception>
        /// <param name="converter"> The converter. </param>
        public void RegisterTypeConverter(ITypeConverter converter)
        {
            if (_typeConverters.ContainsKey(converter.TypeName))
                throw new ConverterAlreadyRegisteredException("Converter for specified type already registered.");

            _typeConverters.Add(converter.TypeName, converter);
        }

        public async Task ConnectLightAsync(CancellationToken token)
        {
            if (_socket != null && _socket.State == WebSocketState.Open)
                return;

            if (_socket == null || _socket.State != WebSocketState.None)
            {
                _jsonRpc?.Dispose();
                _socket?.Dispose();
                _socket = new ClientWebSocket();
            }

            _connectTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(token, _connectTokenSource.Token);
            await _socket.ConnectAsync(_uri, linkedTokenSource.Token);
            linkedTokenSource.Dispose();
            _connectTokenSource.Dispose();
            _connectTokenSource = null;
            Logger.Debug("Connected to Websocket.");

            var formatter = new JsonMessageFormatter();

            _jsonRpc = new JsonRpc(new WebSocketMessageHandler(_socket, formatter));
            _jsonRpc.TraceSource.Listeners.Add(new NLogTraceListener());
            _jsonRpc.TraceSource.Switch.Level = SourceLevels.Warning;
            _jsonRpc.AddLocalRpcTarget(Listener, new JsonRpcTargetOptions { AllowNonPublicInvocation = false });
            _jsonRpc.StartListening();
            Logger.Debug("Listening to websocket.");
        }

        /// <summary> Connects an asynchronous. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <returns> An asynchronous result. </returns>
        public async Task ConnectAsync()
        {
            await ConnectAsync(CancellationToken.None);
        }

        /// <summary> Connects an asynchronous. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <param name="token"> A token that allows processing to be cancelled. </param>
        /// <returns> An asynchronous result. </returns>
        public async Task ConnectAsync(CancellationToken token)
        {
            if (_socket != null && _socket.State == WebSocketState.Open)
                return;

            if (_socket == null || _socket.State != WebSocketState.None)
            {
                _jsonRpc?.Dispose();
                _socket?.Dispose();
                _socket = new ClientWebSocket();
            }

            _connectTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(token, _connectTokenSource.Token);
            await _socket.ConnectAsync(_uri, linkedTokenSource.Token);
            linkedTokenSource.Dispose();
            _connectTokenSource.Dispose();
            _connectTokenSource = null;
            Logger.Debug("Connected to Websocket.");

            var formatter = new JsonMessageFormatter();
            // adding convertersto the formatter
            formatter.JsonSerializer.Converters.Add(new GenericTypeConverter<U8>());
            formatter.JsonSerializer.Converters.Add(new GenericTypeConverter<U16>());
            formatter.JsonSerializer.Converters.Add(new GenericTypeConverter<U32>());
            formatter.JsonSerializer.Converters.Add(new GenericTypeConverter<U64>());
            formatter.JsonSerializer.Converters.Add(new GenericTypeConverter<Hash>());
            formatter.JsonSerializer.Converters.Add(_extrinsicJsonConverter);
            formatter.JsonSerializer.Converters.Add(_extrinsicStatusJsonConverter);

            _jsonRpc = new JsonRpc(new WebSocketMessageHandler(_socket, formatter));
            _jsonRpc.TraceSource.Listeners.Add(new NLogTraceListener());
            _jsonRpc.TraceSource.Switch.Level = SourceLevels.Warning;
            _jsonRpc.AddLocalRpcTarget(Listener, new JsonRpcTargetOptions {AllowNonPublicInvocation = false});
            _jsonRpc.StartListening();
            Logger.Debug("Listening to websocket.");

            var result = await State.GetMetaDataAsync(token);
            var metaDataParser = new MetaDataParser(_uri.OriginalString, result);
            MetaData = metaDataParser.MetaData;
            Logger.Debug("MetaData parsed.");

            var genesis = new BlockNumber();
            genesis.Create(0);
            GenesisHash = await Chain.GetBlockHashAsync(genesis, token);
            Logger.Debug("Genesis hash parsed.");

            RuntimeVersion = await State.GetRuntimeVersionAsync(token);
            Logger.Debug("Runtime version parsed.");

            _jsonRpc.TraceSource.Switch.Level = SourceLevels.All;
        }

        /// <summary> Gets storage asynchronous. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <param name="moduleName"> Name of the module. </param>
        /// <param name="itemName">   Name of the item. </param>
        /// <returns> The storage. </returns>
        public async Task<object> GetStorageAsync(string moduleName, string itemName)
        {
            return await GetStorageAsync(moduleName, itemName, CancellationToken.None);
        }

        /// <summary> Gets storage asynchronous. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <param name="moduleName"> Name of the module. </param>
        /// <param name="itemName">   Name of the item. </param>
        /// <param name="token">      A token that allows processing to be cancelled. </param>
        /// <returns> Returns storage object of ITypeConverter result.</returns>
        public async Task<object> GetStorageAsync(string moduleName, string itemName, CancellationToken token)
        {
            return await GetStorageAsync(moduleName, itemName, null, null, token);
        }

        /// <summary> Gets storage asynchronous. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <param name="moduleName"> Name of the module. </param>
        /// <param name="itemName">   Name of the item. </param>
        /// <param name="key1Param">  The parameter. </param>
        /// <returns> Returns storage object of ITypeConverter result.</returns>
        public async Task<object> GetStorageAsync(string moduleName, string itemName, string[] key1Param)
        {
            return await GetStorageAsync(moduleName, itemName, key1Param, null, CancellationToken.None);
        }

        /// <summary>Gets the storage asynchronous.</summary>
        /// <param name="moduleName">Name of the module.</param>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="key1Param">The key1 parameter.</param>
        /// <param name="key2Param">The key2 parameter.</param>
        /// <returns> Returns storage object of ITypeConverter result.</returns>
        public async Task<object> GetStorageAsync(string moduleName, string itemName, string[] key1Param, string[] key2Param)
        {
            return await GetStorageAsync(moduleName, itemName, key1Param, key2Param, CancellationToken.None);
        }

        /// <summary>Gets the storage asynchronous.</summary>
        /// <param name="moduleName">Name of the module.</param>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="key1Param">The key1 parameter.</param>
        /// <param name="key2Param">The key2 parameter.</param>
        /// <param name="token">The token.</param>
        /// <returns> Returns storage object of ITypeConverter result.</returns>
        /// <exception cref="ClientNotConnectedException">WebSocketState is not open! Currently {_socket?.State}!</exception>
        /// <exception cref="MissingModuleOrItemException">Module '{moduleName}' or Item '{itemName}' missing in metadata of '{MetaData.Origin}'!</exception>
        /// <exception cref="MissingParameterException"></exception>
        /// <exception cref="MissingConverterException">Unknown type '{returnType}' for result '{resultString}'!</exception>
        public async Task<object> GetStorageAsync(string moduleName, string itemName, string[] key1Param, string[] key2Param,
            CancellationToken token)
        {
            if (_socket?.State != WebSocketState.Open)
                throw new ClientNotConnectedException($"WebSocketState is not open! Currently {_socket?.State}!");

            if (!MetaData.TryGetModuleByName(moduleName, out var module) ||
                !module.TryGetStorageItemByName(itemName, out var item))
                throw new MissingModuleOrItemException(
                    $"Module '{moduleName}' or Item '{itemName}' missing in metadata of '{MetaData.Origin}'!");

            // map
            if (item.Function?.Key1 != null && (key1Param == null || key1Param.Length == 0))
                throw new MissingParameterException(
                    $"{moduleName}.{itemName} needs a parameter of type '{item.Function?.Key1}'!");

            // double map
            if (item.Function?.Key2 != null && (key2Param == null || key2Param.Length == 0))
                throw new MissingParameterException(
                    $"{moduleName}.{itemName} needs a parameter of type '{item.Function?.Key2}'!");

            var parameters = RequestGenerator.GetStorage(module, item, key1Param, key2Param);

            var resultString = await InvokeAsync<string>("state_getStorage", new object[] {parameters}, token);

            var returnType = item.Function?.Value;

            if (!_typeConverters.ContainsKey(returnType))
                throw new MissingConverterException($"Unknown type '{returnType}' for result '{resultString}'!");

            return _typeConverters[returnType].Create(resultString);
        }

        /// <summary>
        /// Subscribe Storage Key Async
        /// </summary>
        /// <param name="moduleName"></param>
        /// <param name="itemName"></param>
        /// <param name="parameter"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public async Task<string> SubscribeStorageKeyAsync(string moduleName, string itemName, string[] parameter,
            Action<string, StorageChangeSet> callback)
        {
            return await SubscribeStorageKeyAsync(moduleName, itemName, parameter, callback, CancellationToken.None);
        }

        /// <summary>
        /// Subscribe Storage Key Async
        /// </summary>
        /// <param name="moduleName"></param>
        /// <param name="itemName"></param>
        /// <param name="parameter"></param>
        /// <param name="callback"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<string> SubscribeStorageKeyAsync(string moduleName, string itemName, string[] parameter,
            Action<string, StorageChangeSet> callback, CancellationToken token)
        {
            if (_socket?.State != WebSocketState.Open)
                throw new ClientNotConnectedException($"WebSocketState is not open! Currently {_socket?.State}!");

            if (!MetaData.TryGetModuleByName(moduleName, out var module) ||
                !module.TryGetStorageItemByName(itemName, out var item))
                throw new MissingModuleOrItemException(
                    $"Module '{moduleName}' or Item '{itemName}' missing in metadata of '{MetaData.Origin}'!");

            if (item.Function?.Key1 != null && (parameter == null || parameter.Length == 0))
                throw new MissingParameterException(
                    $"{moduleName}.{itemName} needs a parameter of type '{item.Function?.Key1}'!");

            var parameters = RequestGenerator.GetStorage(module, item, parameter);

            var subscriptionId =
                await InvokeAsync<string>("state_subscribeStorage", new object[] {new JArray {parameters}}, token);
            Listener.RegisterCallBackHandler(subscriptionId, callback);
            return subscriptionId;
        }

        /// <summary>
        /// Get Storage Keys Async
        /// </summary>
        /// <param name="moduleName"></param>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public async Task<JArray> GetStorageKeysAsync(string moduleName, string itemName)
        {
            return await GetStorageKeysAsync(moduleName, itemName, CancellationToken.None);
        }

        /// <summary>
        /// Get Storage Keys Async
        /// </summary>
        /// <param name="moduleName"></param>
        /// <param name="itemName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<JArray> GetStorageKeysAsync(string moduleName, string itemName, CancellationToken token)
        {
            if (_socket?.State != WebSocketState.Open)
                throw new ClientNotConnectedException($"WebSocketState is not open! Currently {_socket?.State}!");

            if (!MetaData.TryGetModuleByName(moduleName, out var module) ||
                !module.TryGetStorageItemByName(itemName, out var item))
                throw new MissingModuleOrItemException(
                    $"Module '{moduleName}' or Item '{itemName}' missing in metadata of '{MetaData.Origin}'!");

            var parameters = Utils.Bytes2HexString(RequestGenerator.GetStorageKeyBytesHash(module, item));

            return await InvokeAsync<JArray>("state_getKeys", new object[] {parameters}, token);
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="key"></param>
        ///// <param name="parameter"></param>
        ///// <param name="moduleName"></param>
        ///// <param name="itemName"></param>
        ///// <returns></returns>
        //private byte[] GetParameterBytes(string key, string[] parameter, string moduleName = "", string itemName = "")
        //{
        //    // multi keys support
        //    if (key.StartsWith("("))
        //    {
        //        var keysDelimited = key.Replace("(", "").Replace(")", "");
        //        var keys = keysDelimited.
        //        (',');
        //        if (keys.Length != parameter.Length)
        //            throw new MissingParameterException(
        //                $"{moduleName}.{itemName} needs {keys.Length} keys, but provided where {parameter.Length} keys!");
        //        var byteList = new List<byte>();
        //        for (var i = 0; i < keys.Length; i++)
        //            byteList.AddRange(Utils.KeyTypeToBytes(keys[i].Trim(), parameter[i]));
        //        return byteList.ToArray();
        //    }
        //    // single key support

        //    return Utils.KeyTypeToBytes(key, parameter[0]);
        //}

        /// <summary> Gets method asynchronous. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="method"> The method. </param>
        /// <returns> The method async&lt; t&gt; </returns>
        public async Task<T> GetMethodAsync<T>(string method)
        {
            return await GetMethodAsync<T>(method, CancellationToken.None);
        }

        /// <summary> Gets method asynchronous. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="method"> The method. </param>
        /// <param name="token">  A token that allows processing to be cancelled. </param>
        /// <returns> The method async&lt; t&gt; </returns>
        public async Task<T> GetMethodAsync<T>(string method, CancellationToken token)
        {
            return await InvokeAsync<T>(method, null, token);
        }

        /// <summary> Gets method asynchronous. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="method">    The method. </param>
        /// <param name="parameter"> The parameter. </param>
        /// <param name="token">     A token that allows processing to be cancelled. </param>
        /// <returns> The method async&lt; t&gt; </returns>
        public async Task<T> GetMethodAsync<T>(string method, string parameter, CancellationToken token)
        {
            return await InvokeAsync<T>(method, new object[] {parameter}, token);
        }

        /// <summary>
        /// Get an unchecked extrinsic.
        /// </summary>
        /// <param name="callArguments"></param>
        /// <param name="account"></param>
        /// <param name="tip"></param>
        /// <param name="lifeTime"></param>
        /// <param name="signed"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<UnCheckedExtrinsic> GetExtrinsicParametersAsync(GenericExtrinsicCall callArguments, Account account, uint tip, uint lifeTime, bool signed, CancellationToken token)
        {
            var method = GetMethod(callArguments);

            var nonce = await System.AccountNextIndexAsync(account.Value, token);

            Era era;
            Hash startEra;

            if (lifeTime == 0)
            {
                era = Era.Create(0, 0);
                startEra = GenesisHash;
            }
            else
            {
                startEra = await Chain.GetFinalizedHeadAsync(token);
                var finalizedHeader = await Chain.GetHeaderAsync(startEra, token);
                era = Era.Create(lifeTime, finalizedHeader.Number.Value);
            }

            return RequestGenerator.SubmitExtrinsic(signed, account, method, era, nonce, tip, GenesisHash, startEra, RuntimeVersion);
        }

        public Method GetMethod(GenericExtrinsicCall callArguments)
        {
            if (!MetaData.TryGetModuleByName(callArguments.ModuleName, out var module) ||
                !module.TryGetCallByName(callArguments.CallName, out var call))
                throw new MissingModuleOrItemException(
                    $"Module '{callArguments.ModuleName}' or Item '{callArguments.CallName}' missing in metadata of '{MetaData.Origin}'!");

            if (call.Arguments?.Length > 0 && callArguments == null)
                throw new MissingParameterException(
                    $"{callArguments.ModuleName}.{callArguments.CallName} needs {call.Arguments.Length} parameter(s)!");

            return new Method(module, call, callArguments?.Encode());
        }

        /// <summary>
        ///     Executes the asynchronous on a different thread, and waits for the result.
        /// </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <exception cref="ClientNotConnectedException">
        ///     Thrown when a Client Not Connected error
        ///     condition occurs.
        /// </exception>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="method">     The method. </param>
        /// <param name="parameters"> Options for controlling the operation. </param>
        /// <param name="token">      A token that allows processing to be cancelled. </param>
        /// <returns> A T. </returns>
        internal async Task<T> InvokeAsync<T>(string method, object parameters, CancellationToken token)
        {
            if (_socket?.State != WebSocketState.Open)
                throw new ClientNotConnectedException($"WebSocketState is not open! Currently {_socket?.State}!");

            Logger.Debug($"Invoking request[{method}, params: {parameters}] {MetaData?.Origin}");

            var requestTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            _requestTokenSourceDict.TryAdd(requestTokenSource, string.Empty);

            var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(token, requestTokenSource.Token);
            var resultString =
                await _jsonRpc.InvokeWithParameterObjectAsync<T>(method, parameters, linkedTokenSource.Token);

            linkedTokenSource.Dispose();
            requestTokenSource.Dispose();

            _requestTokenSourceDict.TryRemove(requestTokenSource, out var _);

            return resultString;
        }

        /// <summary> Closes an asynchronous. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <returns> An asynchronous result. </returns>
        public async Task CloseAsync()
        {
            await CloseAsync(CancellationToken.None);
        }

        /// <summary> Closes an asynchronous. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <param name="token"> A token that allows processing to be cancelled. </param>
        /// <returns> An asynchronous result. </returns>
        public async Task CloseAsync(CancellationToken token)
        {
            _connectTokenSource?.Cancel();

            await Task.Run(() =>
            {
                // cancel remaining request tokens
                foreach (var key in _requestTokenSourceDict.Keys) key?.Cancel();
                _requestTokenSourceDict.Clear();

                if (_socket != null && _socket.State == WebSocketState.Open)
                {
                    _jsonRpc?.Dispose();
                    Logger.Debug("Client closed.");
                }
            });
        }

        #region IDisposable Support

        /// <summary> To detect redundant calls. </summary>
        private bool _disposedValue;

        /// <summary> This code added to correctly implement the disposable pattern. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <param name="disposing">
        ///     True to release both managed and unmanaged resources; false to
        ///     release only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    new JoinableTaskFactory(new JoinableTaskContext()).Run(CloseAsync);
                    _connectTokenSource?.Dispose();

                    // dispose remaining request tokens
                    foreach (var key in _requestTokenSourceDict.Keys) key?.Dispose();
                    _requestTokenSourceDict.Clear();

                    _jsonRpc?.Dispose();
                    _socket?.Dispose();
                    Logger.Debug("Client disposed.");
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SubstrateClient()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        /// <summary> This code added to correctly implement the disposable pattern. </summary>
        /// <remarks> 19.09.2020. </remarks>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
}