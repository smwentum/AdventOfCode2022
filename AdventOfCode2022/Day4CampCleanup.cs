using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day4CampCleanup
    {
        public static int GetPart1()
        {
            List<string> lines = File.ReadAllLines(@"D:\Documents\random programming stuff\Advent of code\2022\AdventOfCode2022\AdventOfCode2022\Test files\Day4.txt").ToList();
            int count = 0;
            foreach (string line in lines)
            {
                SectionInterval assigmentPair = GetAssigment(line.Split(',')[0]);
                SectionInterval assigmentPair1 = GetAssigment(line.Split(',')[1]);

                if (AssigmentContainment(assigmentPair, assigmentPair1))
                {
                    count++; 
                }

            }
            return count;
        }

        public static int GetPart2()
        {
            List<string> lines = File.ReadAllLines(@"D:\Documents\random programming stuff\Advent of code\2022\AdventOfCode2022\AdventOfCode2022\Test files\Day4.txt").ToList();
            int count = 0;
            foreach (string line in lines)
            {
                SectionInterval assigmentPair = GetAssigment(line.Split(',')[0]);
                SectionInterval assigmentPair1 = GetAssigment(line.Split(',')[1]);

                if (AssigmentOverlap(assigmentPair, assigmentPair1))
                {
                    count++;
                }

            }
            return count;
        }

        private static bool AssigmentOverlap(SectionInterval assigmentPair1, SectionInterval assigmentPair2)
        {
            return Overlap(assigmentPair1, assigmentPair2)
            || Overlap(assigmentPair2, assigmentPair1);
        }

        private static bool Overlap(SectionInterval assigmentPair1, SectionInterval assigmentPair2)
        {
            return (assigmentPair1.Beginning <= assigmentPair2.Beginning
                    && assigmentPair2.Beginning <= assigmentPair1.Ending)
                    || (assigmentPair1.Beginning <= assigmentPair2.Ending
                    && assigmentPair2.Ending <= assigmentPair1.Ending);

        }

        private static SectionInterval GetAssigment(string v)
        {
            string[] lines = v.Split( '-' );
            SectionInterval assigment = new SectionInterval();
            assigment.Beginning = int.Parse(lines[0]);
            assigment.Ending = int.Parse(lines[1]);
            return assigment;
        }

        private static bool AssigmentContainment(SectionInterval assigmentPair, SectionInterval assigmentPair1)
        {
            return AssigmentContains(assigmentPair, assigmentPair1)
                    || AssigmentContains(assigmentPair1, assigmentPair);
        }

        private static bool AssigmentContains(SectionInterval assigmentPair1, SectionInterval assigmentPair2)
        {
            return assigmentPair1.Beginning <= assigmentPair2.Beginning
                && assigmentPair1.Ending >= assigmentPair2.Ending;           
        }
    }
}
