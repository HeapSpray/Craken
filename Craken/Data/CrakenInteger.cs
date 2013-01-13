using System;

namespace Nerey.Craken.Data
{
    public class CrakenInt32 : CrakenObject
    {
        public CrakenInt32(Function _parent, string _name, Int32 _data)
            : base(_parent, _name, BitConverter.GetBytes(_data)) { }
        public CrakenInt32(Script _parent, string _name, Int32 _data)
            : base(_parent, _name, BitConverter.GetBytes(_data)) { }
        public CrakenInt32(Craken _parent, string _name, Int32 _data)
            : base(_parent, _name, BitConverter.GetBytes(_data)) { }

        public override object Value
        {
            get { return BitConverter.ToInt32((byte[])this[false, null], 0); }
            set { this[false, null] = BitConverter.GetBytes((Int32)value); }
        }

        public static explicit operator int(CrakenInt32 a) { return (int)a.Value; }
        public static explicit operator short(CrakenInt32 a) { return (short)a.Value; }
        public static explicit operator byte(CrakenInt32 a) { return (byte)a.Value; }
        public static explicit operator uint(CrakenInt32 a) { return (uint)a.Value; }
        public static explicit operator ushort(CrakenInt32 a) { return (ushort)a.Value; }
        public static explicit operator sbyte(CrakenInt32 a) { return (sbyte)a.Value; }

        public static explicit operator CrakenInt32(CrakenInt16 a) 
        {
            Type ttype = a.parent.GetType();
            if (ttype == typeof(Craken)) { return new CrakenInt32((Craken)a.parent, a.name, (int)a.Value); }
            else if (ttype == typeof(Script)) { return new CrakenInt32((Script)a.parent, a.name, (int)a.Value); }
            else if (ttype == typeof(Function)) { return new CrakenInt32((Function)a.parent, a.name, (int)a.Value); }
            return null;
        }
        public static explicit operator CrakenInt32(CrakenByte a)
        {
            Type ttype = a.parent.GetType();
            if (ttype == typeof(Craken)) { return new CrakenInt32((Craken)a.parent, a.name, (int)a.Value); }
            else if (ttype == typeof(Script)) { return new CrakenInt32((Script)a.parent, a.name, (int)a.Value); }
            else if (ttype == typeof(Function)) { return new CrakenInt32((Function)a.parent, a.name, (int)a.Value); }
            return null;
        }
        public static explicit operator CrakenInt32(CrakenUInt32 a)
        {
            Type ttype = a.parent.GetType();
            if (ttype == typeof(Craken)) { return new CrakenInt32((Craken)a.parent, a.name, (int)a.Value); }
            else if (ttype == typeof(Script)) { return new CrakenInt32((Script)a.parent, a.name, (int)a.Value); }
            else if (ttype == typeof(Function)) { return new CrakenInt32((Function)a.parent, a.name, (int)a.Value); }
            return null;
        }
        public static explicit operator CrakenInt32(CrakenUInt16 a)
        {
            Type ttype = a.parent.GetType();
            if (ttype == typeof(Craken)) { return new CrakenInt32((Craken)a.parent, a.name, (int)a.Value); }
            else if (ttype == typeof(Script)) { return new CrakenInt32((Script)a.parent, a.name, (int)a.Value); }
            else if (ttype == typeof(Function)) { return new CrakenInt32((Function)a.parent, a.name, (int)a.Value); }
            return null;
        }
        public static CrakenInt32 operator +(CrakenInt32 a, CrakenInt32 b)
        {
            Type ttype = a.parent.GetType();
            int numa, numb, numc;
            numa = (int)a.Value;
            numb = (int)b.Value;
            CrakenInt32 result; numc = numa + numb;
            if (ttype == typeof(Craken)) { result = new CrakenInt32((Craken)a.parent, a.name, numc); }
            else if (ttype == typeof(Script)) { result = new CrakenInt32((Script)a.parent, a.name, numc); }
            else if (ttype == typeof(Function)) { result = new CrakenInt32((Function)a.parent, a.name, numc); }
            else { return null; }
            return result;
        }
        public static CrakenInt32 operator -(CrakenInt32 a, CrakenInt32 b)
        {
            Type ttype = a.parent.GetType();
            int numa, numb, numc;
            numa = (int)a.Value;
            numb = (int)b.Value;
            CrakenInt32 result; numc = numa - numb;
            if (ttype == typeof(Craken)) { result = new CrakenInt32((Craken)a.parent, a.name, numc); }
            else if (ttype == typeof(Script)) { result = new CrakenInt32((Script)a.parent, a.name, numc); }
            else if (ttype == typeof(Function)) { result = new CrakenInt32((Function)a.parent, a.name, numc); }
            else { return null; }
            return result;
        }
        public static CrakenInt32 operator *(CrakenInt32 a, CrakenInt32 b)
        {
            Type ttype = a.parent.GetType();
            int numa, numb, numc;
            numa = (int)a.Value;
            numb = (int)b.Value;
            CrakenInt32 result; numc = numa * numb;
            if (ttype == typeof(Craken)) { result = new CrakenInt32((Craken)a.parent, a.name, numc); }
            else if (ttype == typeof(Script)) { result = new CrakenInt32((Script)a.parent, a.name, numc); }
            else if (ttype == typeof(Function)) { result = new CrakenInt32((Function)a.parent, a.name, numc); }
            else { return null; }
            return result;
        }
        public static CrakenInt32 operator /(CrakenInt32 a, CrakenInt32 b)
        {
            Type ttype = a.parent.GetType();
            int numa, numb, numc;
            numa = (int)a.Value;
            numb = (int)b.Value;
            CrakenInt32 result; numc = numa / numb;
            if (ttype == typeof(Craken)) { result = new CrakenInt32((Craken)a.parent, a.name, numc); }
            else if (ttype == typeof(Script)) { result = new CrakenInt32((Script)a.parent, a.name, numc); }
            else if (ttype == typeof(Function)) { result = new CrakenInt32((Function)a.parent, a.name, numc); }
            else { return null; }
            return result;
        }

