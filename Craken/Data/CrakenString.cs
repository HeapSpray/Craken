using System;

namespace Nerey.Craken.Data
{
    public class CrakenString : CrakenObject
    {
        public CrakenString(Function _parent, string _name, int size)
            : base(_parent, _name, new string(char.MinValue, size)) { }
        public CrakenString(Script _parent, string _name, int size)
            : base(_parent, _name, new string(char.MinValue, size)) { }
        public CrakenString(Craken _parent, string _name, int size)
            : base(_parent, _name, new string(char.MinValue, size)) { }

        public override byte this[int i]
        {
            get { return (byte)(((string)this[false, null]))[i]; }
        }

        public override object Value
        {
            get { return (string)this[false, null]; }
            set { this[false, null] = value; }
        }

        public override string ToString() { return BitConverter.ToString((byte[])this[false, null]); }

        public static CrakenString operator +(CrakenString a, CrakenString b)
        {
            Type ttype = a.parent.GetType();
            string stra, strb, strc;
            stra = (string)a.Value;
            strb = (string)b.Value;
            strc = stra + strb;
            CrakenString result;
            if (ttype == typeof(Craken)) { result = new CrakenString((Craken)a.parent, a.name, strc.Length); }
            else if (ttype == typeof(Script)) { result = new CrakenString((Script)a.parent, a.name, strc.Length); }
            else if (ttype == typeof(Function)) { result = new CrakenString((Function)a.parent, a.name, strc.Length); }
            else { return null; }
            result[false, null] = strc;
            return result;
        }

        public static CrakenString operator +(CrakenString a, CrakenChar b)
        {
            Type ttype = a.parent.GetType();
            string stra, strc; char strb;
            stra = (string)a.Value;
            strb = (char)b.Value;
            strc = stra + strb;
            CrakenString result;
            if (ttype == typeof(Craken)) { result = new CrakenString((Craken)a.parent, a.name, strc.Length); }
            else if (ttype == typeof(Script)) { result = new CrakenString((Script)a.parent, a.name, strc.Length); }
            else if (ttype == typeof(Function)) { result = new CrakenString((Function)a.parent, a.name, strc.Length); }
            else { return null; }
            result[false, null] = strc;
            return result;
        }

        public static bool operator ==(CrakenString a, CrakenString b)
        {
            string stra, strb;
            stra = (string)a.Value;
            strb = (string)b.Value;
            return stra == strb;
        }

        public static bool operator !=(CrakenString a, CrakenString b)
        {
            string stra, strb;
            stra = (string)a.Value;
            strb = (string)b.Value;
            return stra != strb;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(string)) { return ((string)Value) == ((string)obj); };
            return base.Equals(obj);
        }
        public override int GetHashCode() { return ((string)Value).GetHashCode(); }
    }
}