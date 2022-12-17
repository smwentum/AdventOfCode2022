using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Tree
    {
        public int Height { get; set; }

        public bool LeftVisable { get; set; }
        public int MaxLeft { get; set; }

        public int LeftScenic { get; set; }

        public bool RightVisable { get; set; }

        public int MaxRight { get; set; }

        public int RightSenic { get; set; }

        public bool TopVisable { get; set; }

        public int MaxTop { get; set; }

        public int TopSenic { get; set; }

        public bool BottomVisable { get; set; }

        public int MaxBottom { get; set; }

        public int BottomSenic { get; set; }


        public Tree(int height)
        {
            Height = height;
            LeftVisable = false;
            MaxLeft = 0;
            RightVisable = false;
            MaxRight = 0;
            MaxTop = 0;
            TopVisable = false; 
            BottomVisable = false;
        }

        internal bool IsVisable()
        {
          return LeftVisable || RightVisable || TopVisable || BottomVisable; 
        }
    }
}
