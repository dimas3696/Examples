using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressions
{
    class Program
    {
        delegate decimal Operation(int a, int b);
        delegate int SingleOperation(int a);

        delegate bool Equels(int a, int b);

        delegate decimal Operation3El(Operation a, int c);

        static void Main(string[] args)
        {
            Operation op = (a, b) => a + b;
            SingleOperation mult = a => a * a;
            int x = 3;
            int y = 5;
            int z = 1;
            Console.WriteLine("{0} + {1} = {2}", x, y, op(x, y));
            Console.WriteLine("{0}^2 = {1}", x, mult(x));
            Equels e = (a, b) =>
                {
                    if (a == b)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                };
            Console.WriteLine("{0} == {1} - {2}", x, y, e(x, y));

            Operation3El op3el = (op2, c) => op(x, y) + z;
            Console.WriteLine("({0} + {1}) + {2} = {3}", x, y, z, op3el(op, z));
            Console.ReadKey();
        }
    }
}
