using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robinsons {
    class Program {
        public static void Main(string[] args) {
            int n = 24;
            Console.WriteLine("N=" + n);
            Console.WriteLine("\nTerm 1: \t" + HTermGenerator.FirstAsString(n));
            Console.WriteLine("\nTerm 2: \t" + HTermGenerator.SecondAsString(n));
            //Console.WriteLine("\nSupposed res: \t [x1/f(x0,x0), x2/f(f(x0,x0),f(x0,x0)), y1/f(y0,y0), y2/f(f(y0,y0),f(y0,y0))]");
            Console.WriteLine("\n\nResult: \t" +
                              (Unification.Unify(HTermGenerator.First(n), HTermGenerator.Second(n))));

        }
    }
}
