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
        private static readonly Dictionary<char, int> charPieceType;
        private static readonly Dictionary<char, int> charPieceColor;
        static FenParser()
        {
            charPieceType = new Dictionary<char, int>();
            charPieceColor = new Dictionary<char, int>();

            string pieceChars = "PNBRQKpnbrqk";
            for (int i = 0; i < pieceChars.Length; i++)
            {
                charPieceType[pieceChars[i]] = i % 6;
                charPieceColor[pieceChars[i]] = i / 6;
            }
        }

        public static void SetupPieces(string piecePlacement, ulong[] bitboards)
        {
            int rank = 7;
            int file = 0;
            for (int i = 0; i < piecePlacement.Length; i++)
            {
                if (piecePlacement[i] >= '1' && piecePlacement[i] <= '8')
                {
                    file += piecePlacement[i] - '1';
                }
                else if (piecePlacement[i] == '/')
                {
                    rank--;
                    file = 0;
                }
                else
                {
                    char c = piecePlacement[i];
                    int bitboardIndex = charPieceType[c] + 6 * charPieceColor[c];
                    BitboardHelper.SetBit(ref bitboards[bitboardIndex], rank, file);
                    file++;
                }
            }
        }

        public static void SetupSideToPlay()
        {

        }

        public static void SetupCastlingRights()
        {

        }

        public static void SetupEnPassantSquare()
        {

        }

        public static void SetupHalfMoveClock()
        {

        }

        public static void SetupFullMoveCounter()
        {

        }

        public static void ParseFen(string fen, ulong[] bitboards)
        {
            string[] parts = fen.Split(' ');
            SetupPieces(parts[0], bitboards);

        }
    }
}
