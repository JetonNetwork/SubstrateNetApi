//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SubstrateNetApi.Model.Custom.Runtime;
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
    /// >> Path: pallet_gilt.pallet.Event
    /// 
    ///			The [event](https://substrate.dev/docs/en/knowledgebase/runtime/events) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class PalletGilt
    {
        
        /// <summary>
        /// >> Event: BidPlaced
        /// A bid was successfully placed.
        /// \[ who, amount, duration \]
        /// </summary>
        public sealed class BidPlaced : BaseTuple<AccountId32, U128, U32>
        {
        }
        
        /// <summary>
        /// >> Event: BidRetracted
        /// A bid was successfully removed (before being accepted as a gilt).
        /// \[ who, amount, duration \]
        /// </summary>
        public sealed class BidRetracted : BaseTuple<AccountId32, U128, U32>
        {
        }
        
        /// <summary>
        /// >> Event: GiltIssued
        /// A bid was accepted as a gilt. The balance may not be released until expiry.
        /// \[ index, expiry, who, amount \]
        /// </summary>
        public sealed class GiltIssued : BaseTuple<U32, U32, AccountId32, U128>
        {
        }
        
        /// <summary>
        /// >> Event: GiltThawed
        /// An expired gilt has been thawed.
        /// \[ index, who, original_amount, additional_amount \]
        /// </summary>
        public sealed class GiltThawed : BaseTuple<U32, AccountId32, U128, U128>
        {
        }
    }
}