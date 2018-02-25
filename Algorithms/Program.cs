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
            for (int i = 0; i < input.Length; i++)
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
            for (int i = 0; i < input.Length; i++)
            {
                if (i + 1 != input.Length)
                {
                    if (input[i] > input[i + 1])
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

        public static void QuickSort(int[] input) => QuickSort(input, 0, input.Length - 1);

        public static void QuickSort(int[] input, int leftIndex, int rightIndex)
        {
            if (leftIndex <= rightIndex)
            {
                int pivotIndex = Partition(input, leftIndex, rightIndex);
                QuickSort(input, leftIndex, pivotIndex - 1);
                QuickSort(input, pivotIndex + 1, rightIndex);
            }
        }

        public static int Partition(int[] input, int leftIndex, int rightIndex)
        {
            int pivotValue = input[rightIndex];

            int leftSwap = leftIndex - 1;
            for (int rightSwap = leftIndex; rightSwap <= rightIndex; rightSwap++)
            {
                if (input[rightSwap] <= pivotValue)
                {
                    if (leftSwap != rightSwap)
                    {
                        leftSwap++;
                        int temp = input[leftSwap];
                        input[leftSwap] = input[rightSwap];
                        input[rightSwap] = temp;
                    }
                }
            }

            return leftSwap;
        }

        public static int FindLargest(int[][] matrix, int range)
        {
            int highest = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; i++)
                {
                    int[] values = new int[4] { 0, 0, 0, 0 };

                    values[0] = 1;
                    foreach (int k in Enumerable.Range(j, j + range))
                    {
                        if (k <= matrix[i].Length)
                            values[0] = values[0] * matrix[i][k];
                    }

                    values[1] = 1;
                    foreach (int k in Enumerable.Range(j, j + range))
                    {
                        if (k <= matrix[i].Length)
                        {
                            foreach (int l in Enumerable.Range(i, i + range))
                            {
                                if (l <= matrix.Length)
                                {
                                    values[1] = values[1] * matrix[l][k];
                                }
                            }

                            values[2] = values[2] * matrix[i][k];

                            foreach (int m in Enumerable.Range(i - range, range))
                            {
                                if (m <= matrix.Length)
                                {
                                    values[3] = values[3] * matrix[m][k];
                                }
                            }
                        }
                    }

                    if (values[0] > highest)
                    {
                        highest = values[0];
                    }

                    if (values[1] > highest)
                    {
                        highest = values[1];
                    }

                    if (values[2] > highest)
                    {
                        highest = values[2];
                    }

                    if (values[3] > highest)
                    {
                        highest = values[3];
                    }
                }
            }

            return highest;
        }
    }
}