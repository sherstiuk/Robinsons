
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Robinsons {
    public class FuncAnalyzer {
        
        public static bool IsFunc(ref string str) {
            foreach (var c in str)
                if (c == '(')
                    return true;
            return false;
            //return Regex.Match(str, @"([a-zA-Z]+)(\\(.*\\))").Success;
        }

        public static string GetName(string str) {
            return Regex.Match(str, @"([a-zA-Z]+)(\\(.*\\))").Groups[0].Value;
        }

        public static List<string> GetArgs(string str) {
            //if (!IsFunc(ref str)) return null;
            //str = str.Replace(@"\\s", "");
            var args = new List<string>();

            int parenthesesOpen = 0;
            var current = new StringBuilder();

            foreach (var c in str) {
                if (parenthesesOpen == 0) {
                    if (c == ')') {
                        args.Add(current.ToString());
                        current.Length = 0;
                    }
                    else if (c == '(') parenthesesOpen++;
                    else continue;
                }
                else if (parenthesesOpen == 1) {
                    if (c == '(') parenthesesOpen++;
                    if (c == ')') {
                        parenthesesOpen--;
                        args.Add(current.ToString());
                        current.Length = 0;
                    }
                    if (c == 'x' || c == 'y' || c == 'F') {
                        if (current.Length == 0) current.Append(c);
                        else {
                            args.Add(current.ToString());
                            current.Length = 0;
                            current.Append(c);
                        }
                    }
                    else {
                        current.Append(c);
                    }
                }
                else {
                    if (c == '(') parenthesesOpen++;
                    if (c == ')') parenthesesOpen--;
                    current.Append(c);
                }
            }
            
            //for (String a in args) 	Console.WriteLine(a);
            args.TrimExcess();
            return args;
        }
    }
}

