using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day10CathodeRayTube
    {
        static long answer;
        public  static string EvaluteCylces()
        {

            try
            {
                answer = 0;

                long cycle = 1;
                long start = 1;
                //string[] lines =
                int timeToWait = 0;

                string fileName = //@"D:\Documents\random programming stuff\Advent of code\2022\AdventOfCode2022\AdventOfCode2022\Test Files\Day8.txt";
               @"D:\Documents\random programming stuff\Advent of code\2022\AdventOfCode2022\AdventOfCode2022\Test Files\Day10.txt";
                List<string> lines = System.IO.File.ReadAllLines(fileName).ToList();
                List<int> cyclesIWantTOSee = new List<int> { 19, 59, 99, 139, 179, 219 }; //{ 180, 220 };//{ 20, 60, 100, 140, 180, 220 };
                for (int i = 0; i < lines.Count; cycle++)
                {
                    //Console.WriteLine($"cycle: {cycle} val: {start}");
                    if (lines[i] == "noop")
                    {
                        i++;
                        // cycle--;
                        cycleIWantToSee(cycle, start, cyclesIWantTOSee, "*");
                        continue;
                    }
                    else
                    {
                        if (timeToWait == 0)
                        {
                            timeToWait = 1;
                        }
                        //else if (timeToWait == 2)
                        //{
                        //    timeToWait--;

                        //}
                        else
                        {
                            start += int.Parse(lines[i].Split(' ')[1]);
                            i++;
                            timeToWait--;
                        }
                        // start += int.Parse(lines[i].Split(' ')[1]);

                        if (i != 0&&i < lines.Count)
                        {
                            cycleIWantToSee(cycle, start, cyclesIWantTOSee,"**");
                        }
                    }

                }

                return answer.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private static void cycleIWantToSee(long cycle, long start, List<int> cyclesIWantTOSee, string lineI)
        {
            if (cyclesIWantTOSee.Any(m=>m == cycle) )
            {
                //Console.WriteLine($"cycle: {cycle} val: {start} {cycle * start} {lineI}");
                answer += (cycle+1) * start;
           }
        }
    }
}
