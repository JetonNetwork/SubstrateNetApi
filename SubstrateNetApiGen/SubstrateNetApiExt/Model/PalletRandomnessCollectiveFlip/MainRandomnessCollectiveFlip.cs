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
using SubstrateNetApi.Model.PrimitiveTypes;
using SubstrateNetApi.Model.Types;
using SubstrateNetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace SubstrateNetApi.Model.PalletRandomnessCollectiveFlip
{
    
    
    public sealed class RandomnessCollectiveFlipStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateNetApi.SubstrateClient _client;
        
        public RandomnessCollectiveFlipStorage(SubstrateNetApi.SubstrateClient client)
        {
            this._client = client;
        }
        
        /// <summary>
        /// >> RandomMaterialParams
        ///  Series of block headers from the last 81 blocks that acts as random seed material. This
        ///  is arranged as a ring buffer with `block_number % 81` being the index into the `Vec` of
        ///  the oldest hash.
        /// </summary>
        public static string RandomMaterialParams()
        {
            return RequestGenerator.GetStorage("RandomnessCollectiveFlip", "RandomMaterial", SubstrateNetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> RandomMaterial
        ///  Series of block headers from the last 81 blocks that acts as random seed material. This
        ///  is arranged as a ring buffer with `block_number % 81` being the index into the `Vec` of
        ///  the oldest hash.
        /// </summary>
        public async Task<BaseVec<SubstrateNetApi.Model.PrimitiveTypes.H256>> RandomMaterial(CancellationToken token)
        {
            string parameters = RandomnessCollectiveFlipStorage.RandomMaterialParams();
            return await _client.GetStorageAsync<BaseVec<SubstrateNetApi.Model.PrimitiveTypes.H256>>(parameters, token);
        }
    }
    
    public sealed class RandomnessCollectiveFlipCalls
    {
    }
}
