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


namespace SubstrateNetApi.Model.Custom.Errors
{
    
    
    /// <summary>
    /// >> Path: pallet_authorship.pallet.Error
    /// 
    ///			Custom [dispatch errors](https://substrate.dev/docs/en/knowledgebase/runtime/errors)
    ///			of this pallet.
    ///			
    /// </summary>
    public enum PalletAuthorship
    {
        
        /// <summary>
        /// >> Event: InvalidUncleParent
        /// The uncle parent not in the chain.
        /// </summary>
        InvalidUncleParent,
        
        /// <summary>
        /// >> Event: UnclesAlreadySet
        /// Uncles already set in the block.
        /// </summary>
        UnclesAlreadySet,
        
        /// <summary>
        /// >> Event: TooManyUncles
        /// Too many uncles.
        /// </summary>
        TooManyUncles,
        
        /// <summary>
        /// >> Event: GenesisUncle
        /// The uncle is genesis.
        /// </summary>
        GenesisUncle,
        
        /// <summary>
        /// >> Event: TooHighUncle
        /// The uncle is too high in chain.
        /// </summary>
        TooHighUncle,
        
        /// <summary>
        /// >> Event: UncleAlreadyIncluded
        /// The uncle is already included.
        /// </summary>
        UncleAlreadyIncluded,
        
        /// <summary>
        /// >> Event: OldUncle
        /// The uncle isn't recent enough to be included.
        /// </summary>
        OldUncle,
    }
}