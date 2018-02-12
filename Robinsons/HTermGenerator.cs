
using System.Collections.Generic;
using System.Text;

namespace Robinsons {
    public class HTermGenerator {

        public static Function First(int n) {
            var args = new List<string>();
            int arity = 0;
            if (n < 10) {
                for (int i = 1; i <= n; i++, arity++) args.Add("x" + i);
                //for (int i = 0; i < n; i++, arity++) args.Add("f(y" + i + "," + "y" + i + ")");
                for (int i = 0; i < n; i++, arity++) args.Add("F(y" + i + "y" + i + ")");
                args.Add("y" + n);
            }
            else {
                for (int i = 0; i < 10; i++, arity++) args.Add("x0" + i);
                for (int i = 10; i <= n; i++, arity++) args.Add("x" + i);
                //for (int i = 1; i < 10; i++, arity++) args.Add("f(y0" + i + "," + "y0" + i + ")");
                //for (int i = 10; i < n; i++, arity++) args.Add("f(y" + i + "," + "y" + i + ")");
                for (int i = 1; i < 10; i++, arity++) args.Add("F(y0" + i + "y0" + i + ")");
                for (int i = 10; i < n; i++, arity++) args.Add("F(y" + i + "y" + i + ")");
                args.Add("x" + n);
            }

            args.TrimExcess();
            arity++;
            return new Function(args, arity);
        }

        public static Function Second(int n) {
            var args = new List<string>();
            int arity = 0;
            if (n < 10) {
                //for (int i = 0; i < n; i++, arity++) args.Add("f(x" + i + "," + "x" + i + ")");
                for (int i = 0; i < n; i++, arity++) args.Add("F(x" + i + "x" + i + ")");
                for (int i = 1; i <= n; i++, arity++) args.Add("y" + i);
                args.Add("x" + n);
            }
            else {
                //for (int i = 0; i < 10; i++, arity++) args.Add("f(x0" + i + "," + "x0" + i + ")");
                //for (int i = 10; i < n; i++, arity++) args.Add("f(x" + i + "," + "x" + i + ")");
                for (int i = 0; i < 10; i++, arity++) args.Add("F(x0" + i + "x0" + i + ")");
                for (int i = 10; i < n; i++, arity++) args.Add("F(x" + i + "x" + i + ")");
                for (int i = 1; i < 10; i++, arity++) args.Add("y0" + i);
                for (int i = 10; i <= n; i++, arity++) args.Add("y" + i);
                args.Add("x" + n);
            }
            args.TrimExcess();
            arity++;
            return new Function(args, arity);//Function("h", args, arity);
        }

        public static string FirstAsString(int n) {
            var sb = new StringBuilder("h(");
            for (int i = 1; i <= n; i++) sb.Append('x').Append(i).Append(',');
            for (int i = 0; i < n; i++) sb.Append("f(y").Append(i).Append(",y").Append(i).Append("),");
            sb.Append('y').Append(n).Append(')');
            return sb.ToString();
        }

        public static string SecondAsString(int n) {
            var sb = new StringBuilder("h(");
            for (int i = 0; i < n; i++) sb.Append("f(x").Append(i).Append(",x").Append(i).Append("),");
            for (int i = 1; i <= n; i++) sb.Append('y').Append(i).Append(',');
            sb.Append('x').Append(n).Append(')');
            return sb.ToString();
        }
    }
}