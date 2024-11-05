using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyTestTask.Extensions
{
    public struct SizeParam
    {
        public SizeParam(float height, float width, float depth)
        {
            Height = height;
            Width = width;
            Depth = depth;
        }

        public float Height { get; set; }
        public float Width { get; set; }
        public float Depth { get; set; }
    }
}
