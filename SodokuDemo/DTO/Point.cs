using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodokuDemo.data
{
    class Point
    {
        //point[y,x] dong y cot x
        public int Y { get; set; }
        public int X { get; set; }
        
        public Point(int y, int x)
        {
            this.Y = y;
            this.X = x;
        }
    }
}
