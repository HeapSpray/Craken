using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

using Nerey.Craken.Data;
namespace Nerey.Craken
{
    public enum LexemType : byte
    {
        Unknown = 0, Operator, Command, Variable, 
        Keyword, Divider, String, Number, 
        BracketOpen, BracketClose, Logic,
        Assembly, Function, BeginFunction, EndFunction,
        BeginSection, EndSection, CType,
        BeginExpression, EndExpression,
        DeclareFunction, DeclareVariable,
        DeclareImport, DeclareExport
    };

    public enum LexemDataType : byte
    {
        Unknown = 0,
        int32, int16, int8, uint32, uint16, uint8,
        char8, str8, obj, ref32, boolean
    };

    public class Lexem
    {
        public string name { get; private set; }
        public LexemType type { get; private set; }
        public LexemDataType datatype { get; private set; }
        public string data { get; private set; }

        public Lexem(string _name, LexemType _type, LexemDataType _datatype, string _data)
        {
            name = _data; data = _data;
            type = _type; datatype = _datatype;
        }
    }
}