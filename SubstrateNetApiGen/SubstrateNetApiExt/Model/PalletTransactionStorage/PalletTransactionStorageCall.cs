//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SubstrateNetApi.Model.Calls;
using SubstrateNetApi.Model.SpTransactionStorageProof;
using SubstrateNetApi.Model.Types.Base;
using SubstrateNetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;


namespace SubstrateNetApi.Model.PalletTransactionStorage
{
    
    
    /// <summary>
    /// >> 304 - Variant[pallet_transaction_storage.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class PalletTransactionStorageCall
    {
        
        /// <summary>
        /// >> store
        /// </summary>
        public GenericExtrinsicCall Store(BaseVec<SubstrateNetApi.Model.Types.Primitive.U8> data)
        {
            return new GenericExtrinsicCall("TransactionStorage", "store", data);
        }
        
        /// <summary>
        /// >> renew
        /// </summary>
        public GenericExtrinsicCall Renew(SubstrateNetApi.Model.Types.Primitive.U32 block, SubstrateNetApi.Model.Types.Primitive.U32 index)
        {
            return new GenericExtrinsicCall("TransactionStorage", "renew", block, index);
        }
        
        /// <summary>
        /// >> check_proof
        /// </summary>
        public GenericExtrinsicCall CheckProof(SubstrateNetApi.Model.SpTransactionStorageProof.TransactionStorageProof proof)
        {
            return new GenericExtrinsicCall("TransactionStorage", "check_proof", proof);
        }
    }
}