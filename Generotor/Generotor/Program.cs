using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generotor
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in Pow(2, 8))
            {
                Console.Write("{0} ", item);
            }
            Console.ReadKey();
        }

        public static IEnumerable<int> Pow(int num, int exp)
        {
            int res = 1;

            for (int i = 0; i < exp; i++)
            {
                res = res * num;
                yield return res;
            }
        }
    }
}
