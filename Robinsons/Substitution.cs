
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Robinsons {

    public class Substitution : IEquatable<Substitution>
    {
        public Term T1 { get; private set; }
        public Term T2 { get; private set; }
        //public string T1 { get; private set; }
        //public string T2 { get; private set; }
        /* public bool Empty { get; }

         public Substitution() {
             this.Empty = true;
         }*/

        public Substitution(ref Term t1, ref Term t2) {
            this.T1 = t1;//.ToString();
            this.T2 = t2;//.ToString();
            //this.Empty = false;
        }

        public override string ToString()
            => /*Empty ? null :*/ (new StringBuilder()).Append(T1).Append('/').Append(T2).ToString();

        public bool Equals(Substitution other) {
            return other != null &&
                   EqualityComparer<Term>.Default.Equals(T1, other.T1) &&
                   EqualityComparer<Term>.Default.Equals(T2, other.T2);
        }

        public override int GetHashCode() {
            var hashCode = -2046433335;
            hashCode = hashCode * -1521134295 + EqualityComparer<Term>.Default.GetHashCode(T1);
            hashCode = hashCode * -1521134295 + EqualityComparer<Term>.Default.GetHashCode(T2);
            return hashCode;
        }
    }
}