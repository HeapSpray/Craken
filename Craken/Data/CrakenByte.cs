using System;

namespace Nerey.Craken.Data
{
    public class CrakenByte : CrakenObject
    {
        public CrakenByte(Function _parent, string _name, byte _data)
            : base(_parent, _name, new byte[] { _data }) { }
        public CrakenByte(Script _parent, string _name, byte _data)
            : base(_parent, _name, new byte[] { _data }) { }
        public CrakenByte(Craken _parent, string _name, byte _data)
            : base(_parent, _name, new byte[] { _data }) { }

        public override object Value
        {
            get { return this[0]; }
            set { this[0] = (byte)value; }
        }

        public static CrakenByte operator +(CrakenByte a, CrakenByte b)
        {
            Type ttype = a.parent.GetType();
            byte ba, bb, bc;
            ba = (byte)a.Value; bb = (byte)b.Value;
            bc = (byte)(ba + bb);
            if (ttype == typeof(Craken)) { return new CrakenByte((Craken)a.parent, a.name, bc); }
            else if (ttype == typeof(Script)) { return new CrakenByte((Script)a.parent, a.name, bc); }
            else if (ttype == typeof(Function)) { return new CrakenByte((Function)a.parent, a.name, bc); }
            return null;
        }
        public static CrakenByte operator -(CrakenByte a, CrakenByte b)
        {
            Type ttype = a.parent.GetType();
            byte ba, bb, bc;
            ba = (byte)a.Value; bb = (byte)b.Value;
            bc = (byte)(ba - bb);
            if (ttype == typeof(Craken)) { return new CrakenByte((Craken)a.parent, a.name, bc); }
            else if (ttype == typeof(Script)) { return new CrakenByte((Script)a.parent, a.name, bc); }
            else if (ttype == typeof(Function)) { return new CrakenByte((Function)a.parent, a.name, bc); }
            return null;
        }
        public static CrakenByte operator *(CrakenByte a, CrakenByte b)
        {
            Type ttype = a.parent.GetType();
            byte ba, bb, bc;
            ba = (byte)a.Value; bb = (byte)b.Value;
            bc = (byte)(ba * bb);
            if (ttype == typeof(Craken)) { return new CrakenByte((Craken)a.parent, a.name, bc); }
            else if (ttype == typeof(Script)) { return new CrakenByte((Script)a.parent, a.name, bc); }
            else if (ttype == typeof(Function)) { return new CrakenByte((Function)a.parent, a.name, bc); }
            return null;
        }
        public static CrakenByte operator /(CrakenByte a, CrakenByte b)
        {
            Type ttype = a.parent.GetType();
            byte ba, bb, bc;
            ba = (byte)a.Value; bb = (byte)b.Value;
            bc = (byte)(ba / bb);
            if (ttype == typeof(Craken)) { return new CrakenByte((Craken)a.parent, a.name, bc); }
            else if (ttype == typeof(Script)) { return new CrakenByte((Script)a.parent, a.name, bc); }
            else if (ttype == typeof(Function)) { return new CrakenByte((Function)a.parent, a.name, bc); }
            return null;
        }

        public static bool operator ==(CrakenByte a, CrakenByte b)
        {
            byte numa, numb;
            numa = (byte)a.Value;
            numb = (byte)b.Value;
            return numa == numb;
        }

