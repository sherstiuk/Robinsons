
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Robinsons {

    public class Function : Term
    {
        //public string Name { get; }
        public List<string> Args { get; }
        public int Arity { get; }
        private string Content { get; set; }

        public Function(/*string name, */List<string> args) {
            this.Type = TermType.Func;
            //this.Name = name;
            this.Args = args;
            this.Arity = args.Count;
        }

        public Function(/*string name, */List<string> args, int arity) {
            this.Type = TermType.Func;
            //this.Name = name;
            this.Args = args;
            this.Arity = arity;
        }

        public virtual Term Head() {
            return TermCreator.GetTerm(Args[0]);
        }

        public virtual Term Tail() {
            if (Arity > 2) return new Function(/*Name,*/ new List<string>(Args.GetRange(1, Arity - 1)));
            return new SimpleTerm(Args[0]);
        }

        public virtual string HeadToString() {
            return Args[0];
        }

        public override void ApplySubstitution(ref string from, ref string to) {
            for (int i = 0; i < Arity; i++)
                Args[i] = Args[i].Replace(@from, @to);
        }

        /*
        public override Term ApplySubstitution(ref Substitution s) {
            for (int i = 0; i < Arity; i++)
                Args[i] = Args[i].Replace(s.T1.ToString(), s.T2.ToString());
            return this;
        }
        
        public override Term ApplySubstitution(ref List<Substitution> subs, int start) {
            for (int i = 0; i < Arity; i++)
                for (int j = start; j < subs.Count; j++) {
                    if (Args[i] == subs[j].T1.ToString()) Args[i] = subs[j].T2.ToString();
                    Args[i] = Args[i].Replace(subs[j].T1.ToString(), subs[j].T2.ToString());
                }
            return this;
        }*/

        public override string ToString() {
            var sb = (new StringBuilder("F(")); //StringBuilder(Name)).Append('(')
            for (int i = 0; i < Arity; i++) sb.Append(Args[i]); //Arity - 1; i++) sb.Append(Args[i]).Append(',');
            return sb.Append(')').ToString(); //sb.Append(Args[Arity - 1]).Append(')').ToString();
        }
    }
}
