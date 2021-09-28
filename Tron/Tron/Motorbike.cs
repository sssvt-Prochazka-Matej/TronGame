using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tron
{
    public class Motorbike
    {
        public int Velocity { get; set; }

        public int Score { get; set; }

        public Direction Direction { get; set; }

        public Motorbike(Direction direction)
        {
            Velocity = 4;
            Score = 0;
            Direction = direction;
        }

    }
}
