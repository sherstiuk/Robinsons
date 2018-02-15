
using System.Collections.Generic;

namespace Robinsons {

    public class Term {
        public enum TermType {
            Var,
            Const,
            Func,
            Empty,
        }

        public TermType Type { get; set; }

        public Term() {
            this.Type = TermType.Empty;
        }

        public virtual bool Var() {
            return this.Type == TermType.Var;
        }

        public virtual bool Constant() {
            return this.Type == TermType.Const;
        }

        public virtual bool Func() {
            return this.Type == TermType.Func;
        }

        public virtual bool Empty() {
            return this.Type == TermType.Empty;
        }

        public virtual void ApplySubstitution(ref string from, ref string to) {}
        
        /*
        public virtual Term ApplySubstitution(ref Substitution s) {
            return this;
        }

        public virtual Term ApplySubstitution(ref List<Substitution> subs, int start) {
            return this;
        }*/

        public override string ToString() {
            return "";
        }

    }
}