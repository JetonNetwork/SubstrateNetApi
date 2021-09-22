//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SubstrateNetApi.Model.FrameSupport;
using SubstrateNetApi.Model.Meta;
using SubstrateNetApi.Model.PalletBalances;
using SubstrateNetApi.Model.SpCore;
using SubstrateNetApi.Model.Types;
using SubstrateNetApi.Model.Types.Base;
using SubstrateNetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace SubstrateNetApi.Model.PalletBalances
{
    
    
    public sealed class PalletBalancesStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateNetApi.SubstrateClient _client;
        
        public PalletBalancesStorage(SubstrateNetApi.SubstrateClient client)
        {
            this._client = client;
        }
        
        /// <summary>
        /// >> TotalIssuance
        /// </summary>
        public async Task<SubstrateNetApi.Model.Types.Primitive.U128> TotalIssuance(CancellationToken token)
        {
            var parameters = RequestGenerator.GetStorage("Balances", "TotalIssuance", Storage.Type.Plain);
            return await _client.GetStorageAsync<SubstrateNetApi.Model.Types.Primitive.U128>(parameters, token);
        }
        
        /// <summary>
        /// >> Account
        /// </summary>
        public async Task<SubstrateNetApi.Model.PalletBalances.AccountData> Account(SubstrateNetApi.Model.SpCore.AccountId32 key, CancellationToken token)
        {
            var keyParams = new IType[] { key };
            var parameters = RequestGenerator.GetStorage("Balances", "Account", Storage.Type.Map, new[] {Storage.Hasher.BlakeTwo128Concat}, keyParams);
            return await _client.GetStorageAsync<SubstrateNetApi.Model.PalletBalances.AccountData>(parameters, token);
        }
        
        /// <summary>
        /// >> Locks
        /// </summary>
        public async Task<SubstrateNetApi.Model.FrameSupport.WeakBoundedVec> Locks(SubstrateNetApi.Model.SpCore.AccountId32 key, CancellationToken token)
        {
            var keyParams = new IType[] { key };
            var parameters = RequestGenerator.GetStorage("Balances", "Locks", Storage.Type.Map, new[] {Storage.Hasher.BlakeTwo128Concat}, keyParams);
            return await _client.GetStorageAsync<SubstrateNetApi.Model.FrameSupport.WeakBoundedVec>(parameters, token);
        }
        
        /// <summary>
        /// >> Reserves
        /// </summary>
        public async Task<SubstrateNetApi.Model.FrameSupport.BoundedVec> Reserves(SubstrateNetApi.Model.SpCore.AccountId32 key, CancellationToken token)
        {
            var keyParams = new IType[] { key };
            var parameters = RequestGenerator.GetStorage("Balances", "Reserves", Storage.Type.Map, new[] {Storage.Hasher.BlakeTwo128Concat}, keyParams);
            return await _client.GetStorageAsync<SubstrateNetApi.Model.FrameSupport.BoundedVec>(parameters, token);
        }
        
        /// <summary>
        /// >> StorageVersion
        /// </summary>
        public async Task<SubstrateNetApi.Model.PalletBalances.EnumReleases> StorageVersion(CancellationToken token)
        {
            var parameters = RequestGenerator.GetStorage("Balances", "StorageVersion", Storage.Type.Plain);
            return await _client.GetStorageAsync<SubstrateNetApi.Model.PalletBalances.EnumReleases>(parameters, token);
        }
    }
}
