//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SubstrateNetApi.Model.Types.Base;
using SubstrateNetApi.Model.Types.Composite;
using SubstrateNetApi.Model.Types.Enum;
using SubstrateNetApi.Model.Types.Primitive;
using SubstrateNetApi.Model.Types.Sequence;
using System;
using System.Collections.Generic;


namespace SubstrateNetApi.Model.Custom.Events
{
    
    
    /// <summary>
    /// >> Path: pallet_collective.pallet.Event
    /// 
    ///			The [event](https://substrate.dev/docs/en/knowledgebase/runtime/events) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class PalletCollective
    {
        
        /// <summary>
        /// >> Event: Proposed
        /// A motion (given hash) has been proposed (by given account) with a threshold (given
        /// `MemberCount`).
        /// \[account, proposal_index, proposal_hash, threshold\]
        /// </summary>
        public sealed class Proposed : BaseTuple<AccountId32, U32, H256, U32>
        {
        }
        
        /// <summary>
        /// >> Event: Voted
        /// A motion (given hash) has been voted on by given account, leaving
        /// a tally (yes votes and no votes given respectively as `MemberCount`).
        /// \[account, proposal_hash, voted, yes, no\]
        /// </summary>
        public sealed class Voted : BaseTuple<AccountId32, H256, Bool, U32, U32>
        {
        }
        
        /// <summary>
        /// >> Event: Approved
        /// A motion was approved by the required threshold.
        /// \[proposal_hash\]
        /// </summary>
        public sealed class Approved : BaseTuple<H256>
        {
        }
        
        /// <summary>
        /// >> Event: Disapproved
        /// A motion was not approved by the required threshold.
        /// \[proposal_hash\]
        /// </summary>
        public sealed class Disapproved : BaseTuple<H256>
        {
        }
        
        /// <summary>
        /// >> Event: Executed
        /// A motion was executed; result will be `Ok` if it returned without error.
        /// \[proposal_hash, result\]
        /// </summary>
        public sealed class Executed : BaseTuple<H256, BaseTuple<BaseTuple, EnumDispatchError>>
        {
        }
        
        /// <summary>
        /// >> Event: MemberExecuted
        /// A single member did some action; result will be `Ok` if it returned without error.
        /// \[proposal_hash, result\]
        /// </summary>
        public sealed class MemberExecuted : BaseTuple<H256, BaseTuple<BaseTuple, EnumDispatchError>>
        {
        }
        
        /// <summary>
        /// >> Event: Closed
        /// A proposal was closed because its threshold was reached or after its duration was up.
        /// \[proposal_hash, yes, no\]
        /// </summary>
        public sealed class Closed : BaseTuple<H256, U32, U32>
        {
        }
    }
}