using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Models
{
    public class Piece
    {
        public readonly PieceType Type;
        public readonly PieceColor Color;

        public Piece(PieceType type, PieceColor color)
        {
            Type = type;
            Color = color;
        }
    }
}
