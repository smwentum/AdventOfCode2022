using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    /// <summary>
    /// Sliding Window
    /// </summary>
    internal class Day6TuningTrouble
    {
        public static string Day6Part1()
        {
            string s = File.ReadAllLines(@"D:\Documents\random programming stuff\Advent of code\2022\AdventOfCode2022\AdventOfCode2022\Test files\Day6.txt")[0];
            int[] charCount = new int[26];
            int currentIndex = 0;
            for (currentIndex = 0; currentIndex < 4; currentIndex++)
            {
                charCount[s[currentIndex] - 'a']++;
            }
            while (!IsStartOfPacketMarker(charCount))
            {
                charCount[s[currentIndex - 4] - 'a']--;
                charCount[s[currentIndex] - 'a']++;
                currentIndex++;
                
            }
            return currentIndex.ToString();
            
        }

        public static string Day6Part2()
        {
            string s = File.ReadAllLines(@"D:\Documents\random programming stuff\Advent of code\2022\AdventOfCode2022\AdventOfCode2022\Test files\Day6.txt")[0];
            int[] charCount = new int[26];
            int currentIndex = 0;
            int distinctLength = 14; 
            for (currentIndex = 0; currentIndex < distinctLength; currentIndex++)
            {
                charCount[s[currentIndex] - 'a']++;
            }
            while (!IsStartOfPacketMarker(charCount))
            {
                charCount[s[currentIndex - distinctLength] - 'a']--;
                charCount[s[currentIndex] - 'a']++;
                currentIndex++;

            }
            return currentIndex.ToString();

        }

        private static bool IsStartOfPacketMarker(int[] charCount)
        {
            for (int i = 0; i < charCount.Length; i++)
            {
                if (charCount[i] != 0 && charCount[i] != 1)
                {
                    return false; 
                }
            }
            return true;
        }
    }
}
