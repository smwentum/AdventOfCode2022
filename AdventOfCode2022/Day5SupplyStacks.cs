using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day5SupplyStacks
    {
        public static string Day5Part1()
        {
            List<string> lines = File.ReadAllLines(@"D:\Documents\random programming stuff\Advent of code\2022\AdventOfCode2022\AdventOfCode2022\Test files\Day5.txt").ToList();
            List<Day5StackMoves> moves = new List<Day5StackMoves>();
            Stack<char>[] boxes = new Stack<char>[0];
            string answer = "";
            //going to use a little hack the line i need is the blank one so 
            for (int i = 0; i < lines.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    moves = GetMoves(lines.GetRange(i + 1, lines.Count - 1 - i));
                    boxes = GetStartingConfig(lines.GetRange(0, i ));
                    break;
                    
                }
            }

            foreach (Day5StackMoves move in moves)
            {
                for (int i = 0; i < move.NumberOfBoxesToMove; i++)
                {
                    boxes[move.ToIndex].Push(boxes[move.FromIndex].Pop());
                 }
            }
            for (int i = 0; i < boxes.Length; i++)
            {
                if (boxes[i].Count > 0)
                {
                    answer += boxes[i].Peek().ToString();
                }
                else
                {
                    answer += "";
                }
            }

            return answer;
        }

        public static string Day5Part2()
        {
            List<string> lines = File.ReadAllLines(@"D:\Documents\random programming stuff\Advent of code\2022\AdventOfCode2022\AdventOfCode2022\Test files\Day5.txt").ToList();
            List<Day5StackMoves> moves = new List<Day5StackMoves>();
            Stack<char>[] boxes = new Stack<char>[0];
            string answer = "";
            //going to use a little hack the line i need is the blank one so 
            for (int i = 0; i < lines.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    moves = GetMoves(lines.GetRange(i + 1, lines.Count - 1 - i));
                    boxes = GetStartingConfig(lines.GetRange(0, i));
                    break;

                }
            }
            Stack<char> holder = new Stack<char>();
            foreach (Day5StackMoves move in moves)
            {
                holder = new Stack<char>(); 
                for (int i = 0; i < move.NumberOfBoxesToMove; i++)
                {
                    holder.Push(boxes[move.FromIndex].Pop());
                }
                while (holder.Count > 0)
                {
                    boxes[move.ToIndex].Push(holder.Pop());
                }
            }
           
            for (int i = 0; i < boxes.Length; i++)
            {
                if (boxes[i].Count > 0)
                {
                    answer += boxes[i].Peek().ToString();
                }
                else
                {
                    answer += "";
                }
            }

            return answer;
        }

        private static Stack<char>[] GetStartingConfig(List<string> list)
        {
            list.Reverse();
            string[] rows = list[0].Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int colCount = int.Parse(rows[rows.Length - 1].ToString());
            Stack<char>[] stacks = new Stack<char>[colCount];
            for (int i = 0;i <  stacks.Length;i++)
            {
                stacks[i] = new Stack<char>();
            }
            for (int j = 1; j < list.Count; j++)
            {
                for (int i = 1; i < list[0].Length; i += 4)
                {
                    if (char.IsLetter(list[j][i]))
                    {
                        stacks[(i-1)/4].Push(list[j][i]);
                    }
                }
            }
            return stacks;
        }

        private static List<Day5StackMoves> GetMoves(List<string> list)
        {
            List<Day5StackMoves> moves = new List<Day5StackMoves>() ;
            
            foreach (string line in list)
            {
                moves.Add( GetMove(line));
            }
            return moves;
        }

        private static Day5StackMoves GetMove(string line)
        {
            Day5StackMoves move = new Day5StackMoves();
            string[] tokens = line.Split(' ');
            move.NumberOfBoxesToMove = int.Parse(tokens[1]);
            move.FromIndex = int.Parse(tokens[3])-1;
            move.ToIndex = int.Parse(tokens[5])-1;
            return move; 
        }
    }
}
