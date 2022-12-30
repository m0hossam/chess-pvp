using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ChessEngine.Models
{
    public class Knight : Piece
    {
        public Knight(PieceColorEnum Color) : base(Color)                
        {
            _pieceType = PieceTypeEnum.Knight;
            if (_pieceColor == PieceColorEnum.White)
            {
                PieceImage = "/ChessEngine;component/Resources/WhiteKnight.png";
            }
            else
            {
                PieceImage = "/ChessEngine;component/Resources/BlackKnight.png";
            }
        }

        public override Dictionary<string,string> GenerateLegalMoves(int Turn, int CurrentX, int CurrentY, 
            ObservableCollection<ObservableCollection<BoardSquare>> Board)
        {
            PieceColorEnum Color = Board[CurrentX][CurrentY].SquarePiece.PieceColor;
            Dictionary<string, string> KnightMoves;
            KnightMoves = PseudoLegalMoveGenerator.GenerateKnightMoves(CurrentX, CurrentY, Board);
            KnightMoves = LegalMoveGenerator.GenerateLegalMoves(KnightMoves, Board, Color);
            return KnightMoves;
        }
    }
}
