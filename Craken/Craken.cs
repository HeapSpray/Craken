using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

using Nerey.Craken.Data;
namespace Nerey.Craken
{
    public class Craken
    {
        // helpers.. used all along. on parse, compile, work
        public StringHelper StrHelp { get; private set; }
        public ExpressionHelper ExprHelp { get; private set; }
        public int stackSize { get; private set; } // what else could it be?
        // actually OOP part...
        Dictionary<string, Script> scripts;
        Dictionary<string, Function> functions;
        Dictionary<string, CrakenObject> objects; 
        // find me.. find me.. absolutely...
        public ICollection<string> FunctionPaths { get { return functions.Keys; } }
        public ICollection<string> Scripts { get { return scripts.Keys; } }
        public ICollection<string> ObjectPaths { get { return objects.Keys; } }
        // push-pop-push-pop :o
        public Stack stack { get; private set; }

        public Craken(int _stackSize = 1024)
        {
            stackSize = _stackSize;
            StrHelp = new StringHelper();
            ExprHelp = new ExpressionHelper(this);
            objects = new Dictionary<string, CrakenObject>();
            functions = new Dictionary<string, Function>();
            scripts = new Dictionary<string, Script>();
            stack = new Stack(stackSize);
        }

        // What do you think that means, lol? invoke is invoke 
        public object Invoke(string func, params object[] args) 
        {
            if (func.Contains(".")) // its not a global function bro, its a script one
            {
                string[] splt = func.Split('.');
                foreach (string n in scripts.Keys) { if (n == splt[0]) { return scripts[n].Invoke(splt[1], args); }; };
                throw new CrakenException((int)CrakenException.Exceptions.Function_NOTFOUND, splt[1]);
            }
            else { return Invoke(functions[func], args); };  // nah, its global
        }
        public object Invoke(Function func, params object[] args) 
        {
            if (stack.Count > stackSize) { throw new CrakenException(CrakenException.Exceptions.StackOverflow); };
            return func.Invoke(args);
        }

        // set or get Craken variable on specified path :o
        public CrakenObject this[string path] { get { return objects[path]; } set { objects[path] = value; } }

        public Function GetFunction(string path)
        {
            if (path.Contains("."))
            {
                string[] splt = path.Split('.');
                foreach (string n in scripts.Keys) { if (n == splt[0]) { return scripts[n].GetFunction(splt[1]); }; };
                throw new CrakenException((int)CrakenException.Exceptions.Function_NOTFOUND, splt[1]);
            }
            else 
            {
                if (functions.ContainsKey(path)) { return functions[path]; };
                throw new CrakenException((int)CrakenException.Exceptions.Function_NOTFOUND, path);
            };
        }

        public void SetFunction(string path, Function func)
        {
            if (!functions.ContainsKey(path)) { functions.Add(path, func); return; }
            else { functions[path] = func; };
        }
        
        // set or get scripts (bool invoke indicates if we must call initializer (constructor / int main) of script before using it)
        public Script this[string script, bool invoke]
        {
            get
            {
                if (!scripts.ContainsKey(script)) { throw new CrakenException(CrakenException.Exceptions.Script_NOTLOADED); }
                // get script
                if (invoke) { scripts[script].Invoke(); return scripts[script]; }
                else { return scripts[script]; };
            }
            set
            {
                // reserve a place
                if (!scripts.ContainsKey(script)) { scripts.Add(script, null); }
                // add / set our script
                if (invoke) { scripts[script] = value; scripts[script].Invoke(); }
                else { scripts[script] = value; };
            }
        }
    }
}