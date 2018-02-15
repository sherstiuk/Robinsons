
using System;
using System.Collections.Generic;
using System.Text;

namespace Robinsons {
    public class Unification {
        public static int Performed = 0;

        public static string Unify(Term e1, Term e2) {
            //var subs = new List<Substitution>();
            Substitutions.Finish();
            //Substitutions.Create();
            var composition = UnifyArgs(ref e1, ref e2, false);
            if (!composition) return "FAIL";
            //var subs = Substitutions.getSubs();
            Substitutions.Finish();
            //return subs;
            return "SUCCESS";
        }

        private static bool UnifyArgs(ref Term e1, ref Term e2, bool subs) {
            if (e1.Empty() && e2.Empty()) return true;

            if (e1.Func() && e2.Func())
                if (((Function)e1).Arity != ((Function)e2).Arity)
                    return false;
            //if (e1.Constant() && e2.Constant()) return e1.ToString().Equals(e2.ToString()) ? subs : null;
            if (e1.Var()) {
                if (e2.Var() && ((SimpleTerm)e1).Equals((SimpleTerm)e2))
                    return true;
                else if (((SimpleTerm) e1).OccursIn(ref e2))
                    return false;

                //if (Substitutions.Exists() && Substitutions.Has(ref e1, ref e2))
                //    return false;
                Substitutions.Add(ref e1, ref e2);
                return true;
            }
            if (e2.Var()) {
                if (e1.Var() && ((SimpleTerm)e2).Equals((SimpleTerm)e1))
                    return subs;
                else if (((SimpleTerm)e2).OccursIn(ref e1))
                    return false;

                //if (!Substitutions.Has(ref e2, ref e1))
                    Substitutions.Add(ref e2, ref e1);

                return true;
            }
            else {
                var HE1 = ((Function) e1).Head();
                var HE2 = ((Function) e2).Head();

                var SUBS1 = UnifyArgs(ref HE1, ref HE2, subs);
                HE1 = HE2 = null;

                if (!SUBS1)
                    return false;

                var TE1 = Substitutions.Apply(((Function)e1).Tail(), Performed);
                var TE2 = Substitutions.Apply(((Function)e2).Tail(), Performed);
                Performed++;

                var SUBS2 = UnifyArgs(ref TE1, ref TE2, subs);

                TE1 = TE2 = null;

                return (!SUBS2) ? false : true;
            }
        }
    }
}