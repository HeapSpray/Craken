using System;

namespace Nerey.Craken
{
    public class CrakenException : Exception
    {
        public enum Exceptions : int
        {
            ScriptRead_FAIL = 0,
            ScriptCompile_FAIL = 1,
            Unhandled = 2,
            DivideByZero = 3,
            NullRef = 4,
            ReadOnly = 5,
            StackOverflow = 6,
            Script_NOENTRY = 7,
            Script_NOTLOADED = 8,
            Function_NOTFOUND = 9
        };

        public int id { get; private set; }
        string arga, argb, argc;

        public CrakenException(int _id, string _arga = "", string _argb = "", string _argc = "")
        {
            id = _id;
            arga = _arga;
            argb = _argb;
            argc = _argc;
        }

        public CrakenException(Exceptions _id)
        {
            id = (int)_id;
        }

        public override string Message
        {
            get 
            {
                return string.Format(Messages[id], arga, argb, argc);
            }
        }

        static string[] Messages = new string[]
        {
            "Program: Failed to read the script {0}",
            "Program: Failed to compile the script {0}",
            "Script: Unhandled exception",
            "Script: Divide by zero",
            "Script: null reference {0}",
            "The object is read only: {0}",
            "Stack overflow!",
            "Script {0} has no entry point(main)!",
            "Script {0} not loaded!",
            "Function {0} not found!"
        };
    }
}