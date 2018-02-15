using System;

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
            int[] output = InsertionSort(input);
            Console.Write("Output is: ");
            for(int i = 0; i < output.Length; i++)
            {
                Console.Write(output[i].ToString() + ", ");
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
    }
}
