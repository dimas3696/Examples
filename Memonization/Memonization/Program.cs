using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Memonization
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Console.WriteLine(FibonacciNumber(4));
            timer.Stop();
            Console.WriteLine(timer.ElapsedMilliseconds.ToString() + "ms");
            Stopwatch timerMemo = new Stopwatch();
            timerMemo.Start();
            Console.WriteLine(FibonacciNumberMemoization(3000));
            timerMemo.Stop();
            Console.WriteLine(timerMemo.ElapsedMilliseconds.ToString() + "ms");
            Console.ReadKey();
        }

        public static ulong FibonacciNumber(uint which)
        {
            if (which == 1 || which == 2)
                return 1;

            return FibonacciNumber(which - 2) + FibonacciNumber(which - 1);
        }

        public static ulong FibonacciNumberMemoization(uint which)
        {
            if (which == 1 || which == 2)
                return 1;

            ulong[] array = new ulong[which];
            array[0] = 1;
            array[1] = 1;

            return FibonacciNumberMemoization(which, array);
        }

        private static ulong FibonacciNumberMemoization(uint which, ulong[] array)
        {
            if (array[which - 3] == 0)
            {
                array[which - 3] = FibonacciNumberMemoization(which - 2, array);
            }

            if (array[which - 2] == 0)
            {
                array[which - 2] = FibonacciNumberMemoization(which - 1, array);
            }

            array[which - 1] = array[which - 3] + array[which - 2];
            return array[which - 1];
        }
    }
}
