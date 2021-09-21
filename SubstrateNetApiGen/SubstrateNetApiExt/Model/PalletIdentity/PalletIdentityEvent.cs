//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SubstrateNetApi.Model.SpCore;
using SubstrateNetApi.Model.Types.Base;
using SubstrateNetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;


namespace SubstrateNetApi.Model.PalletIdentity
{
    
    
    /// <summary>
    /// >> 68 - Variant[pallet_identity.pallet.Event]
    /// 
    ///			The [event](https://substrate.dev/docs/en/knowledgebase/runtime/events) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class PalletIdentityEvent
    {
        
        /// <summary>
        /// >> IdentitySet
        /// </summary>
        public sealed class IdentitySet : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32>
        {
        }
        
        /// <summary>
        /// >> IdentityCleared
        /// </summary>
        public sealed class IdentityCleared : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Types.Primitive.U128>
        {
        }
        
        /// <summary>
        /// >> IdentityKilled
        /// </summary>
        public sealed class IdentityKilled : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Types.Primitive.U128>
        {
        }
        
        /// <summary>
        /// >> JudgementRequested
        /// </summary>
        public sealed class JudgementRequested : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Types.Primitive.U32>
        {
        }
        
        /// <summary>
        /// >> JudgementUnrequested
        /// </summary>
        public sealed class JudgementUnrequested : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Types.Primitive.U32>
        {
        }
        
        /// <summary>
        /// >> JudgementGiven
        /// </summary>
        public sealed class JudgementGiven : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Types.Primitive.U32>
        {
        }
        
        /// <summary>
        /// >> RegistrarAdded
        /// </summary>
        public sealed class RegistrarAdded : BaseTuple<SubstrateNetApi.Model.Types.Primitive.U32>
        {
        }
        
        /// <summary>
        /// >> SubIdentityAdded
        /// </summary>
        public sealed class SubIdentityAdded : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Types.Primitive.U128>
        {
        }
        
        /// <summary>
        /// >> SubIdentityRemoved
        /// </summary>
        public sealed class SubIdentityRemoved : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Types.Primitive.U128>
        {
        }
        
        /// <summary>
        /// >> SubIdentityRevoked
        /// </summary>
        public sealed class SubIdentityRevoked : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Types.Primitive.U128>
        {
        }
    }
}