using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day3RucksackReorganization
    {
        

        public static int GetPart1Answer()
        {
            List<string> rucksacks = File.ReadAllLines(@"D:\Documents\random programming stuff\Advent of code\2022\AdventOfCode2022\AdventOfCode2022\Test files\Day3.txt").ToList();

            int answer = 0;
            foreach (string rucksack in rucksacks) 
            {
                answer += GetPriorityFromString(rucksack);
            }
            return answer; 
        }

        public static int GetPart2Answer()
        {
            List<string> rucksacks = File.ReadAllLines(@"D:\Documents\random programming stuff\Advent of code\2022\AdventOfCode2022\AdventOfCode2022\Test files\Day3.txt").ToList();

            int answer = 0;
            for (int i = 0; i < rucksacks.Count; i += 3)
            {
                bool[] commonLetter1 = GetCommonLetterString(rucksacks[i]);
                bool[] commonLetter2 = GetCommonLetterString(rucksacks[i+1]);
                bool[] commonLetter3 = GetCommonLetterString(rucksacks[i+2]);
                for (int j = 0; j < commonLetter1.Length; j++)
                {
                    if (commonLetter1[j] && commonLetter2[j] && commonLetter3[j])
                    {
                       answer += j + 1;
                        break;
                    }
                }
            }
            return answer;
        }

        private static int GetPriorityFromString(string rucksack)
        {
            string compartment1 = rucksack.Substring(0, rucksack.Length / 2);
            string compartment2 = rucksack.Substring(rucksack.Length / 2);

            bool[] commonLetter1 = GetCommonLetterString(compartment1);
            bool[] commonLetter2 = GetCommonLetterString(compartment2);
            for (int i = 0; i < commonLetter1.Length; i++)
            {
                if (commonLetter1[i] && commonLetter1[i] == commonLetter2[i])
                {
                    return i + 1; 
                }
            }
            return 1; 
        }

        private static bool[] GetCommonLetterString(string compartment1)
        {
            bool[] arr = new bool[52];
            for (int i = 0; i < compartment1.Length; i++)
            {
                if (char.IsLower(compartment1[i]))
                {
                    arr[compartment1[i] - 'a'] = true;
                }
                else
                {
                    arr[compartment1[i] - 'A' + 26] = true ;
                }
            }
            return arr; 
            
        }
    }
}
