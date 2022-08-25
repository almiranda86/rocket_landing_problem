using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLandingApp.Domain
{
    public sealed class Position
    {
        public int PositionX { get; set; }

        public int PositionY { get; set; }

        public bool Occupied { get; set; }

        public HashSet<Position> NearPositions { get; set; }

        public Position(int x, int y)
        {
            PositionX = x;
            PositionY = y;
            Occupied = false;
            NearPositions = new HashSet<Position>();    
        }
    }
}