        public static bool operator ==(CrakenInt32 a, CrakenInt32 b)
        {
            int numa, numb;
            numa = (int)a.Value;
            numb = (int)b.Value;
            return numa == numb;
        }

        public static bool operator !=(CrakenInt32 a, CrakenInt32 b)
        {
            int numa, numb;
            numa = (int)a.Value;
            numb = (int)b.Value;
            return numa != numb;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(int)) { return ((int)Value) == ((int)obj); };
            return base.Equals(obj);
        }
        public override int GetHashCode() { return ((int)Value).GetHashCode(); }
        public override string ToString() { return ((int)Value).ToString(); }
    }

    public class CrakenInt16 : CrakenObject
    {
        public CrakenInt16(Function _parent, string _name, int _data)
            : base(_parent, _name, BitConverter.GetBytes(_data)) { }
        public CrakenInt16(Script _parent, string _name, int _data)
            : base(_parent, _name, BitConverter.GetBytes(_data)) { }
        public CrakenInt16(Craken _parent, string _name, int _data)
            : base(_parent, _name, BitConverter.GetBytes(_data)) { }

        public override object Value
        {
            get { return BitConverter.ToInt16((byte[])this[false, null], 0); }
            set { this[false, null] = BitConverter.GetBytes((Int16)value); }
        }

        public static explicit operator int(CrakenInt16 a) { return (int)a.Value; }
        public static explicit operator short(CrakenInt16 a) { return (short)a.Value; }
        public static explicit operator byte(CrakenInt16 a) { return (byte)a.Value; }
        public static explicit operator uint(CrakenInt16 a) { return (uint)a.Value; }
        public static explicit operator ushort(CrakenInt16 a) { return (ushort)a.Value; }
        public static explicit operator sbyte(CrakenInt16 a) { return (sbyte)a.Value; }

        public static explicit operator CrakenInt16(CrakenInt32 a)
        {
            Type ttype = a.parent.GetType();
            if (ttype == typeof(Craken)) { return new CrakenInt16((Craken)a.parent, a.name, (short)a.Value); }
            else if (ttype == typeof(Script)) { return new CrakenInt16((Script)a.parent, a.name, (short)a.Value); }
            else if (ttype == typeof(Function)) { return new CrakenInt16((Function)a.parent, a.name, (short)a.Value); }
            return null;
        }
        public static explicit operator CrakenInt16(CrakenByte a)
        {
            Type ttype = a.parent.GetType();
            if (ttype == typeof(Craken)) { return new CrakenInt16((Craken)a.parent, a.name, (short)a.Value); }
            else if (ttype == typeof(Script)) { return new CrakenInt16((Script)a.parent, a.name, (short)a.Value); }
            else if (ttype == typeof(Function)) { return new CrakenInt16((Function)a.parent, a.name, (short)a.Value); }
            return null;
        }
        public static explicit operator CrakenInt16(CrakenUInt32 a)
        {
            Type ttype = a.parent.GetType();
            if (ttype == typeof(Craken)) { return new CrakenInt16((Craken)a.parent, a.name, (short)a.Value); }
            else if (ttype == typeof(Script)) { return new CrakenInt16((Script)a.parent, a.name, (short)a.Value); }
            else if (ttype == typeof(Function)) { return new CrakenInt16((Function)a.parent, a.name, (short)a.Value); }
            return null;
        }
        public static explicit operator CrakenInt16(CrakenUInt16 a)
        {
            Type ttype = a.parent.GetType();
            if (ttype == typeof(Craken)) { return new CrakenInt16((Craken)a.parent, a.name, (short)a.Value); }
            else if (ttype == typeof(Script)) { return new CrakenInt16((Script)a.parent, a.name, (short)a.Value); }
            else if (ttype == typeof(Function)) { return new CrakenInt16((Function)a.parent, a.name, (short)a.Value); }
            return null;
        }
        public static CrakenInt16 operator +(CrakenInt16 a, CrakenInt16 b)
        {
            Type ttype = a.parent.GetType();
            short numa, numb, numc;
            numa = (short)a.Value;
            numb = (short)b.Value;
            CrakenInt16 result; numc = (short)(numa + numb);
            if (ttype == typeof(Craken)) { result = new CrakenInt16((Craken)a.parent, a.name, numc); }
            else if (ttype == typeof(Script)) { result = new CrakenInt16((Script)a.parent, a.name, numc); }
            else if (ttype == typeof(Function)) { result = new CrakenInt16((Function)a.parent, a.name, numc); }
            else { return null; }
            
            return result;
        }
        public static CrakenInt16 operator -(CrakenInt16 a, CrakenInt16 b)
        {
            Type ttype = a.parent.GetType();
            short numa, numb, numc;
            numa = (short)a.Value;
            numb = (short)b.Value;
            CrakenInt16 result; numc = (short)(numa - numb);
            if (ttype == typeof(Craken)) { result = new CrakenInt16((Craken)a.parent, a.name, numc); }
            else if (ttype == typeof(Script)) { result = new CrakenInt16((Script)a.parent, a.name, numc); }
            else if (ttype == typeof(Function)) { result = new CrakenInt16((Function)a.parent, a.name, numc); }
            else { return null; }
            
            return result;
        }
        public static CrakenInt16 operator *(CrakenInt16 a, CrakenInt16 b)
        {
            Type ttype = a.parent.GetType();
            short numa, numb, numc;
            numa = (short)a.Value;
            numb = (short)b.Value;
            CrakenInt16 result; numc = (short)(numa * numb);
            if (ttype == typeof(Craken)) { result = new CrakenInt16((Craken)a.parent, a.name, numc); }
            else if (ttype == typeof(Script)) { result = new CrakenInt16((Script)a.parent, a.name, numc); }
            else if (ttype == typeof(Function)) { result = new CrakenInt16((Function)a.parent, a.name, numc); }
            else { return null; }
            
            return result;
        }
        public static CrakenInt16 operator /(CrakenInt16 a, CrakenInt16 b)
        {
            Type ttype = a.parent.GetType();
            short numa, numb, numc;
            numa = (short)a.Value;
            numb = (short)b.Value;
            CrakenInt16 result; numc = (short)(numa / numb);
            if (ttype == typeof(Craken)) { result = new CrakenInt16((Craken)a.parent, a.name, numc); }
            else if (ttype == typeof(Script)) { result = new CrakenInt16((Script)a.parent, a.name, numc); }
            else if (ttype == typeof(Function)) { result = new CrakenInt16((Function)a.parent, a.name, numc); }
            else { return null; }
            
            return result;
        }

        public static bool operator ==(CrakenInt16 a, CrakenInt16 b)
        {
            short numa, numb;
            numa = (short)a.Value;
            numb = (short)b.Value;
            return numa == numb;
        }

        public static bool operator !=(CrakenInt16 a, CrakenInt16 b)
        {
            short numa, numb;
            numa = (short)a.Value;
            numb = (short)b.Value;
            return numa != numb;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(short)) { return ((short)Value) == ((short)obj); };
            return base.Equals(obj);
        }
        public override int GetHashCode() { return ((short)Value).GetHashCode(); }
        public override string ToString() { return ((short)Value).ToString(); }
    }

    public class CrakenUInt32 : CrakenObject
    {
        public CrakenUInt32(Function _parent, string _name, UInt32 _data)
            : base(_parent, _name, BitConverter.GetBytes(_data)) { }
        public CrakenUInt32(Script _parent, string _name, UInt32 _data)
            : base(_parent, _name, BitConverter.GetBytes(_data)) { }
        public CrakenUInt32(Craken _parent, string _name, UInt32 _data)
            : base(_parent, _name, BitConverter.GetBytes(_data)) { }

        public override object Value
        {
            get { return BitConverter.ToUInt32((byte[])this[false, null], 0); }
            set { this[false, null] = BitConverter.GetBytes((UInt32)value); }
        }

        public static CrakenUInt32 operator +(CrakenUInt32 a, CrakenUInt32 b)
        {
            Type ttype = a.parent.GetType();
            uint numa, numb, numc;
            numa = (uint)a.Value;
            numb = (uint)b.Value;
            CrakenUInt32 result; numc = numa + numb;
            if (ttype == typeof(Craken)) { result = new CrakenUInt32((Craken)a.parent, a.name, numc); }
            else if (ttype == typeof(Script)) { result = new CrakenUInt32((Script)a.parent, a.name, numc); }
            else if (ttype == typeof(Function)) { result = new CrakenUInt32((Function)a.parent, a.name, numc); }
            else { return null; }
            
            return result;
        }

        public static CrakenUInt32 operator -(CrakenUInt32 a, CrakenUInt32 b)
        {
            Type ttype = a.parent.GetType();
            uint numa, numb, numc;
            numa = (uint)a.Value;
            numb = (uint)b.Value;
            CrakenUInt32 result; numc = numa - numb;
            if (ttype == typeof(Craken)) { result = new CrakenUInt32((Craken)a.parent, a.name, numc); }
            else if (ttype == typeof(Script)) { result = new CrakenUInt32((Script)a.parent, a.name, numc); }
            else if (ttype == typeof(Function)) { result = new CrakenUInt32((Function)a.parent, a.name, numc); }
            else { return null; }
            
            return result;
        }
        public static CrakenUInt32 operator *(CrakenUInt32 a, CrakenUInt32 b)
        {
            Type ttype = a.parent.GetType();
            uint numa, numb, numc;
            numa = (uint)a.Value;
            numb = (uint)b.Value;
            CrakenUInt32 result; numc = numa * numb;
            if (ttype == typeof(Craken)) { result = new CrakenUInt32((Craken)a.parent, a.name, numc); }
            else if (ttype == typeof(Script)) { result = new CrakenUInt32((Script)a.parent, a.name, numc); }
            else if (ttype == typeof(Function)) { result = new CrakenUInt32((Function)a.parent, a.name, numc); }
            else { return null; }

            return result;
        }

        public static CrakenUInt32 operator /(CrakenUInt32 a, CrakenUInt32 b)
        {
            Type ttype = a.parent.GetType();
            uint numa, numb, numc;
            numa = (uint)a.Value;
            numb = (uint)b.Value;
            CrakenUInt32 result; numc = numa / numb;
            if (ttype == typeof(Craken)) { result = new CrakenUInt32((Craken)a.parent, a.name, numc); }
            else if (ttype == typeof(Script)) { result = new CrakenUInt32((Script)a.parent, a.name, numc); }
            else if (ttype == typeof(Function)) { result = new CrakenUInt32((Function)a.parent, a.name, numc); }
            else { return null; }

            return result;
        }

        public static bool operator ==(CrakenUInt32 a, CrakenUInt32 b)
        {
            uint numa, numb;
            numa = (uint)a.Value;
            numb = (uint)b.Value;
            return numa == numb;
        }

        public static bool operator !=(CrakenUInt32 a, CrakenUInt32 b)
        {
            uint numa, numb;
            numa = (uint)a.Value;
            numb = (uint)b.Value;
            return numa != numb;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(uint)) { return ((uint)Value) == ((uint)obj); };
            return base.Equals(obj);
        }
        public override int GetHashCode() { return ((uint)Value).GetHashCode(); }
        public override string ToString() { return ((uint)Value).ToString(); }
    }

    public class CrakenUInt16 : CrakenObject
    {
        public CrakenUInt16(Function _parent, string _name, UInt16 _data)
            : base(_parent, _name, BitConverter.GetBytes(_data)) { }
        public CrakenUInt16(Script _parent, string _name, UInt16 _data)
            : base(_parent, _name, BitConverter.GetBytes(_data)) { }
        public CrakenUInt16(Craken _parent, string _name, UInt16 _data)
            : base(_parent, _name, BitConverter.GetBytes(_data)) { }

        public override object Value
        {
            get { return BitConverter.ToUInt16((byte[])this[false, null], 0); }
            set { this[false, null] = BitConverter.GetBytes((UInt16)value); }
        }

        public static CrakenUInt16 operator +(CrakenUInt16 a, CrakenUInt16 b)
        {
            Type ttype = a.parent.GetType();
            ushort numa, numb, numc;
            numa = (ushort)a.Value;
            numb = (ushort)b.Value;
            CrakenUInt16 result; numc = (ushort)(numa + numb);
            if (ttype == typeof(Craken)) { result = new CrakenUInt16((Craken)a.parent, a.name, numc); }
            else if (ttype == typeof(Script)) { result = new CrakenUInt16((Script)a.parent, a.name, numc); }
            else if (ttype == typeof(Function)) { result = new CrakenUInt16((Function)a.parent, a.name, numc); }
            else { return null; }
            
            return result;
        }
        public static CrakenUInt16 operator -(CrakenUInt16 a, CrakenUInt16 b)
        {
            Type ttype = a.parent.GetType();
            ushort numa, numb, numc;
            numa = (ushort)a.Value;
            numb = (ushort)b.Value;
            CrakenUInt16 result; numc = (ushort)(numa - numb);
            if (ttype == typeof(Craken)) { result = new CrakenUInt16((Craken)a.parent, a.name, numc); }
            else if (ttype == typeof(Script)) { result = new CrakenUInt16((Script)a.parent, a.name, numc); }
            else if (ttype == typeof(Function)) { result = new CrakenUInt16((Function)a.parent, a.name, numc); }
            else { return null; }
            
            return result;
        }

        public static CrakenUInt16 operator *(CrakenUInt16 a, CrakenUInt16 b)
        {
            Type ttype = a.parent.GetType();
            ushort numa, numb, numc;
            numa = (ushort)a.Value;
            numb = (ushort)b.Value;
            CrakenUInt16 result; numc = (ushort)(numa * numb);
            if (ttype == typeof(Craken)) { result = new CrakenUInt16((Craken)a.parent, a.name, numc); }
            else if (ttype == typeof(Script)) { result = new CrakenUInt16((Script)a.parent, a.name, numc); }
            else if (ttype == typeof(Function)) { result = new CrakenUInt16((Function)a.parent, a.name, numc); }
            else { return null; }

            return result;
        }
        public static CrakenUInt16 operator /(CrakenUInt16 a, CrakenUInt16 b)
        {
            Type ttype = a.parent.GetType();
            ushort numa, numb, numc;
            numa = (ushort)a.Value;
            numb = (ushort)b.Value;
            CrakenUInt16 result; numc = (ushort)(numa / numb);
            if (ttype == typeof(Craken)) { result = new CrakenUInt16((Craken)a.parent, a.name, numc); }
            else if (ttype == typeof(Script)) { result = new CrakenUInt16((Script)a.parent, a.name, numc); }
            else if (ttype == typeof(Function)) { result = new CrakenUInt16((Function)a.parent, a.name, numc); }
            else { return null; }

            return result;
        }

        public static bool operator ==(CrakenUInt16 a, CrakenUInt16 b)
        {
            ushort numa, numb;
            numa = (ushort)a.Value;
            numb = (ushort)b.Value;
            return numa == numb;
        }

        public static bool operator !=(CrakenUInt16 a, CrakenUInt16 b)
        {
            ushort numa, numb;
            numa = (ushort)a.Value;
            numb = (ushort)b.Value;
            return numa != numb;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(ushort)) { return ((ushort)Value) == ((ushort)obj); };
            return base.Equals(obj);
        }
        public override int GetHashCode() { return ((ushort)Value).GetHashCode(); }
        public override string ToString() { return ((ushort)Value).ToString(); }
    }
}