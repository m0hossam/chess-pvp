using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ChessEngine.Models
{
    public class Queen : Piece
    {
        public Queen(PieceColorEnum Color, PieceTypeEnum PieceType) : base(Color, PieceType)                
        {
            if (_pieceColor == PieceColorEnum.White)
            {
                PieceImage = "/ChessEngine;component/Resources/WhiteQueen.png";
            }
            else
            {
                PieceImage = "/ChessEngine;component/Resources/BlackQueen.png";
            }
        }

        public override Dictionary<string,string> GenerateLegalMoves(int Turn, int CurrentX, int CurrentY, 
            ObservableCollection<ObservableCollection<BoardSquare>> Board)
        {
            PieceColorEnum Color = Board[CurrentX][CurrentY].SquarePiece.PieceColor;
            Dictionary<string, string> Moves = new Dictionary<string, string>();
            Dictionary<string, string> BishopMoves;
            Dictionary<string, string> RookMoves;
            BishopMoves = PseudoLegalMoveGenerator.GenerateBishopMoves(CurrentX, CurrentY, Board);
            RookMoves = PseudoLegalMoveGenerator.GenerateRookMoves(CurrentX, CurrentY, Board);
            BishopMoves = LegalMoveGenerator.GenerateLegalMoves(BishopMoves, Board, Color);
            RookMoves = LegalMoveGenerator.GenerateLegalMoves(RookMoves, Board, Color);
            foreach (KeyValuePair<string, string> Pair in RookMoves)
            {
                Moves.Add(Pair.Key, Pair.Value);
            }
            foreach (KeyValuePair<string, string> Pair in BishopMoves)
            {
                Moves.Add(Pair.Key, Pair.Value);
            }
            return Moves;
        }
    }
}
