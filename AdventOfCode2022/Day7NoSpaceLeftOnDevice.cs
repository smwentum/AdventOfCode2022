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
        public static Folder Directory   { get; set; }
        public static string GetFolderSizeCount()
        {
            List<string> lines = //File.ReadAllLines(@"D:\Documents\random programming stuff\Advent of code\2022\AdventOfCode2022\AdventOfCode2022\Test files\Day7Pt1Test.txt").ToList();
                                File.ReadAllLines(@"D:\Documents\random programming stuff\Advent of code\2022\AdventOfCode2022\AdventOfCode2022\Test files\Day7.txt").ToList();

            Directory = new Folder("\\");
            Folder currentDirectory = Directory;

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
                            currentDirectory = Directory;
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
            Directory.getCurrentSize(Directory);
            return Directory.getSizeLessThanMax(100000).ToString();
            
        }

        public static string FindFileToDelete()
        {
            GetFolderSizeCount();
            long totalUsedSpace = Directory.TotalSize;
            long totalSpaceNeeded = 30000000; // comes from problem description 
            long minSizeToDelete = totalSpaceNeeded - (70000000- totalUsedSpace);
            List<Folder> listOfDirectories = GetAllDirectoreis(Directory);
            listOfDirectories.RemoveAll(m => m.TotalSize < minSizeToDelete);
            return listOfDirectories.OrderBy(m => m.TotalSize).First().TotalSize.ToString();

            //return listOfDirectories[0].TotalSize.ToString();
        }

        private static List<Folder> GetAllDirectoreis(Folder directory)
        {
            List<Folder> folders = new List<Folder>();

            foreach (Folder f in directory.SubDirectoreis)
            {
                folders.AddRange(GetAllDirectoreis(f));
            }
            folders.Add(directory);


            return folders; 
        }
    }
}
