using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngine
{
    public static class MoveDecoder
    {
        public static int[] DecodeMove(string Move)
        {
            int[] Positions = new int[4];
            for (int i = 0; i < 4; i++)
            {
                Positions[i] = Move[i] - '0';
            }
            return Positions;
        }
    }
}
