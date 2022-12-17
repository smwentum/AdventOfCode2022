using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Folder
    {
        public string Name { get; set; }
        public List<Folder> SubDirectoreis { get; set; }
        public long FileSize { get; set; }

        public long TotalSize { get; set; }

        public Folder Parent { get; set; }

        public Folder()
        {

        }

        public Folder(string name)
        {
            Name = name;
            SubDirectoreis = new List<Folder>();
            FileSize = 0; 
        }

        public Folder(string name, Folder parent):this(name)
        {
            Parent = parent;
        }

        public long getCurrentSize(Folder folder)
        {
            folder.TotalSize = folder.FileSize;
            foreach (Folder f in folder.SubDirectoreis)
            {
                folder.TotalSize += getCurrentSize(f);
            }
            return folder.TotalSize; 
        }

        public long getSizeLessThanMax(long maxSize)
        {
            
            long childSize = SubDirectoreis.Select(m => m.getSizeLessThanMax(maxSize)).Sum();
            if (TotalSize <= maxSize)
            {
                childSize += TotalSize; 
            }
            return childSize;
        }
    }
}
