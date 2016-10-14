﻿//Apache2, 2014-2016, Samuel Carlsson, WinterDev

using System; 
using System.Text;
namespace NRasterizer.Tables
{
    struct TableHeader
    {
        readonly uint _tag;
        readonly uint _checkSum;
        readonly uint _offset;
        readonly uint _length;

        public TableHeader(uint tag, uint checkSum, uint offset, uint len)
        {
            _tag = tag;
            _checkSum = checkSum;
            _offset = offset;
            _length = len;
        }
        public string Tag { get { return TagToString(_tag); } }

        //// TODO: Take offset parameter as commonly two seeks are made in a row
        //public BinaryReader GetDataReader()
        //{
        //    _input.BaseStream.Seek(_offset, SeekOrigin.Begin);
        //    // TODO: Limit reading to _length by wrapping BinaryReader (or Stream)?
        //    return _input;
        //}
        public uint Offset { get { return _offset; } }
        public uint CheckSum { get { return _checkSum; } }
        public uint Length { get { return _length; } }
        static String TagToString(uint tag)
        {
            byte[] bytes = BitConverter.GetBytes(tag);
            Array.Reverse(bytes);
            return Encoding.ASCII.GetString(bytes);
        }

        public override string ToString()
        {
            return "{" + Tag + "}";
        }

      
    }
}
