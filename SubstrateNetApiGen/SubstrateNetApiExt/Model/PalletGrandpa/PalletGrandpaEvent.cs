//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SubstrateNetApi.Model.SpFinalityGrandpa;
using SubstrateNetApi.Model.Types.Base;
using SubstrateNetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;


namespace SubstrateNetApi.Model.PalletGrandpa
{
    
    
    /// <summary>
    /// >> 49 - Variant[pallet_grandpa.pallet.Event]
    /// 
    ///			The [event](https://substrate.dev/docs/en/knowledgebase/runtime/events) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class PalletGrandpaEvent
    {
        
        /// <summary>
        /// >> NewAuthorities
        /// </summary>
        public sealed class NewAuthorities : BaseTuple<BaseVec<BaseTuple<SubstrateNetApi.Model.SpFinalityGrandpa.Public,SubstrateNetApi.Model.Types.Primitive.U64>>>
        {
        }
        
        /// <summary>
        /// >> Paused
        /// </summary>
        public sealed class Paused : BaseTuple
        {
        }
        
        /// <summary>
        /// >> Resumed
        /// </summary>
        public sealed class Resumed : BaseTuple
        {
        }
    }
}