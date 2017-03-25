﻿using System.Text;

namespace NemApi
{
    internal class MosaicProperty
    {
        private readonly Serializer Serializer = new Serializer();

        internal MosaicProperty(string propertyName, string propertyValue)
        {
            PropertyNameLength = Encoding.Default.GetBytes(propertyName).Length;
            PropertyValueLength = Encoding.Default.GetBytes(propertyValue).Length;
            PropertyLength += ByteLength.EightBytes + PropertyNameLength + PropertyValueLength;

            Serializer.WriteInt(PropertyLength);
            Serializer.WriteInt(PropertyNameLength);
            Serializer.WriteString(propertyName);
            Serializer.WriteInt(PropertyValueLength);
            Serializer.WriteString(propertyValue);

            PropertyBytes = ByteUtils.TruncateByteArray(Serializer.GetBytes(), PropertyLength + 4);
        }

        internal int PropertyLength { get; set; }
        private int PropertyNameLength { get; }
        private int PropertyValueLength { get; }
        private byte[] PropertyBytes { get; }

        internal byte[] GetBytes()
        {
            return PropertyBytes;
        }
    }
}