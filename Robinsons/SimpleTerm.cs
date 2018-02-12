
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Robinsons {
    public class SimpleTerm : Term {

        public string Content { get; private set; }

        public SimpleTerm(string str) {
            Content = str;
            Type = TermType.Var;
            //Type = Regex.Match(str, @"[a-zA-Z]+[0-9]+").Success ? TermType.Var : TermType.Const;
        }

        public override Term ApplySubstitution(ref Substitution s) {
            Content = Content.Replace(s.T1.ToString(), s.T2.ToString());
            return this;
        }

        public override Term ApplySubstitution(ref List<Substitution> subs, int start) {
            for (int i = start; i < subs.Count; i++) {
                if (Content == subs[i].T1.ToString()) Content = subs[i].T2.ToString();
                Content = Content.Replace(subs[i].T1.ToString(), subs[i].T2.ToString());
            }
            return this;
        }

        public override string ToString() {
            return Content;
        }

        public virtual Term Tail() {
            return new Term();
        }

        public bool OccursIn(ref Term e2) {
            return e2.ToString().Contains(Content);
        }

        public bool Equals(SimpleTerm other) {
            return other != null && Content == other.Content;
        }

        public override int GetHashCode() {
            return Content.GetHashCode() * 3;
        }
    }
}