        public static bool operator !=(CrakenByte a, CrakenByte b)
        {
            byte numa, numb;
            numa = (byte)a.Value;
            numb = (byte)b.Value;
            return numa != numb;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(byte)) { return ((byte)Value) == ((byte)obj); };
            return base.Equals(obj);
        }
        public override int GetHashCode() { return ((byte)Value).GetHashCode(); }
        public override string ToString() { return ((byte)Value).ToString(); }
    }

    public class CrakenChar : CrakenObject
    {
        public CrakenChar(Function _parent, string _name, char _data)
            : base(_parent, _name, DataHelper.CharsToBytes(new char[] { _data })) { }
        public CrakenChar(Script _parent, string _name, char _data)
            : base(_parent, _name, DataHelper.CharsToBytes(new char[] { _data })) { }
        public CrakenChar(Craken _parent, string _name, char _data)
            : base(_parent, _name, DataHelper.CharsToBytes(new char[] { _data })) { }

        public override object Value
        {
            get { return this[0]; }
            set { this[0] = (byte)value; }
        }

        public static bool operator ==(CrakenChar a, CrakenChar b)
        {
            char numa, numb;
            numa = (char)a.Value;
            numb = (char)b.Value;
            return numa == numb;
        }

        public static bool operator !=(CrakenChar a, CrakenChar b)
        {
            char numa, numb;
            numa = (char)a.Value;
            numb = (char)b.Value;
            return numa != numb;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(char)) { return ((char)Value) == ((char)obj); };
            return base.Equals(obj);
        }
        public override int GetHashCode() { return ((char)Value).GetHashCode(); }
        public override string ToString() { return ((char)Value).ToString(); }
    }

    public class CrakenSByte : CrakenObject
    {
        public CrakenSByte(Function _parent, string _name, sbyte _data)
            : base(_parent, _name, new sbyte[] { _data }) { }
        public CrakenSByte(Script _parent, string _name, sbyte _data)
            : base(_parent, _name, new sbyte[] { _data }) { }
        public CrakenSByte(Craken _parent, string _name, sbyte _data)
            : base(_parent, _name, new sbyte[] { _data }) { }

        public override object Value
        {
            get { return this[0]; }
            set { this[0] = (byte)value; }
        }

        public static CrakenSByte operator +(CrakenSByte a, CrakenSByte b)
        {
            Type ttype = a.parent.GetType();
            sbyte ba, bb, bc;
            ba = (sbyte)a.Value; bb = (sbyte)b.Value;
            bc = (sbyte)(ba + bb);
            if (ttype == typeof(Craken)) { return new CrakenSByte((Craken)a.parent, a.name, bc); }
            else if (ttype == typeof(Script)) { return new CrakenSByte((Script)a.parent, a.name, bc); }
            else if (ttype == typeof(Function)) { return new CrakenSByte((Function)a.parent, a.name, bc); }
            return null;
        }
        public static CrakenSByte operator -(CrakenSByte a, CrakenSByte b)
        {
            Type ttype = a.parent.GetType();
            sbyte ba, bb, bc;
            ba = (sbyte)a.Value; bb = (sbyte)b.Value;
            bc = (sbyte)(ba - bb);
            if (ttype == typeof(Craken)) { return new CrakenSByte((Craken)a.parent, a.name, bc); }
            else if (ttype == typeof(Script)) { return new CrakenSByte((Script)a.parent, a.name, bc); }
            else if (ttype == typeof(Function)) { return new CrakenSByte((Function)a.parent, a.name, bc); }
            return null;
        }
        public static CrakenSByte operator *(CrakenSByte a, CrakenSByte b)
        {
            Type ttype = a.parent.GetType();
            sbyte ba, bb, bc;
            ba = (sbyte)a.Value; bb = (sbyte)b.Value;
            bc = (sbyte)(ba * bb);
            if (ttype == typeof(Craken)) { return new CrakenSByte((Craken)a.parent, a.name, bc); }
            else if (ttype == typeof(Script)) { return new CrakenSByte((Script)a.parent, a.name, bc); }
            else if (ttype == typeof(Function)) { return new CrakenSByte((Function)a.parent, a.name, bc); }
            return null;
        }
        public static CrakenSByte operator /(CrakenSByte a, CrakenSByte b)
        {
            Type ttype = a.parent.GetType();
            sbyte ba, bb, bc;
            ba = (sbyte)a.Value; bb = (sbyte)b.Value;
            bc = (sbyte)(ba / bb);
            if (ttype == typeof(Craken)) { return new CrakenSByte((Craken)a.parent, a.name, bc); }
            else if (ttype == typeof(Script)) { return new CrakenSByte((Script)a.parent, a.name, bc); }
            else if (ttype == typeof(Function)) { return new CrakenSByte((Function)a.parent, a.name, bc); }
            return null;
        }

        public static bool operator ==(CrakenSByte a, CrakenSByte b)
        {
            sbyte numa, numb;
            numa = (sbyte)a.Value;
            numb = (sbyte)b.Value;
            return numa == numb;
        }

        public static bool operator !=(CrakenSByte a, CrakenSByte b)
        {
            sbyte numa, numb;
            numa = (sbyte)a.Value;
            numb = (sbyte)b.Value;
            return numa != numb;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(sbyte)) { return ((sbyte)Value) == ((sbyte)obj); };
            return base.Equals(obj);
        }
        public override int GetHashCode() { return ((sbyte)Value).GetHashCode(); }
        public override string ToString() { return ((sbyte)Value).ToString(); }
    }
}