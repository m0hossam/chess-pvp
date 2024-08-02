using ChessApp.Models;

namespace ModelsUnitTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pieceChars = "PNBRQKpnbrqk";
            Dictionary<char, PieceType> charPieceType = new Dictionary<char, PieceType>();
            Dictionary<char, PieceColor> charPieceColor = new Dictionary<char, PieceColor>();
            for (int i = 0; i < pieceChars.Length; i++)
            {
                charPieceType[pieceChars[i]] = (PieceType)(i % 6);
                charPieceColor[pieceChars[i]] = (PieceColor)(i / 6);
            }
            for (int i = 0; i < pieceChars.Length; i++)
            {
                Console.WriteLine(pieceChars[i] + " -> " + charPieceColor[pieceChars[i]] + " " + charPieceType[pieceChars[i]]);
            }
        }
    }
}
