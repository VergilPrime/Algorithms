using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine();
            int[] radixarray = new int[]{
                123,1323,513,123,753,135,7312,53,1,63,64,24,74,134,134,6432,134,672,724,341,63,35,5,6,31
            };
            for (int i = 0; i < radixarray.Length; i++)
            {
                if (i > 0) Console.Write(", ");
                Console.Write(radixarray[i]);
            }
            Console.WriteLine();
            RadixSort(radixarray, 4);
            for (int i = 0; i < radixarray.Length; i++)
            {
                if (i > 0) Console.Write(", ");
                Console.Write(radixarray[i]);
            }
            Console.WriteLine();
            Console.ReadLine();
        }
        public static void RadixSort(int[] input, int digits)
        {
            int max = Int32.MinValue;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > max) max = input[i];
            }

            Queue<int>[] sortbox = new Queue<int>[]{
                new Queue<int>(),
                new Queue<int>(),
                new Queue<int>(),
                new Queue<int>(),
                new Queue<int>(),
                new Queue<int>(),
                new Queue<int>(),
                new Queue<int>(),
                new Queue<int>(),
                new Queue<int>()
            };

            Queue<int> sortlist = new Queue<int>();
            foreach (int val in input)
            {
                sortlist.Enqueue(val);
            }

            bool done = false;
            int m = 10;
            int n = 1;

            while(max / n > 0)
            {

                while (sortlist.Count > 0)
                {
                    int val = sortlist.Dequeue();
                    int column = val % m / n;
                    sortbox[column].Enqueue(val);
                }

                for (int i = 0; i < sortbox.Length; i++)
                {
                    while (sortbox[i].Count > 0)
                    {
                        sortlist.Enqueue(sortbox[i].Dequeue());
                    }
                }

                m *= 10;
                n *= 10;
            }

            for (int i = 0; i < input.Length; i++)
            {
                input[i] = sortlist.Dequeue();
            }

        }
    }
}
