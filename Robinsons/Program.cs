using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robinsons {
    class Program {
        public static void Main(string[] args) {
            int n = 2;
            Console.WriteLine("N=" + n);
            Console.WriteLine("\nTerm 1: \t" + HTermGenerator.FirstAsString(n));
            Console.WriteLine("\nTerm 2: \t" + HTermGenerator.SecondAsString(n));

            Console.WriteLine("\n\nResult: \t" +
                              (Unification.Unify(HTermGenerator.First(n), HTermGenerator.Second(n))));

        }
    }
}
