using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perplexity
{
    class Player
    {
        public Coordinate PlayerPos { get; set; }

        public Player(Coordinate startPos)
        {
            PlayerPos = startPos;
        }
    }
}
