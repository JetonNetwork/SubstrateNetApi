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


namespace SubstrateNetApi.Model.Types.Composite
{
    
    
    /// <summary>
    /// >> Path: pallet_democracy.types.Delegations
    /// </summary>
    public sealed class Delegations : BaseType
    {
        
        private U128 _votes;
        
        private U128 _capital;
        
        public U128 Votes
        {
            get
            {
                return this._votes;
            }
            set
            {
                this._votes = value;
            }
        }
        
        public U128 Capital
        {
            get
            {
                return this._capital;
            }
            set
            {
                this._capital = value;
            }
        }
        
        public override string TypeName()
        {
            return "Delegations";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Votes.Encode());
            result.AddRange(Capital.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Votes = new U128();
            Votes.Decode(byteArray, ref p);
            Capital = new U128();
            Capital.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}