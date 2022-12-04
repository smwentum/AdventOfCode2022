using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day2RockPaperSizors
    {

        #region part 1: 

        public static string part1GetFile(string fileName)
        {
            List<string> lines = File.ReadLines(fileName).ToList();
            int answer = 0;

            foreach (string line in lines)
            {
                string[] moves = line.Split(' ');
                RockPaperScissors opponent = GetMoves(moves[0]);
                RockPaperScissors player = GetMoves(moves[1]);
                answer += GetScore(opponent, player);

            }

            return answer.ToString();
        }

        private static int GetScore(RockPaperScissors opponent, RockPaperScissors player)
        {
            int answer = 0;
            answer = getPlayerMoveScore(player, answer);
            answer += getRoundOutcome(opponent, player);
            return answer;
        }

        private static int getRoundOutcome(RockPaperScissors opponent, RockPaperScissors player)
        {
           
            //tie 
            if (opponent == player)
            {
                return 3;
            }
            //lost
            if (opponent == RockPaperScissors.Rock && player == RockPaperScissors.Scissors
                || opponent == RockPaperScissors.Scissors && player == RockPaperScissors.Paper
               ||   opponent == RockPaperScissors.Paper && player == RockPaperScissors.Rock)
            {
                return 0;
            }
            //win
            return 6; 
        }

        private static int getPlayerMoveScore(RockPaperScissors player, int answer)
        {
            switch (player)
            {
                case RockPaperScissors.Rock:
                    answer += 1;
                    break;
                case RockPaperScissors.Paper:
                    answer += 2;
                    break;
                case RockPaperScissors.Scissors:
                    answer += 3;
                    break;

            }

            return answer;
        }

        private static RockPaperScissors GetMoves(string v)
        {
            if (v == "A" || v == "X")
            {
                return RockPaperScissors.Rock;

            }
            else if (v == "B" || v == "Y")
            {
                return RockPaperScissors.Paper;
            }
            return RockPaperScissors.Scissors;
        }

        #endregion

    }
}
