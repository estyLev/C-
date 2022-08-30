using System;
using System.Collections.Generic;
using System.Text;

namespace week2
{
    public class Box
    {
        public double hight { get; set; }
        public double width { get; set; }
        public double depth { get; set; }

        public Box(double hight, double width, double depth)
        {
            this.hight = hight;
            this.width = width;
            this.depth = depth;
        }

        public override bool Equals(object obj)
        {
            return obj is Box box &&
                   hight == box.hight &&
                   width == box.width &&
                   depth == box.depth;
        }
    }
}
