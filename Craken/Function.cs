using System;

using Nerey.Craken.Data;
namespace Nerey.Craken
{
    public class FunctionArgument
    {
        // can set only inside our class
        public string name { get; private set; }    // arg name
        public Type type { get; private set; }      // arg native data type

        public FunctionArgument(string _name, Type _type)
        {
            name = _name;
            type = _type;
        }
    }

    public class Function
    {
        // can set only inside our class
        public string name { get; private set; }    // function's name, what else?
        public object parent { get; private set; }  // parent.. the vm.base or object ?
        public bool iprivate { get; private set; }  // private for dis script / object ?
        public bool ivirtual { get; private set; }  // virtual is NOT an imported native C# function
        public Type returns { get; private set; }   // type of data function returns
        public FunctionArgument[] args { get; private set; }    // arguments we pass to da function
        Opcode[] opcodes;

        // many variants of what parent should be.. seriously? a rape. 
        public Function(Script _parent, Opcode[] _opcodes, string _name, FunctionArgument[] _args, Type _returns)
        {
            parent = _parent;
            iprivate = true;
            ivirtual = true;
            name = _name;
            args = _args;
            returns = _returns;
            opcodes = _opcodes;
        }

        public Function(Craken _parent, Opcode[] _opcodes, string _name, FunctionArgument[] _args, Type _returns)
        {
            parent = _parent;
            iprivate = false;
            ivirtual = true;
            name = _name;
            args = _args;
            returns = _returns;
            opcodes = _opcodes;
        }

        // aaaand here goes the execution of opcodes :3s
        public object Invoke(params object[] args)
        {
            Craken craken = null; object result = null;
            if (iprivate) { craken = ((Script)parent).vm; } else { craken = (Craken)parent; }; // get vm :o
            StringHelper strh = craken.StrHelp;
            Opcode op; string path = "";
            // temporary variables...
            byte btemp; short stemp; int itemp; long ltemp; double dtemp; float ftemp;
            bool bltemp; object otemp; sbyte sbtemp;
            ushort ustemp; uint uitemp;
            byte[] src, trg; string tsrc, ttrg;
            CrakenInt32 i32; CrakenInt16 i16; CrakenUInt32 ui32; CrakenUInt16 ui16;
            CrakenByte b8; CrakenBool bl8; CrakenChar c8; CrakenString str8; CrakenSByte sb8; 

            for (int i = 0; i < opcodes.Length; i++)
            {
                op = opcodes[i]; path = BitConverter.ToString(op.data);         // get string from byte array in op's data
                int s = 0, lim = 0, s2 = 0;                                     // temporary variables
                while (op.data[i] != 0) { s++; }; lim = s; s = 0;               // find a 0 byte wich splits 2 strings in one array
                src = new byte[lim]; trg = new byte[op.data.Length - lim];      // make arrays to split
                for (s = 0; s < lim; s++) { src[s] = op.data[s]; };             // split those
                for (s = lim; s < op.data.Length; s++) { trg[s2] = op.data[s]; s2++; }; // split those[2]
                tsrc = BitConverter.ToString(src); ttrg = BitConverter.ToString(trg);   // get strings :3
                switch (op.op)
                {
                    case 0: break;  // Sleep ^_^
                    case 1:         // push
                        switch (op.prefix)
                        {
                            case OpPrefix.int32 | OpPrefix.int16 | OpPrefix.int8 | OpPrefix.boolean | OpPrefix.obj:
                                craken.stack.Push(craken[path].Value);
                                break;
                            case OpPrefix.reference | OpPrefix.str | OpPrefix.chr:
                                craken.stack.Push(path);
                                break;
                        };
                        break;
                    case 2:         // pop
                        craken[path].Value = craken.stack.Pop();
                        break;
                    case 3:         // inc
                        switch (op.prefix)
                        {
                            case OpPrefix.int8: sbtemp = (sbyte)craken[path].Value; sbtemp++; craken[path].Value = sbtemp; break;
                            case OpPrefix.uint8: btemp = (byte)craken[path].Value; btemp++; craken[path].Value = btemp; break;
                            case OpPrefix.int16: stemp = (short)craken[path].Value; stemp++; craken[path].Value = stemp; break;
                            case OpPrefix.uint16: ustemp = (ushort)craken[path].Value; ustemp++; craken[path].Value = ustemp; break;
                            case OpPrefix.int32: itemp = (int)craken[path].Value; itemp++; craken[path].Value = itemp; break;
                            case OpPrefix.uint32: uitemp = (uint)craken[path].Value; uitemp++; craken[path].Value = uitemp; break;
                            case OpPrefix.boolean: craken[path].Value = true; break;
                        };
                        break;
                    case 4:         // dec
                        switch (op.prefix)
                        {
                            case OpPrefix.int8: sbtemp = (sbyte)craken[path].Value; sbtemp--; craken[path].Value = sbtemp; break;
                            case OpPrefix.uint8: btemp = (byte)craken[path].Value; btemp--; craken[path].Value = btemp; break;
                            case OpPrefix.int16: stemp = (short)craken[path].Value; stemp--; craken[path].Value = stemp; break;
                            case OpPrefix.uint16: ustemp = (ushort)craken[path].Value; ustemp--; craken[path].Value = ustemp; break;
                            case OpPrefix.int32: itemp = (int)craken[path].Value; itemp--; craken[path].Value = itemp; break;
                            case OpPrefix.uint32: uitemp = (uint)craken[path].Value; uitemp--; craken[path].Value = uitemp; break;
                            case OpPrefix.boolean: craken[path].Value = true; break;
                        };
                        break;
                    case 5:         // mov [data]
                        if (op.prefix == OpPrefix.reference) { craken[ttrg].Value = tsrc; }
                        else { craken[ttrg].Value = craken[tsrc].Value; }
                        break;
                    case 7:         // add [data]
                        switch (op.prefix)
                        {
                            case OpPrefix.int32:
                                i32 = (CrakenInt32)craken[ttrg]; i32 += (CrakenInt32)craken[tsrc]; break;
                            case OpPrefix.int16:
                                i16 = (CrakenInt16)craken[ttrg]; i16 += (CrakenInt16)craken[tsrc]; break;
                            case OpPrefix.uint32:
                                ui32 = (CrakenUInt32)craken[ttrg]; ui32 += (CrakenUInt32)craken[tsrc]; break;
                            case OpPrefix.uint16:
                                ui16 = (CrakenUInt16)craken[ttrg]; ui16 += (CrakenUInt16)craken[tsrc];  break;
                            case OpPrefix.int8:
                                sb8 = (CrakenSByte)craken[ttrg]; sb8 += (CrakenSByte)craken[tsrc]; break;
                            case OpPrefix.uint8:
                                b8 = (CrakenByte)craken[ttrg]; b8 += (CrakenByte)craken[tsrc]; break;
                            case OpPrefix.str:
                                str8 = (CrakenString)craken[ttrg]; str8 += (CrakenString)craken[tsrc]; break;
                        };
                        break;
                };
            };


            return result;
        }
    }
}