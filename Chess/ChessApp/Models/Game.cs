using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Models
{
    public class Game
    {
        public readonly Board Board;
        public int SideToMove;
        public int HalfMoveClock;
        public int FullMoveCounter;
        public Square EnPassantTargetSquare;
    }
}
