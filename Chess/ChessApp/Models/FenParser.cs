using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Models
{
    public static class FenParser
    {
        private static readonly Dictionary<char, PieceType> charPieceType = new Dictionary<char, PieceType>();
        private static readonly Dictionary<char, PieceColor> charPieceColor = new Dictionary<char, PieceColor>();
        static FenParser()
        {
            charPieceType = new Dictionary<char, PieceType>();
            charPieceColor = new Dictionary<char, PieceColor>();

            string pieceChars = "PKBRQKpkbrqk";
            for (int i = 0; i < pieceChars.Length; i++)
            {
                charPieceType[pieceChars[i]] = (PieceType)(i % 6);
                charPieceColor[pieceChars[i]] = (PieceColor)(i / 6);
            }
        }

        public static void ParseFen(string fen, ulong[] bitboards)
        {
            string[] parts = fen.Split(' ');
        }
    }
}
