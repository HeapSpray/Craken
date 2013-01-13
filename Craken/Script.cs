using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Nerey.Craken.Data;

namespace Nerey.Craken
{
    public class Script
    {
        public Craken vm { get; private set; }
        public string name { get; private set; }
        StringHelper strh { get { return vm.StrHelp; } }
        ExpressionHelper expr { get { return vm.ExprHelp; } }

        public Script(Craken _vm, string path)
        {
            vm = _vm;
            if (!File.Exists(path)) { throw new CrakenException(CrakenException.Exceptions.ScriptRead_FAIL); };
            string alltxt, temp;
            alltxt = File.ReadAllText(path);
            // prepare our source for parsing
            temp = vm.StrHelp.Clean(alltxt);
            alltxt = temp;
            // get script's filename. it'll be used as actual name
            string[] splt = path.Replace(@"\", ".").Split('.');
            name = splt[splt.Length - 2];

            Compile(alltxt);
        }

        Dictionary<string, CrakenObject> objects;
        Dictionary<string, Function> functions;
        List<string> names;
        public ICollection<string> FunctionPaths { get { return functions.Keys; } }
        public ICollection<string> ObjectPaths { get { return objects.Keys; } }
        void Compile(string script)
        {
            // temp stuff
            string[] splt, isplt, spc; string temp = "", tmp = "", exprbody = "";
            int start = 0, length = 0, end = 0, clvl = 0, blvl = 0; char chr = char.MinValue, pchr = char.MinValue;
            objects = new Dictionary<string, CrakenObject>();
            functions = new Dictionary<string, Function>();
            //names = new List<string>();
            Lexer lex = new Lexer(vm);
            // function lexems
            List<Lexem> flexems = new List<Lexem>();
            // bracket lists
            List<int> oc, ob, cc, cb;
            oc = new List<int>(); ob = new List<int>(); 
            cc = new List<int>(); cb = new List<int>(); 
            // other function data
            FunctionArgument[] args = null; int j = 0;
            string fname = ""; Type ftype = typeof(int);
            // bracket parsing vars
            char b = char.MinValue; bool ib = false;
            char sb = "'"[0];

            for (int i = 0; i < script.Length; i++)
            {
                // check brackets here :o
                if ((script[i] == '"' || script[i] == sb) && (ib == false && b == char.MinValue)) { b = script[i]; ib = true; };
                if (ib == true && script[i] == b) { ib = false; b = char.MinValue; };
                if (ib == false)
                {
                    // move through dat structures :o
                    if ("{}();".Contains(script[i].ToString()))
                    {
                        pchr = chr; chr = script[i];
                        end = i; length = end - start;
                        temp = script.Substring(start, length);

                        if (chr == '{') { oc.Add(i); clvl++; }; if (chr == '}') { cc.Add(i); clvl--; };
                        if (chr == '(') { ob.Add(i); blvl++; }; if (chr == ')') { cb.Add(i); blvl--; };

                        // if we've got a procedure declared here... parse it
                        if (temp.StartsWith("proc ") && chr == '(' && blvl == 1 && clvl == 0)
                        {
                            splt = temp.Split(' '); // %stuff from proc declare to '(' aka beginning of args list% .split(' ')
                            fname = splt[2]; ftype = strh.StrToType(splt[1]); // function's name and type detected
                            j = i + 1; tmp = "";    // temp variables
                            while (script[j] != ')') { tmp += script[j]; j++; }; blvl--;    // get arguments string between brackets
                            spc = tmp.Replace(", ", ",").Split(',');                        // split arguments via commas
                            args = new FunctionArgument[spc.Length];                        // prepare argument array
                            for (int k = 0; k < spc.Length; k++)                            // loop through arguments and process then
                            {  
                                isplt = spc[k].Split(' ');                                  // split arg to get datatype and name
                                args[k] = new FunctionArgument(isplt[1], strh.StrToType(isplt[0]));
                            };
                            tmp = ""; spc = null; isplt = null;                             // temp cleanup
                            i = j; j = 0;                                                   // move to end of args, we've already processed them
                        };

                        if (pchr == '{' && clvl == 1)   // function begins here
                        {
                            exprbody = "";
                        };

                        if (chr == ';' && clvl > 1)     // expression somewhere in function's body
                        {
                            // parse the expression and put those lexems to function's body
                            flexems.AddRange(lex.ProcessExpression(exprbody));
                        };

                        if (chr == '}' && clvl == 0)    // function ends here
                        {
                            // write function to the list, put lexems to it... cleanup temp vars
                            functions.Add(fname, new Function(this, lex.CompileExpression(flexems.ToArray()), fname, args, ftype));
                            ftype = null; fname = ""; args = null; flexems.Clear(); exprbody = "";
                        };

                        if (clvl > 0) { exprbody += temp + chr; }; // put function's body here

                        start = i + 1;
                    };
                };
            };
            // if bracket level (increases with open ones, decreases with closed) is > 0 after end of parsing.. we've got an error in script obviously
            if (clvl != 0 || blvl != 0) { throw new Exception("Wrong brackets placement!"); };

            // add ourself to vm
            foreach (string fn in functions.Keys) 
            {
                vm.SetFunction(name + "." + fn, null); 
            };
            vm[name, false] = this;
        }

        public Function GetFunction(string name) 
        { 
            return functions[name]; 
        }
        public void SetFunction(string path, Function func)
        {
            if (!functions.ContainsKey(path)) { functions.Add(path, func); return; }
            else { functions[path] = func; };
        }

        // invoke main (entry point for script)
        public object Invoke(params object[] args) 
        {
            if (!vm.FunctionPaths.Contains(name + ".main")) { throw new CrakenException((int)CrakenException.Exceptions.Script_NOENTRY, name); };
            return vm.Invoke(name + ".main", args);
        }

        public object Invoke(string function, params object[] args)
        {
            if (!functions.ContainsKey(function)) { throw new CrakenException((int)CrakenException.Exceptions.Function_NOTFOUND, function); };
            return functions[function].Invoke(args);
        }
    }
}