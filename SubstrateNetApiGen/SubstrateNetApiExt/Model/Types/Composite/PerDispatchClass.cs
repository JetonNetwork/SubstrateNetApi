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
    /// >> Path: frame_support.weights.PerDispatchClass
    /// </summary>
    public sealed class PerDispatchClass : BaseType
    {
        
        private WeightsPerClass _normal;
        
        private WeightsPerClass _operational;
        
        private WeightsPerClass _mandatory;
        
        public WeightsPerClass Normal
        {
            get
            {
                return this._normal;
            }
            set
            {
                this._normal = value;
            }
        }
        
        public WeightsPerClass Operational
        {
            get
            {
                return this._operational;
            }
            set
            {
                this._operational = value;
            }
        }
        
        public WeightsPerClass Mandatory
        {
            get
            {
                return this._mandatory;
            }
            set
            {
                this._mandatory = value;
            }
        }
        
        public override string TypeName()
        {
            return "PerDispatchClass";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Normal.Encode());
            result.AddRange(Operational.Encode());
            result.AddRange(Mandatory.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Normal = new WeightsPerClass();
            Normal.Decode(byteArray, ref p);
            Operational = new WeightsPerClass();
            Operational.Decode(byteArray, ref p);
            Mandatory = new WeightsPerClass();
            Mandatory.Decode(byteArray, ref p);
            _typeSize = p - start;
        }
    }
}