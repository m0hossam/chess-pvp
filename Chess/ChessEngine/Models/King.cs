using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ChessEngine.Models
{
    public class King : Piece
    {
        private bool _moved;
        public bool Moved
        {
            get { return _moved; }
            set { _moved = value; }
        }

        public King(PieceColorEnum Color) : base(Color)                
        {
            _pieceType = PieceTypeEnum.King;
            _moved = false;
            if (_pieceColor == PieceColorEnum.White)
            {
                PieceImage = "/ChessEngine;component/Resources/WhiteKing.png";
            }
            else
            {
                PieceImage = "/ChessEngine;component/Resources/BlackKing.png";
            }
        }

        public void RedHighlight()
        {
            if (_pieceColor == PieceColorEnum.White)
            {
                PieceImage = "/ChessEngine;component/Resources/WhiteKingChecked.png";
            }
            else
            {
                PieceImage = "/ChessEngine;component/Resources/BlackKingChecked.png";
            }
        }

        public void RemoveRedHighlight()
        {
            if (_pieceColor == PieceColorEnum.White)
            {
                PieceImage = "/ChessEngine;component/Resources/WhiteKing.png";
            }
            else
            {
                PieceImage = "/ChessEngine;component/Resources/BlackKing.png";
            }
        }

        public override Dictionary<string,string> GenerateLegalMoves(int Turn, int CurrentX, int CurrentY, ObservableCollection<ObservableCollection<BoardSquare>> Board)
        {
            Dictionary<string, string> Moves = new Dictionary<string, string>();

            List<Tuple<int, int>> Pairs = new List<Tuple<int, int>>();
            Pairs.Add(new Tuple<int, int>(CurrentX - 1, CurrentY - 1));
            Pairs.Add(new Tuple<int, int>(CurrentX - 1, CurrentY));
            Pairs.Add(new Tuple<int, int>(CurrentX - 1, CurrentY + 1));
            Pairs.Add(new Tuple<int, int>(CurrentX, CurrentY - 1));
            Pairs.Add(new Tuple<int, int>(CurrentX, CurrentY + 1));
            Pairs.Add(new Tuple<int, int>(CurrentX + 1, CurrentY - 1));
            Pairs.Add(new Tuple<int, int>(CurrentX + 1, CurrentY));
            Pairs.Add(new Tuple<int, int>(CurrentX + 1, CurrentY + 1));

            foreach (Tuple<int, int> Pair in Pairs)
            {
                if (Pair.Item1 >= 0 && Pair.Item1 < 8 && Pair.Item2 >= 0 && Pair.Item2 < 8)
                {
                    Piece Threat = Board[Pair.Item1][Pair.Item2].SquarePiece;
                    if (Threat.PieceColor != _pieceColor)
                    {
                        Moves.Add(MoveEncoder.EncodeMove(CurrentX, CurrentY, Pair.Item1, Pair.Item2), "Standard");
                    }
                }
            }

            if (_moved == false) //could castle?
            {
                bool CanLongCastle = true;
                bool CanShortCastle = true;
                for (int i = CurrentY - 1; i > 0; i--)
                {
                    if (Board[CurrentX][i].SquarePiece.PieceType != PieceTypeEnum.Empty)
                    {
                        CanLongCastle = false;
                        break;
                    }
                }
                for (int i = CurrentY + 1; i < 7; i++)
                {
                    if (Board[CurrentX][i].SquarePiece.PieceType != PieceTypeEnum.Empty)
                    {
                        CanShortCastle = false;
                        break;
                    }
                }
                if (CanLongCastle)
                {
                    Piece PotentialRook = Board[CurrentX][0].SquarePiece;
                    if (PotentialRook.PieceType == PieceTypeEnum.Rook && PotentialRook.PieceColor == _pieceColor)
                    {
                        var ActualRook = (Rook)PotentialRook;
                        if (ActualRook.Moved == false)
                        {
                            Moves.Add(MoveEncoder.EncodeMove(CurrentX, CurrentY, CurrentX, CurrentY - 2), "Castling");
                        }
                    }
                }
                if (CanShortCastle)
                {
                    Piece PotentialRook = Board[CurrentX][7].SquarePiece;
                    if (PotentialRook.PieceType == PieceTypeEnum.Rook && PotentialRook.PieceColor == _pieceColor)
                    {
                        var ActualRook = (Rook)PotentialRook;
                        if (ActualRook.Moved == false)
                        {
                            Moves.Add(MoveEncoder.EncodeMove(CurrentX, CurrentY, CurrentX, CurrentY + 2), "Castling");
                        }
                    }
                }
            }

            Moves = LegalMoveGenerator.GenerateKingLegalMoves(Moves, Board, _pieceColor);
            return Moves;
        }
    }
}
