//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SubstrateNetApi.Model.Base;
using SubstrateNetApi.Model.PalletMultisig;
using SubstrateNetApi.Model.SpCore;
using SubstrateNetApi.Model.Types.Base;
using System;
using System.Collections.Generic;


namespace SubstrateNetApi.Model.PalletMultisig
{
    
    
    /// <summary>
    /// >> 79 - Variant[pallet_multisig.pallet.Event]
    /// 
    ///			The [event](https://substrate.dev/docs/en/knowledgebase/runtime/events) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class PalletMultisigEvent
    {
        
        /// <summary>
        /// >> NewMultisig
        /// </summary>
        public sealed class NewMultisig : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Base.Arr32U8>
        {
        }
        
        /// <summary>
        /// >> MultisigApproval
        /// </summary>
        public sealed class MultisigApproval : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.PalletMultisig.Timepoint, SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Base.Arr32U8>
        {
        }
        
        /// <summary>
        /// >> MultisigExecuted
        /// </summary>
        public sealed class MultisigExecuted : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.PalletMultisig.Timepoint, SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Base.Arr32U8, BaseTuple<BaseTuple,  SubstrateNetApi.Model.SpRuntime.EnumDispatchError>>
        {
        }
        
        /// <summary>
        /// >> MultisigCancelled
        /// </summary>
        public sealed class MultisigCancelled : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.PalletMultisig.Timepoint, SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Base.Arr32U8>
        {
        }
    }
}