using System;

namespace AdventOfCode2022 // Note: actual namespace depends on the project name.
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                problem1part1();
                problem1part2();
                Console.WriteLine($"Day 2 part 1: {Day2RockPaperScissors.part1GetFile(@"D:\Documents\random programming stuff\Advent of code\2022\AdventOfCode2022\AdventOfCode2022\Test files\Day2.txt")}");
                Console.WriteLine($"Day 2 part 2: {Day2RockPaperScissors.part2GetFile(@"D:\Documents\random programming stuff\Advent of code\2022\AdventOfCode2022\AdventOfCode2022\Test files\Day2.txt")}");
                Console.WriteLine($"Day 3 part 1: {Day3RucksackReorganization.GetPart1Answer()}");
                Console.WriteLine($"Day 3 part 2: {Day3RucksackReorganization.GetPart2Answer()}");
                Console.WriteLine($"Day 4 part 1: {Day4CampCleanup.GetPart1()}");
                Console.WriteLine($"Day 4 part 2: {Day4CampCleanup.GetPart2()}");
                Console.WriteLine($"Day 5 part 1: {Day5SupplyStacks.Day5Part1()}");
                Console.WriteLine($"Day 5 part 2: {Day5SupplyStacks.Day5Part2()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
             
            }
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