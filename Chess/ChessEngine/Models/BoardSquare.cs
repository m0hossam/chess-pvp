using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngine.Models
{
    public class BoardSquare : BaseNotificationClass
    {
        private int _xCoordinate;
        public int XCoordinate
        {
            get { return _xCoordinate; }
        }

        private int _yCoordinate;
        public int YCoordinate
        {
            get { return _yCoordinate; }
        }

        private SquareColorEnum _squareColor;

        private string _squareImage;
        public string SquareImage
        {
            get { return _squareImage; }
            set
            {
                _squareImage = value;
                OnPropertyChanged(nameof(SquareImage));
            }
        }

        private Piece _squarePiece;
        public Piece SquarePiece
        {
            get { return _squarePiece; }
            set
            {
                _squarePiece = value;
                OnPropertyChanged(nameof(SquarePiece));
            }
        }

        private Piece CreatePiece(int X, int Y)
        {
            if (X == 0)
            {
                if (Y == 0 || Y == 7)
                {
                    return new Rook(PieceColorEnum.Black);
                }
                if (Y == 1 || Y == 6)
                {
                    return new Knight(PieceColorEnum.Black);
                }
                if (Y == 2 || Y == 5)
                {
                    return new Bishop(PieceColorEnum.Black);
                }
                if (Y == 3)
                {
                    return new Queen(PieceColorEnum.Black);
                }
                if (Y == 4)
                {
                    return new King(PieceColorEnum.Black);
                }
            }
            if (X == 1)
            {
                return new Pawn(PieceColorEnum.Black);
            }
            if (X == 6)
            {
                return new Pawn(PieceColorEnum.White);
            }
            if (X == 7)
            {
                if (Y == 0 || Y == 7)
                {
                    return new Rook(PieceColorEnum.White);
                }
                if (Y == 1 || Y == 6)
                {
                    return new Knight(PieceColorEnum.White);
                }
                if (Y == 2 || Y == 5)
                {
                    return new Bishop(PieceColorEnum.White);
                }
                if (Y == 3)
                {
                    return new Queen(PieceColorEnum.White);
                }
                if (Y == 4)
                {
                    return new King(PieceColorEnum.White);
                }
            }
            return new EmptyPiece(PieceColorEnum.Empty);
        }

        public BoardSquare(int X, int Y)
        {
            _xCoordinate = X;
            _yCoordinate = Y;
            if ((X + Y) % 2 == 0)
            {
                _squareColor = SquareColorEnum.Light;
                SquareImage = "/ChessEngine;component/Resources/LightSquare.png";
            } 
            else
            {
                _squareColor = SquareColorEnum.Dark;
                SquareImage = "/ChessEngine;component/Resources/DarkSquare.png";
            }
            SquarePiece = CreatePiece(X, Y);
        }

        public void HighlightSquare()
        {
            if (_squareColor == SquareColorEnum.Light)
            {
                SquareImage = "/ChessEngine;component/Resources/LightSquareHighlight.png";
            }
            else
            {
                SquareImage = "/ChessEngine;component/Resources/DarkSquareHighlight.png";
            }
        }

        public void LastMoveSquare()
        {
            if (_squareColor == SquareColorEnum.Light)
            {
                SquareImage = "/ChessEngine;component/Resources/LightSquareLastMove.png";
            }
            else
            {
                SquareImage = "/ChessEngine;component/Resources/DarkSquareLastMove.png";
            }
        }

        public void OriginalSquare()
        {
            if (_squareColor == SquareColorEnum.Light)
            {

                SquareImage = "/ChessEngine;component/Resources/LightSquare.png";
            }
            else
            {
                SquareImage = "/ChessEngine;component/Resources/DarkSquare.png";
            }
        }  
                  
    }
}
