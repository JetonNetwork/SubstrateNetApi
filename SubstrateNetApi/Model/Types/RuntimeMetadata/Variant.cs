﻿using SubstrateNetApi.Model.Types.Base;
using SubstrateNetApi.Model.Types.Struct;
using System;

namespace SubstrateNetApi.Model.Types.Metadata.V14
{
    public class Variant : StructType
    {
        public override string Name() => "Variant<T: Form = MetaForm>";

        private int _size;
        public override int Size() => _size;

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            VariantName = new BaseString();
            VariantName.Decode(byteArray, ref p);

            VariantFields = new Vec<Field>();
            VariantFields.Decode(byteArray, ref p);

            Index = new U8();
            Index.Decode(byteArray, ref p);

            Docs = new Vec<BaseString>();
            Docs.Decode(byteArray, ref p);

            _size = p - start;
        }
        public BaseString VariantName { get; private set; }
        public Vec<Field> VariantFields { get; private set; }
        public U8 Index { get; private set; }
        public Vec<BaseString> Docs { get; private set; }
    }

}