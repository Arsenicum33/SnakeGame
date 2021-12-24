using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame__TODO_ML_
{
    class Field
    {
        public readonly int X;
        public readonly int Y;
        public Field()
        {
            X = 0;
            Y = 0;
        }
        public Field(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
