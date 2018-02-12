
using System;
using System.Collections.Generic;
using System.Text;

namespace Robinsons {
    public class Unification {
        public static int Performed = 0;

        public static string Unify(Term e1, Term e2) {
            var subs = new List<Substitution>();
            var composition = UnifyArgs(ref e1, ref e2, ref subs);
            if (composition == null) return "FAIL";
            subs = null;

            ///*
            var sb = new StringBuilder("{ ");
            for (int i = 0; i < composition.Count - 1; i++) sb.Append(composition[i].ToString()).Append(" , ");
            return sb.Append(composition[composition.Count - 1]).Append(" }").ToString();
            //*/
            //return "SUCCESS";
        }

        private static List<Substitution> UnifyArgs(ref Term e1, ref Term e2, ref List<Substitution> subs) {
            if (subs == null) subs = new List<Substitution>();

            if (e1.Empty() && e2.Empty()) return subs;

            if (e1.Func() && e2.Func())
                if (((Function)e1).Arity != ((Function)e2).Arity)
                    return null;
            //if (e1.Constant() && e2.Constant()) return e1.ToString().Equals(e2.ToString()) ? subs : null;
            if (e1.Var()) {
                if (e2.Var() && ((SimpleTerm)e1).Equals((SimpleTerm)e2))
                    return subs;
                else if (((SimpleTerm) e1).OccursIn(ref e2))
                    return null;
                var s = new Substitution(ref e1, ref e2);
                subs.Add(s);
                subs.TrimExcess();
                s = null;
                return subs;
            }
            if (e2.Var()) {
                if (e1.Var() && ((SimpleTerm)e2).Equals((SimpleTerm)e1))
                    return subs;
                else if (((SimpleTerm)e2).OccursIn(ref e1))
                    return null;
                var s = new Substitution(ref e2, ref e1);
                subs.Add(s);
                subs.TrimExcess();
                s = null;
                return subs;
            }
            else {
                var HE1 = ((Function) e1).Head();
                var HE2 = ((Function) e2).Head();

                var SUBS1 = UnifyArgs(ref HE1, ref HE2, ref subs);
                HE1 = HE2 = null;

                if (SUBS1 == null) return null;

                var TE1 = ((Function) e1).Tail().ApplySubstitution(ref SUBS1, Performed);
                var TE2 = ((Function) e2).Tail().ApplySubstitution(ref SUBS1, Performed);
                SUBS1 = null;
                Performed++;

                var SUBS2 = UnifyArgs(ref TE1, ref TE2, ref subs);

                TE1 = TE2 = null;

                return SUBS2 == null ? null : subs;
            }
        }
    }
}