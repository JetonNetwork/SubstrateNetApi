//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SubstrateNetApi.Model.PrimitiveTypes;
using SubstrateNetApi.Model.SpCore;
using SubstrateNetApi.Model.Types.Base;
using SubstrateNetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;


namespace SubstrateNetApi.Model.PalletAuthorship
{
    
    
    public enum UncleEntryItem
    {
        
        InclusionHeight,
        
        Uncle,
    }
    
    /// <summary>
    /// >> 315 - Variant[pallet_authorship.UncleEntryItem]
    /// </summary>
    public sealed class EnumUncleEntryItem : BaseEnumExt<UncleEntryItem, SubstrateNetApi.Model.Types.Primitive.U32, BaseTuple<SubstrateNetApi.Model.PrimitiveTypes.H256, BaseOpt<SubstrateNetApi.Model.SpCore.AccountId32>>>
    {
    }
}