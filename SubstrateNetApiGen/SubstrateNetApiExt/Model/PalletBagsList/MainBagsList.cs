//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SubstrateNetApi.Model.Extrinsics;
using SubstrateNetApi.Model.Meta;
using SubstrateNetApi.Model.PalletBagsList;
using SubstrateNetApi.Model.SpCore;
using SubstrateNetApi.Model.Types;
using SubstrateNetApi.Model.Types.Base;
using SubstrateNetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace SubstrateNetApi.Model.PalletBagsList
{
    
    
    public sealed class BagsListStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateNetApi.SubstrateClient _client;
        
        public BagsListStorage(SubstrateNetApi.SubstrateClient client)
        {
            this._client = client;
        }
        
        public static string CounterForListNodesParams()
        {
            var parameters = RequestGenerator.GetStorage("BagsList", "CounterForListNodes", Storage.Type.Plain);
            return parameters;
        }
        
        /// <summary>
        /// >> CounterForListNodes
        /// </summary>
        public async Task<SubstrateNetApi.Model.Types.Primitive.U32> CounterForListNodes(CancellationToken token)
        {
            string parameters = BagsListStorage.CounterForListNodesParams();
            return await _client.GetStorageAsync<SubstrateNetApi.Model.Types.Primitive.U32>(parameters, token);
        }
        
        public static string ListNodesParams(SubstrateNetApi.Model.SpCore.AccountId32 key)
        {
            var keyParams = new IType[] { key };
            var parameters = RequestGenerator.GetStorage("BagsList", "ListNodes", Storage.Type.Map, new[] {Storage.Hasher.Twox64Concat}, keyParams);
            return parameters;
        }
        
        /// <summary>
        /// >> ListNodes
        /// </summary>
        public async Task<SubstrateNetApi.Model.PalletBagsList.Node> ListNodes(SubstrateNetApi.Model.SpCore.AccountId32 key, CancellationToken token)
        {
            string parameters = BagsListStorage.ListNodesParams(key);
            return await _client.GetStorageAsync<SubstrateNetApi.Model.PalletBagsList.Node>(parameters, token);
        }
        
        public static string ListBagsParams(SubstrateNetApi.Model.Types.Primitive.U64 key)
        {
            var keyParams = new IType[] { key };
            var parameters = RequestGenerator.GetStorage("BagsList", "ListBags", Storage.Type.Map, new[] {Storage.Hasher.Twox64Concat}, keyParams);
            return parameters;
        }
        
        /// <summary>
        /// >> ListBags
        /// </summary>
        public async Task<SubstrateNetApi.Model.PalletBagsList.Bag> ListBags(SubstrateNetApi.Model.Types.Primitive.U64 key, CancellationToken token)
        {
            string parameters = BagsListStorage.ListBagsParams(key);
            return await _client.GetStorageAsync<SubstrateNetApi.Model.PalletBagsList.Bag>(parameters, token);
        }
    }
    
    public sealed class BagsListCalls
    {
        
        /// <summary>
        /// >> rebag
        /// </summary>
        public static Method Rebag(SubstrateNetApi.Model.SpCore.AccountId32 dislocated)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(dislocated.Encode());
            return new Method(40, "BagsList", 0, "rebag", byteArray.ToArray());
        }
    }
    
    /// <summary>
    /// >> Rebagged
    /// </summary>
    public sealed class EventRebagged : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Types.Primitive.U64, SubstrateNetApi.Model.Types.Primitive.U64>
    {
    }
}
