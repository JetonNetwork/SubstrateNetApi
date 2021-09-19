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


namespace SubstrateNetApi.Model.Types.Composite
{
    
    
    /// <summary>
    /// >> Path: sp_npos_elections.Support
    /// </summary>
    public sealed class Support : BaseType
    {
        
        private U128 _total;
        
        private BaseVec<BaseTuple<AccountId32,U128>> _voters;
        
        public U128 Total
        {
            get
            {
                return this._total;
            }
            set
            {
                this._total = value;
            }
        }
        
        public BaseVec<BaseTuple<AccountId32,U128>> Voters
        {
            get
            {
                return this._voters;
            }
            set
            {
                this._voters = value;
            }
        }
        
        public override string TypeName()
        {
            return "Support";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Total.Encode());
            result.AddRange(Voters.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Total = new U128();
            Total.Decode(byteArray, ref p);
            Voters = new BaseVec<BaseTuple<AccountId32,U128>>();
            Voters.Decode(byteArray, ref p);
            _typeSize = p - start;
        }
    }
}