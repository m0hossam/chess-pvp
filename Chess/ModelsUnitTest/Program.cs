using ChessApp.Models;

namespace ModelsUnitTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ulong[] bitboards = new ulong[12];
            string piecePlacement = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";
            FenParser.SetupPieces(piecePlacement, bitboards);
            for (int i = 0; i < bitboards.Length; i++)
            {
                Console.WriteLine($"{(PieceColor)(i / 6)} {(PieceType)(i % 6)} Bitboard");
                for (int rank = 7; rank >= 0; rank--)
                {
                    for (int file = 0; file < 8; file++)
                    {
                        Console.Write(BitboardHelper.GetBit(bitboards[i], rank, file));
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
