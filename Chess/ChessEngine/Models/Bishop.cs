using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ChessEngine.Models
{
    public class Bishop : Piece
    {
        public Bishop(PieceColorEnum Color) : base(Color)
        {
            _pieceType = PieceTypeEnum.Bishop;
            if (_pieceColor == PieceColorEnum.White)
            {
                PieceImage = "/ChessEngine;component/Resources/WhiteBishop.png";
            }
            else
            {
                PieceImage = "/ChessEngine;component/Resources/BlackBishop.png";
            }
        }

        public override Dictionary<string,string> GenerateLegalMoves(int Turn, int CurrentX, int CurrentY, 
            ObservableCollection<ObservableCollection<BoardSquare>> Board)
        {
            PieceColorEnum Color = Board[CurrentX][CurrentY].SquarePiece.PieceColor;
            Dictionary<string, string> BishopMoves;
            BishopMoves = PseudoLegalMoveGenerator.GenerateBishopMoves(CurrentX, CurrentY, Board);
            BishopMoves = LegalMoveGenerator.GenerateLegalMoves(BishopMoves, Board, Color);
            return BishopMoves;
        }
    }
}
