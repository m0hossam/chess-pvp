using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ChessEngine.Models
{
    public class Rook : Piece
    {
        private bool _moved;
        public bool Moved
        {
            get { return _moved; }
            set { _moved = value; }
        }

        public Rook(PieceColorEnum Color) : base(Color)                
        {
            _pieceType = PieceTypeEnum.Rook;
            _moved = false;
            if (_pieceColor == PieceColorEnum.White)
            {
                PieceImage = "/ChessEngine;component/Resources/WhiteRook.png";
            }
            else
            {
                PieceImage = "/ChessEngine;component/Resources/BlackRook.png";
            }
        }

        public override Dictionary<string,string> GenerateLegalMoves(int Turn, int CurrentX, int CurrentY, 
            ObservableCollection<ObservableCollection<BoardSquare>> Board)
        {
            PieceColorEnum Color = Board[CurrentX][CurrentY].SquarePiece.PieceColor;
            Dictionary<string, string> RookMoves;
            RookMoves = PseudoLegalMoveGenerator.GenerateRookMoves(CurrentX, CurrentY, Board);
            RookMoves = LegalMoveGenerator.GenerateLegalMoves(RookMoves, Board, Color);
            return RookMoves;
        }
    }
}
