using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robinsons {
    class Substitutions {

        private static string _path = @"..\subs.txt";

        public static void Create() {
            if (File.Exists(_path)) return;
            File.Create(_path);
            //File.SetAttributes(_path, FileAttributes.Hidden);
        }

        public static Term Apply(Term t, int start) {
            string[] subs = getLines();
            foreach (var s in subs) {
                var pair = s.Split('|');
                string from = pair[0];
                string to = pair[1];
                pair = null;
                t.ApplySubstitution(ref from, ref to);
            }
            return t;
        }

        public static void Add(ref Term e1, ref Term e2) => File.AppendAllText(_path, getSub(ref e1, ref e2) );

        public static void Add(string sub) => File.AppendAllText(_path, sub);

        public static bool Has(ref Term e1, ref Term e2) {
            string[] subs = getLines();
            var sub = getSub(ref e1, ref e2);
            foreach (var s in subs)
                if (s == sub) return true;
            return false;
        }

        public static void Finish() {
            if (File.Exists(_path))
                File.Delete(_path);
        }

        public static string getSubs() {
            string[] subs = getLines();
            var sb = new StringBuilder("{ ");
            foreach (var s in subs) sb.Append(s).Append(" , ");
            return sb.Append(subs[subs.Length - 1]).Append(" }").ToString();
        }

        public static bool Exists() => File.Exists(_path);

        private static string[] getLines() => File.Exists(_path) ? File.ReadAllLines(_path) : null;

        public static string getSub(ref Term e1, ref Term e2) => (new StringBuilder()).Append(e1).Append('|').Append(e2).Append('\n').ToString();

    }
}
