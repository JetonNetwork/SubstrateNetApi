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
    /// >> Path: pallet_utility.pallet.Event
    /// 
    ///			The [event](https://substrate.dev/docs/en/knowledgebase/runtime/events) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class PalletUtility
    {
        
        /// <summary>
        /// >> Event: BatchInterrupted
        /// Batch of dispatches did not complete fully. Index of first failing dispatch given, as
        /// well as the error. \[index, error\]
        /// </summary>
        public sealed class BatchInterrupted : BaseTuple<U32, EnumDispatchError>
        {
        }
        
        /// <summary>
        /// >> Event: BatchCompleted
        /// Batch of dispatches completed fully with no error.
        /// </summary>
        public sealed class BatchCompleted : BaseTuple
        {
        }
        
        /// <summary>
        /// >> Event: ItemCompleted
        /// A single item within a Batch of dispatches has completed with no error.
        /// </summary>
        public sealed class ItemCompleted : BaseTuple
        {
        }
    }
}