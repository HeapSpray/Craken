using System;

namespace Nerey.Craken.Data
{
    public class CrakenBool : CrakenObject
    {
        public CrakenBool(Function _parent, string _name, bool _data)
            : base(_parent, _name, new byte[] { ((byte)(_data ? 1 : 0)) }) { }
        public CrakenBool(Script _parent, string _name, bool _data)
            : base(_parent, _name, new byte[] { ((byte)(_data ? 1 : 0)) }) { }
        public CrakenBool(Craken _parent, string _name, bool _data)
            : base(_parent, _name, new byte[] { ((byte)(_data ? 1 : 0)) }) { }

        public override object Value
        {
            get { return this[0] == 1; }
            set { this[0] = ((byte)((bool)value ? 1 : 0)); }
        }

        public static bool operator ==(CrakenBool a, CrakenBool b)
        {
            bool numa, numb;
            numa = (bool)a.Value;
            numb = (bool)b.Value;
            return numa == numb;
        }

        public static bool operator !=(CrakenBool a, CrakenBool b)
        {
            bool numa, numb;
            numa = (bool)a.Value;
            numb = (bool)b.Value;
            return numa != numb;
        }

        public static bool operator true(CrakenBool a) { return (bool)a.Value == true; }
        public static bool operator false(CrakenBool a) { return (bool)a.Value == false; }
        public static CrakenBool operator &(CrakenBool a, CrakenBool b) 
        {
            Type ttype = a.parent.GetType();
            if (ttype == typeof(Craken)) { return new CrakenBool((Craken)a.parent, a.name, (bool)a.Value & (bool)b.Value); }
            else if (ttype == typeof(Script)) { return new CrakenBool((Script)a.parent, a.name, (bool)a.Value & (bool)b.Value); }
            else if (ttype == typeof(Function)) { return new CrakenBool((Function)a.parent, a.name, (bool)a.Value & (bool)b.Value); }
            return null;
        }
        public static CrakenBool operator |(CrakenBool a, CrakenBool b)
        {
            Type ttype = a.parent.GetType();
            if (ttype == typeof(Craken)) { return new CrakenBool((Craken)a.parent, a.name, (bool)a.Value | (bool)b.Value); }
            else if (ttype == typeof(Script)) { return new CrakenBool((Script)a.parent, a.name, (bool)a.Value | (bool)b.Value); }
            else if (ttype == typeof(Function)) { return new CrakenBool((Function)a.parent, a.name, (bool)a.Value | (bool)b.Value); }
            return null;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(bool)) { return ((bool)Value) == ((bool)obj); };
            return base.Equals(obj);
        }
        public override int GetHashCode() { return ((bool)Value).GetHashCode(); }
        public override string ToString() { return ((bool)Value).ToString(); }
    }
}