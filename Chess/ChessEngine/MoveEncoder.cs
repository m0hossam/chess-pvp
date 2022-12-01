using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngine
{
    public static class MoveEncoder
    {
        public static string EncodeMove(int X1, int Y1, int X2, int Y2)
        {
            string Move = X1.ToString() + Y1.ToString() + X2.ToString() + Y2.ToString();
            return Move;
        }
    }
}
