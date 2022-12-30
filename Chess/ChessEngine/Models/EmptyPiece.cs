using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ChessEngine.Models
{
    public class EmptyPiece : Piece
    {
        public EmptyPiece(PieceColorEnum Color) : base(Color)               
        {
            _pieceType = PieceTypeEnum.Empty;
            _pieceColor = PieceColorEnum.Empty;
            PieceImage = "/ChessEngine;component/Resources/Empty.png";
        }

        public override Dictionary<string,string> GenerateLegalMoves(int Turn, int CurrentX, int CurrentY, ObservableCollection<ObservableCollection<BoardSquare>> Board)
        {
            return null;
        }
    }
}
