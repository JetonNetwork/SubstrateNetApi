//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SubstrateNetApi.Model.Types.Base;
using System;
using System.Collections.Generic;


namespace SubstrateNetApi.Model.FrameSystem
{
    
    
    /// <summary>
    /// >> 118 - Variant[frame_system.pallet.Error]
    /// Error for the System pallet
    /// </summary>
    public enum FrameSystemError
    {
        
        /// <summary>
        /// >> InvalidSpecName
        /// </summary>
        InvalidSpecName,
        
        /// <summary>
        /// >> SpecVersionNeedsToIncrease
        /// </summary>
        SpecVersionNeedsToIncrease,
        
        /// <summary>
        /// >> FailedToExtractRuntimeVersion
        /// </summary>
        FailedToExtractRuntimeVersion,
        
        /// <summary>
        /// >> NonDefaultComposite
        /// </summary>
        NonDefaultComposite,
        
        /// <summary>
        /// >> NonZeroRefCount
        /// </summary>
        NonZeroRefCount,
    }
}