using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ChessEngine.Models
{
    public static class PseudoLegalMoveGenerator
    {
        public static Dictionary<string, string> GenerateRookMoves(int CurrentX, int CurrentY,
            ObservableCollection<ObservableCollection<BoardSquare>> Board)
        {
            Dictionary<string, string> PseudoLegalMoves = new Dictionary<string, string>();
            PieceColorEnum CurrentColor = Board[CurrentX][CurrentY].SquarePiece.PieceColor;

            for (int x = CurrentX - 1; x >= 0; x--) //Checking file upwards
            {
                string Move = MoveEncoder.EncodeMove(CurrentX, CurrentY, x, CurrentY);
                PieceColorEnum Color = Board[x][CurrentY].SquarePiece.PieceColor;

                if (Color == PieceColorEnum.Empty)
                {
                    PseudoLegalMoves.Add(Move, "Standard");
                }
                else if (Color == CurrentColor)
                {
                    break;
                }
                else //Opposite Colors
                {
                    PseudoLegalMoves.Add(Move, "Standard");
                    break;
                }
            }
            for (int x = CurrentX + 1; x < 8; x++) //Checking file downwards
            {
                string Move = MoveEncoder.EncodeMove(CurrentX, CurrentY, x, CurrentY);
                PieceColorEnum Color = Board[x][CurrentY].SquarePiece.PieceColor;

                if (Color == PieceColorEnum.Empty)
                {
                    PseudoLegalMoves.Add(Move, "Standard");
                }
                else if (Color == CurrentColor)
                {
                    break;
                }
                else //Opposite Colors
                {
                    PseudoLegalMoves.Add(Move, "Standard");
                    break;
                }
            }
            for (int y = CurrentY + 1; y < 8; y++) //Checking rank rightwards
            {
                string Move = MoveEncoder.EncodeMove(CurrentX, CurrentY, CurrentX, y);
                PieceColorEnum Color = Board[CurrentX][y].SquarePiece.PieceColor;

                if (Color == PieceColorEnum.Empty)
                {
                    PseudoLegalMoves.Add(Move, "Standard");
                }
                else if (Color == CurrentColor)
                {
                    break;
                }
                else //Opposite Colors
                {
                    PseudoLegalMoves.Add(Move, "Standard");
                    break;
                }
            }
            for (int y = CurrentY - 1; y >= 0; y--) //Checking rank leftwards
            {
                string Move = MoveEncoder.EncodeMove(CurrentX, CurrentY, CurrentX, y);
                PieceColorEnum Color = Board[CurrentX][y].SquarePiece.PieceColor;

                if (Color == PieceColorEnum.Empty)
                {
                    PseudoLegalMoves.Add(Move, "Standard");
                }
                else if (Color == CurrentColor)
                {
                    break;
                }
                else //Opposite Colors
                {
                    PseudoLegalMoves.Add(Move, "Standard");
                    break;
                }
            }

            return PseudoLegalMoves;
        }

        public static Dictionary<string,string> GenerateBishopMoves(int CurrentX, int CurrentY,
            ObservableCollection<ObservableCollection<BoardSquare>> Board)
        {
            Dictionary<string, string> PseudoLegalMoves = new Dictionary<string, string>();
            PieceColorEnum CurrentColor = Board[CurrentX][CurrentY].SquarePiece.PieceColor;

            for (int x = CurrentX - 1, y = CurrentY + 1; x >= 0 && y < 8; x--, y++) //diagonal NE
            {
                string Move = MoveEncoder.EncodeMove(CurrentX, CurrentY, x, y);
                PieceColorEnum Color = Board[x][y].SquarePiece.PieceColor;

                if (Color == PieceColorEnum.Empty)
                {
                    PseudoLegalMoves.Add(Move, "Standard");
                }
                else if (Color == CurrentColor)
                {
                    break;
                }
                else //Opposite Colors
                {
                    PseudoLegalMoves.Add(Move, "Standard");
                    break;
                }
            }
            for (int x = CurrentX - 1, y = CurrentY - 1; x >= 0 && y >= 0; x--, y--) //diagonal NW
            {
                string Move = MoveEncoder.EncodeMove(CurrentX, CurrentY, x, y);
                PieceColorEnum Color = Board[x][y].SquarePiece.PieceColor;

                if (Color == PieceColorEnum.Empty)
                {
                    PseudoLegalMoves.Add(Move, "Standard");
                }
                else if (Color == CurrentColor)
                {
                    break;
                }
                else //Opposite Colors
                {
                    PseudoLegalMoves.Add(Move, "Standard");
                    break;
                }
            }
            for (int x = CurrentX + 1, y = CurrentY - 1; x < 8 && y >= 0; x++, y--) //diagonal SW
            {
                string Move = MoveEncoder.EncodeMove(CurrentX, CurrentY, x, y);
                PieceColorEnum Color = Board[x][y].SquarePiece.PieceColor;

                if (Color == PieceColorEnum.Empty)
                {
                    PseudoLegalMoves.Add(Move, "Standard");
                }
                else if (Color == CurrentColor)
                {
                    break;
                }
                else //Opposite Colors
                {
                    PseudoLegalMoves.Add(Move, "Standard");
                    break;
                }
            }
            for (int x = CurrentX + 1, y = CurrentY + 1; x < 8 && y < 8; x++, y++) //diagonal SE
            {
                string Move = MoveEncoder.EncodeMove(CurrentX, CurrentY, x, y);
                PieceColorEnum Color = Board[x][y].SquarePiece.PieceColor;

                if (Color == PieceColorEnum.Empty)
                {
                    PseudoLegalMoves.Add(Move, "Standard");
                }
                else if (Color == CurrentColor)
                {
                    break;
                }
                else //Opposite Colors
                {
                    PseudoLegalMoves.Add(Move, "Standard");
                    break;
                }
            }

            return PseudoLegalMoves;
        }

        public static Dictionary<string, string> GenerateKnightMoves(int CurrentX, int CurrentY,
            ObservableCollection<ObservableCollection<BoardSquare>> Board)
        {
            Dictionary<string, string> PseudoLegalMoves = new Dictionary<string, string>();
            PieceColorEnum CurrentColor = Board[CurrentX][CurrentY].SquarePiece.PieceColor;
            List<Tuple<int, int>> Pairs = new List<Tuple<int, int>>();
            Pairs.Add(new Tuple<int,int>(CurrentX - 2, CurrentY - 1));
            Pairs.Add(new Tuple<int, int>(CurrentX - 2, CurrentY + 1));
            Pairs.Add(new Tuple<int, int>(CurrentX + 2, CurrentY - 1));
            Pairs.Add(new Tuple<int, int>(CurrentX + 2, CurrentY + 1));
            Pairs.Add(new Tuple<int, int>(CurrentX - 1, CurrentY - 2));
            Pairs.Add(new Tuple<int, int>(CurrentX - 1, CurrentY + 2));
            Pairs.Add(new Tuple<int, int>(CurrentX + 1, CurrentY - 2));
            Pairs.Add(new Tuple<int, int>(CurrentX + 1, CurrentY + 2));

            foreach(Tuple<int,int> Pair in Pairs)
            {
                if (Pair.Item1 >= 0 && Pair.Item1 < 8 && Pair.Item2 >= 0 && Pair.Item2 < 8)
                {
                    PieceColorEnum Color = Board[Pair.Item1][Pair.Item2].SquarePiece.PieceColor;
                    if (Color == PieceColorEnum.Empty || Color != CurrentColor)
                    {
                        string Move = MoveEncoder.EncodeMove(CurrentX, CurrentY, Pair.Item1, Pair.Item2);
                        PseudoLegalMoves.Add(Move, "Standard");
                    }
                }
            }

            return PseudoLegalMoves;
        }

    }
}
