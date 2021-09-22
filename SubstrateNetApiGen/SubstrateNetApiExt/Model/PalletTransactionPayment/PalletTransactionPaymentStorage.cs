//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SubstrateNetApi.Model.Meta;
using SubstrateNetApi.Model.PalletTransactionPayment;
using SubstrateNetApi.Model.SpArithmetic;
using SubstrateNetApi.Model.Types;
using SubstrateNetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace SubstrateNetApi.Model.PalletTransactionPayment
{
    
    
    public sealed class PalletTransactionPaymentStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateNetApi.SubstrateClient _client;
        
        public PalletTransactionPaymentStorage(SubstrateNetApi.SubstrateClient client)
        {
            this._client = client;
        }
        
        /// <summary>
        /// >> NextFeeMultiplier
        /// </summary>
        public async Task<SubstrateNetApi.Model.SpArithmetic.FixedU128> NextFeeMultiplier(CancellationToken token)
        {
            var parameters = RequestGenerator.GetStorage("TransactionPayment", "NextFeeMultiplier", Storage.Type.Plain);
            return await _client.GetStorageAsync<SubstrateNetApi.Model.SpArithmetic.FixedU128>(parameters, token);
        }
        
        /// <summary>
        /// >> StorageVersion
        /// </summary>
        public async Task<SubstrateNetApi.Model.PalletTransactionPayment.EnumReleases> StorageVersion(CancellationToken token)
        {
            var parameters = RequestGenerator.GetStorage("TransactionPayment", "StorageVersion", Storage.Type.Plain);
            return await _client.GetStorageAsync<SubstrateNetApi.Model.PalletTransactionPayment.EnumReleases>(parameters, token);
        }
    }
}
