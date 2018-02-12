
using System.Collections.Generic;

namespace Robinsons {
    public class TermCreator {

        public static Term GetTerm(string str) {
            if (str == null)
                return new Term();
            else if (!FuncAnalyzer.IsFunc(ref str))
                return new SimpleTerm(str);
            return GetTerm(/*FuncAnalyzer.GetName(str), */FuncAnalyzer.GetArgs(str));
        }

        public static Function GetTerm(/*string name, */List<string> args) {
            return new Function(/*name, */args);
        }

    }
}