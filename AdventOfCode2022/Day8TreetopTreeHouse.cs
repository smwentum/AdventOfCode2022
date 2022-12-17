using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    /// <summary>
    /// idea: adjanceny matrix
    /// </summary>
    internal class Day8TreetopTreeHouse
    {

        public static string CountOfVisableTrees()
        {
            string fileName =   @"D:\Documents\random programming stuff\Advent of code\2022\AdventOfCode2022\AdventOfCode2022\Test Files\Day8Test.txt";
            List<string> lines = System.IO.File.ReadAllLines(fileName).ToList();
            Tree[][] trees = new Tree[lines.Count][];
            for (int i = 0; i < trees.Length; i++)
            {
                trees[i] = new Tree[lines[0].Length];
            }
            for (int i = 0; i < trees.Length; i++)
            {
                for (int j = 0; j < trees[0].Length; j++)
                {
                    trees[i][j] = new Tree(int.Parse(lines[i][j].ToString())); 
                }
            }

            MarkTreesVisableFromLeft(trees);
            MarkTreesVisableFromRight(trees);
            MarkTreesVisableFromTop(trees);
            MarkTreesVisableFromBottom(trees);
            int count = 0;
            for (int i = 0; i < trees.Length; i++)
            {
                for (int j = 0; j < trees[0].Length; j++)
                {
                    if (trees[i][j].IsVisable())
                    {
                        //Console.Write("V");
                        count++;
                    }
                    //else
                    //{
                    //    Console.Write("N");
                    //}

                }
                //Console.WriteLine();
            }


            return count.ToString();
        }

        public static string HeighestScenicScore()
        {
            string fileName = //@"D:\Documents\random programming stuff\Advent of code\2022\AdventOfCode2022\AdventOfCode2022\Test Files\Day8.txt";
            @"D:\Documents\random programming stuff\Advent of code\2022\AdventOfCode2022\AdventOfCode2022\Test Files\Day8Test.txt";
            List<string> lines = System.IO.File.ReadAllLines(fileName).ToList();
            Tree[][] trees = new Tree[lines.Count][];
            for (int i = 0; i < trees.Length; i++)
            {
                trees[i] = new Tree[lines[0].Length];
            }
            for (int i = 0; i < trees.Length; i++)
            {
                for (int j = 0; j < trees[0].Length; j++)
                {
                    trees[i][j] = new Tree(int.Parse(lines[i][j].ToString()));
                }
            }

            MarkTreesVisableFromLeft(trees);
            MarkTreesVisableFromRight(trees);
            MarkTreesVisableFromTop(trees);
            MarkTreesVisableFromBottom(trees);
            int count = 0;
            for (int i = 0; i < trees.Length; i++)
            {
                for (int j = 0; j < trees[0].Length; j++)
                {
                    if (trees[i][j].IsVisable())
                    {
                        //Console.Write("V");
                        count++;
                    }
                    //else
                    //{
                    //    Console.Write("N");
                    //}

                }
                //Console.WriteLine();
            }


            return count.ToString();
        }


        private static void MarkTreesVisableFromBottom(Tree[][] trees)
        {
            int rows = trees.Length;
            //bottom top row is top visable
            for (int i = 0; i < trees[0].Length; i++)
            {
                trees[rows-1][i].BottomVisable = true;
                trees[rows - 1][i].MaxBottom = trees[rows - 1][i].Height; 

                for (int j = 1; j < trees.Length; j++)
                {
                    if ( trees[rows-j ][i].MaxBottom < trees[rows-j-1][i].Height)
                    {
                        trees[rows - j - 1][i].BottomVisable = true;
                    }
                    trees[rows - j - 1][i].MaxBottom = Math.Max(trees[rows - j - 1][i].Height, trees[rows - j][i].MaxBottom);


                }
            }
        }

        private static void MarkTreesVisableFromTop(Tree[][] trees)
        {
            //first top row is top visable
            for (int i = 0; i < trees[0].Length; i++)
            {
                trees[0][i].TopVisable = true;
                trees[0][i].MaxTop = trees[0][i].Height;
                for (int j = 1; j < trees.Length; j++)
                {
                    if ( trees[j-1][i].MaxTop < trees[j][i].Height)
                    {
                        trees[j][i].TopVisable = true;
                    }
                    trees[j][i].MaxTop = Math.Max(trees[j][i].Height, trees[j - 1][i].MaxTop);
                }
            }
        }

        private static void MarkTreesVisableFromRight(Tree[][] trees)
        {
            int cols = trees[0].Length;
            //last col is right visable
            for (int i = 0; i < trees.Length; i++)
            {
                trees[i][cols-1].RightVisable = true;
                trees[i][cols - 1].MaxRight = trees[i][cols-1].Height;
                for (int j = cols-2; j >= 0; j--)
                {
                    if ( trees[i][j + 1].MaxRight < trees[i][j].Height)
                    {
                        trees[i][j].RightVisable = true;
                    }
                    trees[i][j].MaxRight = Math.Max(trees[i][j + 1].MaxRight, trees[i][j].Height);
                    
                }
            }
        }

        private static void MarkTreesVisableFromLeft(Tree[][] trees)
        {
            //first col is left visible
            for (int i = 0; i < trees.Length; i++)
            {
                trees[i][0].LeftVisable = true;
                trees[i][0].MaxLeft = trees[i][0].Height;
                trees[i][0].LeftScenic = 0; 
                for (int j = 1; j < trees.Length; j++)
                {
                    if (trees[i][j - 1].MaxLeft < trees[i][j].Height)
                    {
                        trees[i][j].LeftVisable = true;
                    }
                    trees[i][j].MaxLeft = Math.Max(trees[i][j].Height, trees[i][j - 1].MaxLeft);
                    int k = j - 1;
                    while (k >= 0)
                    {
                        trees[i][j].LeftScenic++;
                        if (trees[i][k].Height < trees[i][j].Height)
                        {
                            
                            k--;
                        }
                        else
                        {
                            break;
                        }
                        
                    }

                }
            }

            
        }
    }
}
