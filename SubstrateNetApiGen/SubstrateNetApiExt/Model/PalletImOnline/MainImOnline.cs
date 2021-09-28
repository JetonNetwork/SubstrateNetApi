//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SubstrateNetApi.Model.Extrinsics;
using SubstrateNetApi.Model.FrameSupport;
using SubstrateNetApi.Model.Meta;
using SubstrateNetApi.Model.PalletImOnline;
using SubstrateNetApi.Model.PalletStaking;
using SubstrateNetApi.Model.SpCore;
using SubstrateNetApi.Model.Types;
using SubstrateNetApi.Model.Types.Base;
using SubstrateNetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace SubstrateNetApi.Model.PalletImOnline
{
    
    
    public sealed class ImOnlineStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateNetApi.SubstrateClient _client;
        
        public ImOnlineStorage(SubstrateNetApi.SubstrateClient client)
        {
            this._client = client;
        }
        
        public static string HeartbeatAfterParams()
        {
            var parameters = RequestGenerator.GetStorage("ImOnline", "HeartbeatAfter", Storage.Type.Plain);
            return parameters;
        }
        
        /// <summary>
        /// >> HeartbeatAfter
        /// </summary>
        public async Task<SubstrateNetApi.Model.Types.Primitive.U32> HeartbeatAfter(CancellationToken token)
        {
            string parameters = ImOnlineStorage.HeartbeatAfterParams();
            return await _client.GetStorageAsync<SubstrateNetApi.Model.Types.Primitive.U32>(parameters, token);
        }
        
        public static string KeysParams()
        {
            var parameters = RequestGenerator.GetStorage("ImOnline", "Keys", Storage.Type.Plain);
            return parameters;
        }
        
        /// <summary>
        /// >> Keys
        /// </summary>
        public async Task<SubstrateNetApi.Model.FrameSupport.WeakBoundedVec> Keys(CancellationToken token)
        {
            string parameters = ImOnlineStorage.KeysParams();
            return await _client.GetStorageAsync<SubstrateNetApi.Model.FrameSupport.WeakBoundedVec>(parameters, token);
        }
        
        public static string ReceivedHeartbeatsParams(BaseTuple<SubstrateNetApi.Model.Types.Primitive.U32,SubstrateNetApi.Model.Types.Primitive.U32> key)
        {
            var keyParams = key.Value;
            var parameters = RequestGenerator.GetStorage("ImOnline", "ReceivedHeartbeats", Storage.Type.Map, new[] {Storage.Hasher.Twox64Concat,Storage.Hasher.Twox64Concat}, keyParams);
            return parameters;
        }
        
        /// <summary>
        /// >> ReceivedHeartbeats
        /// </summary>
        public async Task<SubstrateNetApi.Model.FrameSupport.WrapperOpaque> ReceivedHeartbeats(BaseTuple<SubstrateNetApi.Model.Types.Primitive.U32,SubstrateNetApi.Model.Types.Primitive.U32> key, CancellationToken token)
        {
            string parameters = ImOnlineStorage.ReceivedHeartbeatsParams(key);
            return await _client.GetStorageAsync<SubstrateNetApi.Model.FrameSupport.WrapperOpaque>(parameters, token);
        }
        
        public static string AuthoredBlocksParams(BaseTuple<SubstrateNetApi.Model.Types.Primitive.U32,SubstrateNetApi.Model.SpCore.AccountId32> key)
        {
            var keyParams = key.Value;
            var parameters = RequestGenerator.GetStorage("ImOnline", "AuthoredBlocks", Storage.Type.Map, new[] {Storage.Hasher.Twox64Concat,Storage.Hasher.Twox64Concat}, keyParams);
            return parameters;
        }
        
        /// <summary>
        /// >> AuthoredBlocks
        /// </summary>
        public async Task<SubstrateNetApi.Model.Types.Primitive.U32> AuthoredBlocks(BaseTuple<SubstrateNetApi.Model.Types.Primitive.U32,SubstrateNetApi.Model.SpCore.AccountId32> key, CancellationToken token)
        {
            string parameters = ImOnlineStorage.AuthoredBlocksParams(key);
            return await _client.GetStorageAsync<SubstrateNetApi.Model.Types.Primitive.U32>(parameters, token);
        }
    }
    
    public sealed class ImOnlineCalls
    {
        
        /// <summary>
        /// >> heartbeat
        /// </summary>
        public static Method Heartbeat(SubstrateNetApi.Model.PalletImOnline.Heartbeat heartbeat, SubstrateNetApi.Model.PalletImOnline.Signature signature)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(heartbeat.Encode());
            byteArray.AddRange(signature.Encode());
            return new Method(20, "ImOnline", 0, "heartbeat", byteArray.ToArray());
        }
    }
    
    /// <summary>
    /// >> HeartbeatReceived
    /// </summary>
    public sealed class EventHeartbeatReceived : BaseTuple<SubstrateNetApi.Model.PalletImOnline.Public>
    {
    }
    
    /// <summary>
    /// >> AllGood
    /// </summary>
    public sealed class EventAllGood : BaseTuple
    {
    }
    
    /// <summary>
    /// >> SomeOffline
    /// </summary>
    public sealed class EventSomeOffline : BaseTuple<BaseVec<BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32,SubstrateNetApi.Model.PalletStaking.Exposure>>>
    {
    }
    
    public enum ImOnlineErrors
    {
        
        /// <summary>
        /// >> InvalidKey
        /// </summary>
        InvalidKey,
        
        /// <summary>
        /// >> DuplicatedHeartbeat
        /// </summary>
        DuplicatedHeartbeat,
    }
}
