using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine();
            int[] input = new int[] { 56, 32, 41, 66, 23, 1016, 41, 12 };
            Console.WriteLine("Input is: ' 56, 32, 41, 66, 23, 1016, 41, 12 '");
            Console.WriteLine("");
            QuickSort(input);
            Console.Write("Output is: ");
            for(int i = 0; i < input.Length; i++)
            {
                Console.Write(input[i].ToString() + ", ");
            }
            Console.ReadLine();
        }

        public static int[] SelectionSort(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[j] < input[i])
                    {
                        int k = input[j];
                        input[j] = input[i];
                        input[i] = k;
                    }
                }
            }
            return input;
        }

        public static int[] InsertionSort(int[] input)
        {
            for(int i = 0; i < input.Length; i++)
            {
                if(i + 1 != input.Length)
                {
                    if(input[i] > input[i + 1])
                    {
                        for (int j = i + 1; j > 0; j--)
                        {
                            if (input[j] < input[j - 1])
                            {
                                int k = input[j];
                                input[j] = input[j - 1];
                                input[j - 1] = k;
                            }
                        }
                    }
                }
            }
            return input;
        }

        public static int[] QuickSort(int[] input)
        {
            return QuickSort(input, 0, input.Length - 1);
        }

        public static int[] QuickSort(int[] input, int leftIndex, int rightIndex)
        {
            if(leftIndex <= rightIndex)
            {
                int pivotIndex = Partition(input, leftIndex, rightIndex);
                input = QuickSort(input, leftIndex, pivotIndex - 1);
                input = QuickSort(input, pivotIndex + 1, rightIndex);
            }

            return input;
        }

        public static int Partition(int[] input, int leftIndex, int rightIndex)
        {
            int pivotValue = input[rightIndex];

            int leftSwap = leftIndex - 1;
            for(int rightSwap = leftIndex; rightSwap <= rightIndex; rightSwap++)
            {
                if(rightSwap <= pivotValue){
                    leftSwap++;
                    int temp = input[leftSwap];
                    input[leftSwap] = input[rightSwap];
                    input[rightSwap] = temp;
                }

                return rightSwap;
            }

            return 0;
        }
    }
}