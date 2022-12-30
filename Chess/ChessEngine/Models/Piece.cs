using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ChessEngine.Models
{
    public abstract class Piece : BaseNotificationClass
    {
        protected PieceTypeEnum _pieceType;
        public PieceTypeEnum PieceType
        {
            get { return _pieceType; }
        }

        protected PieceColorEnum _pieceColor;
        public PieceColorEnum PieceColor
        {
            get { return _pieceColor; }
        }

        private string _pieceImage;
        public string PieceImage
        {
            get { return _pieceImage; }
            set
            {
                _pieceImage = value;
                OnPropertyChanged(nameof(PieceImage));
            }
        }

        public Piece(PieceColorEnum Color)
        {
            _pieceColor = Color;
        }

        public abstract Dictionary<string,string> GenerateLegalMoves(int Turn, int CurrentX, int CurrentY, ObservableCollection<ObservableCollection<BoardSquare>> Board); 
    }
}
