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


namespace SubstrateNetApi.Model.PalletRecovery
{
    
    
    /// <summary>
    /// >> 445 - Variant[pallet_recovery.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://substrate.dev/docs/en/knowledgebase/runtime/errors)
    ///			of this pallet.
    ///			
    /// </summary>
    public enum PalletRecoveryError
    {
        
        /// <summary>
        /// >> NotAllowed
        /// </summary>
        NotAllowed,
        
        /// <summary>
        /// >> ZeroThreshold
        /// </summary>
        ZeroThreshold,
        
        /// <summary>
        /// >> NotEnoughFriends
        /// </summary>
        NotEnoughFriends,
        
        /// <summary>
        /// >> MaxFriends
        /// </summary>
        MaxFriends,
        
        /// <summary>
        /// >> NotSorted
        /// </summary>
        NotSorted,
        
        /// <summary>
        /// >> NotRecoverable
        /// </summary>
        NotRecoverable,
        
        /// <summary>
        /// >> AlreadyRecoverable
        /// </summary>
        AlreadyRecoverable,
        
        /// <summary>
        /// >> AlreadyStarted
        /// </summary>
        AlreadyStarted,
        
        /// <summary>
        /// >> NotStarted
        /// </summary>
        NotStarted,
        
        /// <summary>
        /// >> NotFriend
        /// </summary>
        NotFriend,
        
        /// <summary>
        /// >> DelayPeriod
        /// </summary>
        DelayPeriod,
        
        /// <summary>
        /// >> AlreadyVouched
        /// </summary>
        AlreadyVouched,
        
        /// <summary>
        /// >> Threshold
        /// </summary>
        Threshold,
        
        /// <summary>
        /// >> StillActive
        /// </summary>
        StillActive,
        
        /// <summary>
        /// >> AlreadyProxy
        /// </summary>
        AlreadyProxy,
        
        /// <summary>
        /// >> BadState
        /// </summary>
        BadState,
    }
}