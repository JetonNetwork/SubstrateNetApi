//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SubstrateNetApi.Model.SpCore;
using SubstrateNetApi.Model.Types.Base;
using SubstrateNetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;


namespace SubstrateNetApi.Model.PalletBagsList
{
    
    
    /// <summary>
    /// >> 504 - Composite[pallet_bags_list.list.Node]
    /// </summary>
    public sealed class Node : BaseType
    {
        
        /// <summary>
        /// >> id
        /// </summary>
        private SubstrateNetApi.Model.SpCore.AccountId32 _id;
        
        /// <summary>
        /// >> prev
        /// </summary>
        private BaseOpt<SubstrateNetApi.Model.SpCore.AccountId32> _prev;
        
        /// <summary>
        /// >> next
        /// </summary>
        private BaseOpt<SubstrateNetApi.Model.SpCore.AccountId32> _next;
        
        /// <summary>
        /// >> bag_upper
        /// </summary>
        private SubstrateNetApi.Model.Types.Primitive.U64 _bagUpper;
        
        public SubstrateNetApi.Model.SpCore.AccountId32 Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
        
        public BaseOpt<SubstrateNetApi.Model.SpCore.AccountId32> Prev
        {
            get
            {
                return this._prev;
            }
            set
            {
                this._prev = value;
            }
        }
        
        public BaseOpt<SubstrateNetApi.Model.SpCore.AccountId32> Next
        {
            get
            {
                return this._next;
            }
            set
            {
                this._next = value;
            }
        }
        
        public SubstrateNetApi.Model.Types.Primitive.U64 BagUpper
        {
            get
            {
                return this._bagUpper;
            }
            set
            {
                this._bagUpper = value;
            }
        }
        
        public override string TypeName()
        {
            return "Node";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Id.Encode());
            result.AddRange(Prev.Encode());
            result.AddRange(Next.Encode());
            result.AddRange(BagUpper.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Id = new SubstrateNetApi.Model.SpCore.AccountId32();
            Id.Decode(byteArray, ref p);
            Prev = new BaseOpt<SubstrateNetApi.Model.SpCore.AccountId32>();
            Prev.Decode(byteArray, ref p);
            Next = new BaseOpt<SubstrateNetApi.Model.SpCore.AccountId32>();
            Next.Decode(byteArray, ref p);
            BagUpper = new SubstrateNetApi.Model.Types.Primitive.U64();
            BagUpper.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}