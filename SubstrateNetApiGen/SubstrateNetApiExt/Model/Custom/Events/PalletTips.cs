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
    /// >> Path: pallet_tips.pallet.Event
    /// 
    ///			The [event](https://substrate.dev/docs/en/knowledgebase/runtime/events) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class PalletTips
    {
        
        /// <summary>
        /// >> Event: NewTip
        /// A new tip suggestion has been opened. \[tip_hash\]
        /// </summary>
        public sealed class NewTip : BaseTuple<H256>
        {
        }
        
        /// <summary>
        /// >> Event: TipClosing
        /// A tip suggestion has reached threshold and is closing. \[tip_hash\]
        /// </summary>
        public sealed class TipClosing : BaseTuple<H256>
        {
        }
        
        /// <summary>
        /// >> Event: TipClosed
        /// A tip suggestion has been closed. \[tip_hash, who, payout\]
        /// </summary>
        public sealed class TipClosed : BaseTuple<H256, AccountId32, U128>
        {
        }
        
        /// <summary>
        /// >> Event: TipRetracted
        /// A tip suggestion has been retracted. \[tip_hash\]
        /// </summary>
        public sealed class TipRetracted : BaseTuple<H256>
        {
        }
        
        /// <summary>
        /// >> Event: TipSlashed
        /// A tip suggestion has been slashed. \[tip_hash, finder, deposit\]
        /// </summary>
        public sealed class TipSlashed : BaseTuple<H256, AccountId32, U128>
        {
        }
    }
}