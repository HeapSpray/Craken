using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

using Nerey.Craken.Data;
namespace Nerey.Craken
{
    public class Lexer
    {
        // can set only inside our class
        public Craken craken { get; private set; }                      // vm
        public StringHelper strh { get { return craken.StrHelp; } }
        public ExpressionHelper exprh { get { return craken.ExprHelp; } }
        public Lexer(Craken _craken) { craken = _craken; }

        static string[] datatypes = new string[]
        {
            "int", "short", "byte", "char",
            "uint32", "ushort", "sbyte", "string",
            "object", "ref", "objref"
        };

        public Lexem[] ProcessExpression(string expression)
        {
            List<Lexem> lexems = new List<Lexem>();
            List<string> commands = new List<string>();
            List<string> variables = new List<string>();
            string expr, temp, func = ""; LexemType ltype = LexemType.Unknown;
            int start = 0, length = 0, end = 0; char chr = char.MinValue, pchr = char.MinValue;
            string[] splt, isplt; Lexem lastlexem = new Lexem("", LexemType.Unknown, LexemDataType.Unknown, "");
            char b = char.MinValue; bool ib = false;
            char sb = "'"[0]; string btmp = "";

            expr = expression; int l = expr.Length;
            for (int i = 0; i < l; i++)
            {
                if ("{}!=-+*/()&|,.:?".IndexOf(expr[i]) > -1 || (i == l - 1))
                {
                    pchr = chr; chr = expr[i];
                    end = i; length = end - start;
                    temp = expr.Substring(start, length);
                    if (i == l - 1) { chr = ';'; lexems.Add(new Lexem(chr.ToString(), LexemType.Divider, LexemDataType.Unknown, (i + 1).ToString())); }
                    else { lexems.Add(new Lexem(chr.ToString(), LexemType.Divider, LexemDataType.Unknown, i.ToString())); };

                    if (expr.StartsWith("proc ") && chr == '(') 
                    {
                        isplt = strh.nbSplit(expr, ' ');
                        lexems.Add(new Lexem(isplt[2], LexemType.DeclareFunction, strh.StrToLDT(isplt[1]), ""));
                    };

                    
                    start = i + 1;
                };
            };
            return lexems.ToArray();
        }

        public Opcode[] CompileExpression(Lexem[] lexems)
        {
            List<Opcode> opcodes = new List<Opcode>();

            return opcodes.ToArray();
        }
    }
}