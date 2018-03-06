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
            Console.WriteLine(CountPaths(5, 6));
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

        public static void MergeSort(int[] input)
        {
            if(input.Length > 2)
            {
                int split = input.Length / 2;
                int[] left = new int[split];
                int[] right = new int[input.Length - split];
                for (int i = 0; i < split; i++)
                {
                    left[i] = input[i];
                }

                for (int j = split; j < input.Length; j++)
                {
                    right[j - split] = input[j];
                }

                MergeSort(left);
                MergeSort(right);

                int leftindex = 0;
                int rightindex = 0;

                for (int i = 0; i < input.Length; i++)
                {
                    if(leftindex < left.Length && rightindex < right.Length)
                    {
                        if(left[leftindex] < right[rightindex])
                        {
                            input[i] = left[leftindex];
                            leftindex++;
                        }
                        else
                        {
                            input[i] = right[rightindex];
                            rightindex++;
                        }
                    }
                    else if(leftindex < left.Length && rightindex >= right.Length)
                    {
                        input[i] = left[leftindex];
                        leftindex++;
                    }
                    else if(rightindex < right.Length && leftindex >= left.Length)
                    {
                        input[i] = right[rightindex];
                        rightindex++;
                    }
                    else if(leftindex >= left.Length && rightindex >= right.Length)
                    {
                        Console.Write("Something went terribly wrong.");
                    }
                }

            }else if(input.Length == 2)
            {
                if(input[0] > input[1])
                {
                    int temp = input[0];
                    input[0] = input[1];
                    input[1] = temp;
                }
            }
        }

        public static void RadixSort(int[] input)
        {
            Queue<int> All = new Queue<int>();

            List<Queue<int>> Queues = new List<Queue<int>>(){
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

            int m = 10;
            int n = 1;
            int maxdigits = 1;

            for (int i = 0; i < input.Length; i++)
            {
                int val = input[i];

                int digits = val.ToString().Count();

                if (digits > maxdigits) maxdigits = digits;
            }

            for (int i = 0; i < maxdigits; i++)
            {
                Console.WriteLine($"Digit {i + 1}");
                for (int j = 0; j < input.Length; j++)
                {
                    int val = input[j];

                    int sortinto = val % m / n;

                    Console.WriteLine($"Sorting {val} into Queues[{sortinto}].");
                    Queues[sortinto].Enqueue(val);
                }

                for(int j = 0; j < Queues.Count; j++)
                {
                    Console.WriteLine($"Queues[{j}] has {Queues[j].Count} values");
                    while (Queues[j].Count > 0)
                    {
                        Console.WriteLine($"Moving value from Queues[{j}] to 'All'");
                        All.Enqueue(Queues[j].Dequeue());
                    }
                }

                n = n * 10;
                m = m * 10;

                input = All.ToArray();

                Console.WriteLine();
                Console.WriteLine(All.Count);
                Console.WriteLine();

                All = new Queue<int>();
            }

        }



        public static int CountPaths(int x, int y)
        {
            int xpaths = 0;
            int ypaths = 0;
            if(x == 1 && y == 1)
            {
                return 1;

            }
            else
            {
                if( x > 1)
                {
                    xpaths = CountPaths(x - 1, y);
                }
                
                if( y > 1)
                {
                    ypaths = CountPaths(x, y - 1);
                }

                return xpaths + ypaths;
            }
        }
    }
}