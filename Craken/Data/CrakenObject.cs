using System;

namespace Nerey.Craken.Data
{
    public class CrakenObject
    {
        public object parent { get; private set; }
        public string name { get; private set; }
        public bool ilocal { get; private set; }
        public bool ivirtual { get; private set; }
        public bool ireadonly { get; private set; }
        public Type type { get; private set; }
        public bool inull { get { return data == null && ndata == null; } }
        byte[] data; object ndata;

        public CrakenObject(Function _parent, string _name, byte[] _data)
        {
            ivirtual = true;
            ilocal = true;
            parent = _parent;
            name = _name;
            data = _data;
            type = data.GetType();
        }
        public CrakenObject(Script _parent, string _name, byte[] _data)
        {
            ivirtual = true;
            ilocal = false;
            parent = _parent;
            name = _name;
            data = _data;
            type = data.GetType();
        }
        public CrakenObject(Craken _parent, string _name, byte[] _data)
        {
            ivirtual = true;
            ilocal = false;
            parent = _parent;
            name = _name;
            data = _data;
            type = data.GetType();
        }

        public CrakenObject(Function _parent, string _name, object _data)
        {
            ivirtual = false;
            ilocal = true;
            parent = _parent;
            name = _name;
            ndata = _data;
            type = ndata.GetType();
        }
        public CrakenObject(Script _parent, string _name, object _data)
        {
            ivirtual = false;
            ilocal = false;
            parent = _parent;
            name = _name;
            ndata = _data;
            type = ndata.GetType();
        }
        public CrakenObject(Craken _parent, string _name, object _data)
        {
            ivirtual = false;
            ilocal = false;
            parent = _parent;
            name = _name;
            ndata = _data;
            type = ndata.GetType();
        }

        public virtual object this[bool initialize, object[] _params]
        {
            get 
            {
                if (!ivirtual) { return ndata; }
                else { return data; }
            }
            set 
            {
                if (ireadonly) { throw new CrakenException(CrakenException.Exceptions.ReadOnly); }
                else if (initialize) 
                {
                    if (!ivirtual) { ndata = type.TypeInitializer.Invoke(_params); }
                    else { data = new byte[(int)value]; };
                }
                else if (!initialize)
                {
                    if (!ivirtual) { ndata = value; }
                    else { data = (byte[])value; };
                };
            }
        }

        public virtual byte this[int i]
        {
            get { return data[i]; }
            set 
            {
                if (!ireadonly) { data[i] = value; }
                else { throw new CrakenException(CrakenException.Exceptions.ReadOnly); }
            }
        }

        public virtual object Value { get; set; }
        public virtual int Length { get { return data.Length; } }

    }
}