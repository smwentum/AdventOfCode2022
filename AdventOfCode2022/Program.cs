using System;

namespace AdventOfCode2022 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            problem1part1();
            problem1part2();
        }

        private static void problem1part1()
        {
            long max = 0;
            long sum = 0;
            int index = 1;
            List<long> arr = new List<long>();
            string[] lines = File.ReadLines(@"D:\Documents\random programming stuff\Advent of code\2022\AdventOfCode2022\AdventOfCode2022\Test files\problem1a.txt").ToArray();
            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {

                    arr.Add(max);
                    sum = 0;
                    index++;
                    max = 0;
                    continue;
                }
                else
                {
                    sum += long.Parse(line);
                }
                max = Math.Max(max, sum);
            }
            arr.Add(max);

            Console.WriteLine($"Problem 1 answer 1: {arr.Max()}");
        }

        private static void problem1part2()
        {
            long max = 0;
            long sum = 0;
           
            List<long> arr = new List<long>();
            string[] lines = File.ReadLines(@"D:\Documents\random programming stuff\Advent of code\2022\AdventOfCode2022\AdventOfCode2022\Test files\problem1b.txt").ToArray();
            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                   // Console.WriteLine(max);
                    arr.Add(max);
                    sum = 0;
                    max = 0;
                }
                else
                {
                    sum += long.Parse(line);
                }
                max = Math.Max(max, sum);
            }
            arr.Add(max);
            arr.Sort();

            int len = arr.Count - 1;
            Console.WriteLine($"Problem 1 answer 2: {arr[len]+ arr[len - 1]+ arr[len - 2]}");
        }
    }
}