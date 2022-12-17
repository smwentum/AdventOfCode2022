using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    //Graph maybe
    internal class Day7NoSpaceLeftOnDevice
    {
        public static string GetFolderSizeCount()
        {
            List<string> lines = File.ReadAllLines(@"D:\Documents\random programming stuff\Advent of code\2022\AdventOfCode2022\AdventOfCode2022\Test files\Day7.txt").ToList();

            Folder directory = new Folder("\\");
            Folder currentDirectory = directory;

            for (int i = 1; i < lines.Count; i++)
            {
                
                if (lines[i].StartsWith('$'))
                {
                    string[] cmd = lines[i].Split(' ');
                    if (cmd[1] == "ls")
                    {
                        //do nothing for right now
                    }
                    else if (cmd[1] == "cd")
                    {
                        if (cmd[2] == "..")
                        {
                            currentDirectory = currentDirectory.Parent;
                        }
                        else if (cmd[2] == "/")
                        {
                            currentDirectory = directory;
                        }
                        else
                        {
                            currentDirectory = currentDirectory.SubDirectoreis.First(m => m.Name == cmd[2]);
                        }

                    }
                }
                else
                {
                    //this is assuming it's a folder
                    if (lines[i].StartsWith("dir"))
                    {
                        currentDirectory.SubDirectoreis.Add(new Folder(lines[i].Split(' ')[1], currentDirectory));
                    }
                    else
                    {
                        currentDirectory.FileSize += long.Parse(lines[i].Split(' ')[0]);
                    }
                }
            }
            directory.getCurrentSize(directory);
            return directory.getSizeLessThanMax(100000).ToString();
            
        }

    }
}
