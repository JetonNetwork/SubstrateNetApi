//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SubstrateNetApi.Model.Meta;
using SubstrateNetApi.Model.PalletGilt;
using SubstrateNetApi.Model.Types;
using SubstrateNetApi.Model.Types.Base;
using SubstrateNetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace SubstrateNetApi.Model.PalletGilt
{
    
    
    public sealed class PalletGiltStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateNetApi.SubstrateClient _client;
        
        public PalletGiltStorage(SubstrateNetApi.SubstrateClient client)
        {
            this._client = client;
        }
        
        /// <summary>
        /// >> QueueTotals
        /// </summary>
        public async Task<BaseVec<BaseTuple<SubstrateNetApi.Model.Types.Primitive.U32,SubstrateNetApi.Model.Types.Primitive.U128>>> QueueTotals(CancellationToken token)
        {
            var parameters = RequestGenerator.GetStorage("Gilt", "QueueTotals", Storage.Type.Plain);
            return await _client.GetStorageAsync<BaseVec<BaseTuple<SubstrateNetApi.Model.Types.Primitive.U32,SubstrateNetApi.Model.Types.Primitive.U128>>>(parameters, token);
        }
        
        /// <summary>
        /// >> Queues
        /// </summary>
        public async Task<BaseVec<SubstrateNetApi.Model.PalletGilt.GiltBid>> Queues(SubstrateNetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            var keyParams = new IType[] { key };
            var parameters = RequestGenerator.GetStorage("Gilt", "Queues", Storage.Type.Map, new[] {Storage.Hasher.BlakeTwo128Concat}, keyParams);
            return await _client.GetStorageAsync<BaseVec<SubstrateNetApi.Model.PalletGilt.GiltBid>>(parameters, token);
        }
        
        /// <summary>
        /// >> ActiveTotal
        /// </summary>
        public async Task<SubstrateNetApi.Model.PalletGilt.ActiveGiltsTotal> ActiveTotal(CancellationToken token)
        {
            var parameters = RequestGenerator.GetStorage("Gilt", "ActiveTotal", Storage.Type.Plain);
            return await _client.GetStorageAsync<SubstrateNetApi.Model.PalletGilt.ActiveGiltsTotal>(parameters, token);
        }
        
        /// <summary>
        /// >> Active
        /// </summary>
        public async Task<SubstrateNetApi.Model.PalletGilt.ActiveGilt> Active(SubstrateNetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            var keyParams = new IType[] { key };
            var parameters = RequestGenerator.GetStorage("Gilt", "Active", Storage.Type.Map, new[] {Storage.Hasher.BlakeTwo128Concat}, keyParams);
            return await _client.GetStorageAsync<SubstrateNetApi.Model.PalletGilt.ActiveGilt>(parameters, token);
        }
    }
}
