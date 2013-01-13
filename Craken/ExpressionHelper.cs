using System;
using System.Collections;
using System.Collections.Generic;

namespace Nerey.Craken
{
    public class ExpressionHelper
    {
        // can set only inside our class
        public Craken craken { get; private set; } // Actually the vm itself

        public ExpressionHelper(Craken _craken)
        {
            craken = _craken;
        }

        public Lexem[] ParseExpression(string expression)
        {
            List<Lexem> ops = new List<Lexem>();
            int length = 0, start = 0, end = 0;
            string substr;
            
            for (int i = 0; i < expression.Length; i++)
            {

            };
            return ops.ToArray();
        }
    }
}