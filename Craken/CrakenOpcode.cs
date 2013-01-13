using System;

namespace Nerey.Craken
{
    // source type of data we operate with, lol
    public enum OpPrefix : byte
    {
        int32 = 1,
        int16 = 2,
        int8 = 3,
        uint32 = 4,
        uint16 = 5,
        uint8 = 6,
        str = 7, obj = 8,
        reference = 9, chr = 10,
        boolean = 11
    };

    public class Opcode
    {
        // can set only inside our class
        public byte op { get; private set; }            // opcode itself
        public OpPrefix prefix { get; private set; }    // datatype prefix
        public byte[] data { get; private set; }        // da arguments \o/

        public Opcode(byte _op, OpPrefix _prfx, byte[] _data)
        {
            op = _op;
            prefix = _prfx;
            data = _data;
        }

        // set / get data of args.. 
        public byte this[int i]
        {
            get { return data[i]; }
            private set { data[i] = value; } // can set only inside our class
        }
    }
}