using System;
using System.Collections;
using System.Collections.Generic;

namespace Nerey.Craken
{
    public class StringHelper
    {
        // replace, ignoring brackets content.. quite rough but works
        public string nbReplace(string where, string what, string with)
        {
            string result = ""; int i = 0, wl = what.Length;
            char b = char.MinValue; bool ib = false;
            char sb = "'"[0];
            for (i = 0; i < where.Length; i++)
            {
                if ((where[i] == '"' || where[i] == sb) && (ib == false && b == char.MinValue)) { b = where[i]; ib = true; };
                if (ib == true && where[i] == b) { ib = false; b = char.MinValue; };
                if (ib == false)
                {
                    if (where.Length > i + what.Length)
                    {
                        if (where.Substring(i, wl) == what)
                        { result += with; i += wl; }
                        else { result += where[i]; };
                    }
                    else { result += where[i]; };
                }
                else { result += where[i]; };
            };
            return result;
        }

        public string nbReplace(string where, char what, char with)
        {
            string result = ""; int i = 0;
            char b = char.MinValue; bool ib = false;
            char sb = "'"[0];
            for (i = 0; i < where.Length; i++)
            {
                if ((where[i] == '"' || where[i] == sb) && (ib == false && b == char.MinValue)) { b = where[i]; ib = true; };
                if (ib == true && where[i] == b) { ib = false; b = char.MinValue; };
                if (!ib)
                {
                    if (where[i] != what) { result += where[i]; }
                    else { result += with; };
                };
            };
            return result;
        }

        // inside brackets replace
        public string ibReplace(string where, string what, string with)
        {
            string result = ""; int i = 0, wl = what.Length;
            char b = char.MinValue; bool ib = false;
            char sb = "'"[0];
            for (i = 0; i < where.Length; i++)
            {
                if ((where[i] == '"' || where[i] == sb) && (ib == false && b == char.MinValue)) { b = where[i]; ib = true; };
                if (ib == true && where[i] == b) { ib = false; b = char.MinValue; };
                if (ib)
                {
                    if (where.Length > i + what.Length)
                    {
                        if (where.Substring(i, wl) == what)
                        { result += with; i += wl; }
                        else { result += where[i]; };
                    };
                };
            };
            return result;
        }

        // if string (ignoring stuff wich is in brackets inside of string) contains somthing like if nbContains("a 'b' c", 'b')... would return false. while nbContains("a b 'c'", 'b') = true
        public bool nbContains(string where, char what) 
        {
            char b = char.MinValue; bool ib = false;
            char sb = "'"[0]; int i = 0;
            for (i = 0; i < where.Length; i++)
            {
                if ((where[i] == '"' || where[i] == sb) && (ib == false && b == char.MinValue)) { b = where[i]; ib = true; };
                if (ib == true && where[i] == b) { ib = false; b = char.MinValue; };
                if (!ib) { if (where[i] == what) { return true; }; };
            };
            return false;
        }

        public bool nbContains(string where, string what)
        {
            char b = char.MinValue; bool ib = false;
            char sb = "'"[0]; int i = 0, wl = what.Length;
            for (i = 0; i < where.Length; i++)
            {
                if ((where[i] == '"' || where[i] == sb) && (ib == false && b == char.MinValue)) { b = where[i]; ib = true; };
                if (ib == true && where[i] == b) { ib = false; b = char.MinValue; };
                if (!ib) { if (i + wl < where.Length) { if (where.Substring(i, wl) == what) { return true; } }; };
            };
            return false;
        }

        // split stuff ignoring brackets content
        public string[] nbSplit(string where, char chr)
        {
            List<string> result = new List<string>();
            char b = char.MinValue; bool ib = false;
            char sb = "'"[0]; int i = 0, s = 0;
            for (i = 0; i < where.Length; i++)
            {
                if ((where[i] == '"' || where[i] == sb) && (ib == false && b == char.MinValue)) { b = where[i]; ib = true; };
                if (ib == true && where[i] == b) { ib = false; b = char.MinValue; };
                if (!ib) 
                {
                    if (where[i] == chr) 
                    {
                        result.Add(where.Substring(s, i - s));
                        s = i + 1; 
                    };
                };
            };
            return result.ToArray();
        }

        // kill those new lines, tabs, multiple space chars and so on.... make text easier to parse
        public string RemoveFormatting(string from, bool ignoreBrackets = false)
        {
            string result = "";
            char b = char.MinValue; bool ib = false;
            char sb = "'"[0];

            if (ignoreBrackets)
            {
                for (int i = 0; i < from.Length; i++)
                {
                    if (from[i] != '\n' && from[i] != '\t' && from[i] != '\r') { result += from[i]; };
                };
            }
            else
            {
                for (int i = 0; i < from.Length; i++)
                {
                    if ((from[i] == '"' || from[i] == sb) && (ib == false && b == char.MinValue)) { b = from[i]; ib = true; };
                    if (ib == true && from[i] == b) { ib = false; b = char.MinValue; };
                    if (!ib) { if (from[i] != '\n' && from[i] != '\t' && from[i] != '\r') { result += from[i]; }; }
                    else { result += from[i]; };
                };
            }

            return result;
        }

        // cleanup.. large cleanup 
        public string Clean(string what)
        {
            string result = "", temp = "";
            Console.WriteLine(what + "\n\n");
            temp = RemoveFormatting(what); result = temp; Console.WriteLine(result + "\n\n");
            while (result.Contains("  ")) { temp = nbReplace(what, "  ", " "); result = temp; }; Console.WriteLine(result + "\n\n");
            return result;
        }

        // string to lexem data type
        public LexemDataType StrToLDT(string str)
        {
            switch (str)
            {
                case "int": return LexemDataType.int32;
                case "short": return LexemDataType.int16;
                case "sbyte": return LexemDataType.int8;
                case "bool": return LexemDataType.boolean;
                case "char": return LexemDataType.char8;
                case "object": return LexemDataType.obj;
                case "ref": return LexemDataType.ref32;
                case "string": return LexemDataType.str8;
                case "uint32": return LexemDataType.uint32;
                case "uint16": return LexemDataType.uint16;
                case "byte": return LexemDataType.uint8;
                default: return LexemDataType.Unknown;
            }
        }

        // string to C# native type
        public Type StrToType(string str)
        {
            switch (str)
            {
                case "int": return typeof(Int32);
                case "short": return typeof(Int16);
                case "sbyte": return typeof(sbyte);
                case "bool": return typeof(bool);
                case "char": return typeof(char);
                case "object": return typeof(object);
                case "ref": return typeof(string);
                case "string": return typeof(string);
                case "uint32": return typeof(UInt32);
                case "uint16": return typeof(UInt16);
                case "byte": return typeof(byte);
                default: return typeof(object);
            };
        }
    }
}