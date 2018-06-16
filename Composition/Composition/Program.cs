using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composition
{
    class Program
    {
        delegate int Sum(int a);
        delegate int Mult(int a);

        delegate int SumMult(int a);

        delegate int Operation(int a);
        delegate int Compose(Operation f1, Operation f2, int a);

        static void Main(string[] args)
        {
            int x = 5;
            Sum s = a => a + a;
            Mult m = a => a * a;
            Console.WriteLine("({0} + {1}) ^ 2 = {2}", x, x, m(s(x)));
            Console.WriteLine("({0} * {1}) + this.result = {2}", x, x, s(m(x)));

            //imperative composition
            Console.WriteLine("\nImperative composition");
            SumMult sm = a =>
            {
                int holder = a;
                holder = s(a);
                holder = m(holder);
                return holder;
            };
            Console.WriteLine("Delegate SumMult ({0} + {1}) ^ 2 = {2}", x, x, sm(x));

            //function composition
            Console.WriteLine("\nFunction composition");
            Operation opMult = a => a * a;
            Operation opSum = a => a + a;
            Compose compose = (f1, f2, a) => f1(f2(a));
            Console.WriteLine("Delegate Compose(Mult, Sum) ({0} + {1}) ^ 2 = {2}", x, x, compose(opMult, opSum, x));
            Console.WriteLine("Delegate Compose(Sum, Mult) ({0} * {1}) + this.result = {2}", x, x, compose(opSum, opMult, x));

            Console.ReadKey();
        }
    }
}
