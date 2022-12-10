using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ChessEngine.Models
{
    public static class LegalMoveGenerator
    {
        public static BoardSquare FindKing(PieceColorEnum Color,
            ObservableCollection<ObservableCollection<BoardSquare>> Board)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Board[i][j].SquarePiece.PieceType == PieceTypeEnum.King
                        && Board[i][j].SquarePiece.PieceColor == Color)
                    {
                        return Board[i][j];
                    }
                }
            }
            return null;
        }

        private static bool IsMoveLegal(ObservableCollection<ObservableCollection<BoardSquare>> Board, PieceColorEnum Color,
            int KingX, int KingY, string Move, string MoveType)
        {
            int[] Positions = MoveDecoder.DecodeMove(Move);
            int OldX = Positions[0];
            int OldY = Positions[1];
            int NewX = Positions[2];
            int NewY = Positions[3];
            int EnPassantX = -1;
            int EnPassantY = -1;

            if (String.Equals(MoveType, "EnPassant"))
            {
                if (NewY > OldY) //to the right of capturing pawn
                {
                    EnPassantX = OldX;
                    EnPassantY = OldY + 1;
                }
                else //to the left of capturing pawn
                {
                    EnPassantX = OldX;
                    EnPassantY = OldY - 1;
                }
            }

            #region Checking ranks & files for Queens and Rooks
            for (int x = KingX - 1; x >= 0; x--) //Checking file upwards
            {
                Piece Threat = Board[x][KingY].SquarePiece;
                if (x == OldX && KingY == OldY || (x == EnPassantX && KingY == EnPassantY)) //Empty Square Due To Movement
                {
                    continue;
                }
                if (x == NewX && KingY == NewY) //Friendly Piece Due To Movement
                {
                    break;
                }
                if (Threat.PieceColor == Color) //Friendly Piece
                {
                    break;
                }
                if (Threat.PieceColor == PieceColorEnum.Empty) //Empty Square
                {
                    continue;
                }
                if (Threat.PieceType == PieceTypeEnum.Queen
                    || Threat.PieceType == PieceTypeEnum.Rook) //Opposition Piece
                {
                    return false;
                }
                else //Non-threatening opposition piece
                {
                    break;
                }
            }
            for (int x = KingX + 1; x < 8; x++) //Checking file downwards
            {
                Piece Threat = Board[x][KingY].SquarePiece;
                if (x == OldX && KingY == OldY || (x == EnPassantX && KingY == EnPassantY)) //Empty Square Due To Movement
                {
                    continue;
                }
                if (x == NewX && KingY == NewY) //Friendly Piece Due To Movement
                {
                    break;
                }
                if (Threat.PieceColor == Color) //Friendly Piece
                {
                    break;
                }
                if (Threat.PieceColor == PieceColorEnum.Empty) //Empty Square
                {
                    continue;
                }
                if (Threat.PieceType == PieceTypeEnum.Queen
                    || Threat.PieceType == PieceTypeEnum.Rook) //Opposition Piece
                {
                    return false;
                }
                else //Non-threatening opposition piece
                {
                    break;
                }
            }
            for (int y = KingY + 1; y < 8; y++) //Checking rank rightwards
            {
                Piece Threat = Board[KingX][y].SquarePiece;
                if (KingX == OldX && y == OldY || (KingX == EnPassantX && y == EnPassantY)) //Empty Square Due To Movement
                {
                    continue;
                }
                if (KingX == NewX && y == NewY) //Friendly Piece Due To Movement
                {
                    break;
                }
                if (Threat.PieceColor == Color) //Friendly Piece
                {
                    break;
                }
                if (Threat.PieceColor == PieceColorEnum.Empty) //Empty Square
                {
                    continue;
                }
                if (Threat.PieceType == PieceTypeEnum.Queen
                    || Threat.PieceType == PieceTypeEnum.Rook) //Opposition Piece
                {
                    return false;
                }
                else //Non-threatening opposition piece
                {
                    break;
                }
            }
            for (int y = KingY - 1; y >= 0; y--) //Checking rank leftwards
            {
                Piece Threat = Board[KingX][y].SquarePiece;
                if (KingX == OldX && y == OldY || (KingX == EnPassantX && y == EnPassantY)) //Empty Square Due To Movement
                {
                    continue;
                }
                if (KingX == NewX && y == NewY) //Friendly Piece Due To Movement
                {
                    break;
                }
                if (Threat.PieceColor == Color) //Friendly Piece
                {
                    break;
                }
                if (Threat.PieceColor == PieceColorEnum.Empty) //Empty Square
                {
                    continue;
                }
                if (Threat.PieceType == PieceTypeEnum.Queen
                    || Threat.PieceType == PieceTypeEnum.Rook) //Opposition Piece
                {
                    return false;
                }
                else //Non-threatening opposition piece
                {
                    break;
                }
            }
            #endregion

            #region Checking diagonals for Queens and Bishops
            for (int x = KingX - 1, y = KingY + 1; x >= 0 && y < 8; x--, y++) //diagonal NE
            {
                Piece Threat = Board[x][y].SquarePiece;
                if (x == OldX && y == OldY || (x == EnPassantX && y == EnPassantY)) //Empty Square Due To Movement
                {
                    continue;
                }
                if (x == NewX && y == NewY) //Friendly Piece Due To Movement
                {
                    break;
                }
                if (Threat.PieceColor == Color) //Friendly Piece
                {
                    break;
                }
                if (Threat.PieceColor == PieceColorEnum.Empty) //Empty Square
                {
                    continue;
                }
                if (Threat.PieceType == PieceTypeEnum.Bishop || Threat.PieceType == PieceTypeEnum.Queen) //Opposition Piece
                {
                    return false;
                }
                else //Non-threatening opposition piece
                {
                    break;
                }
            }
            for (int x = KingX - 1, y = KingY - 1; x >= 0 && y >= 0; x--, y--) //diagonal NW
            {
                Piece Threat = Board[x][y].SquarePiece;
                if (x == OldX && y == OldY || (x == EnPassantX && y == EnPassantY)) //Empty Square Due To Movement
                {
                    continue;
                }
                if (x == NewX && y == NewY) //Friendly Piece Due To Movement
                {
                    break;
                }
                if (Threat.PieceColor == Color) //Friendly Piece
                {
                    break;
                }
                if (Threat.PieceColor == PieceColorEnum.Empty) //Empty Square
                {
                    continue;
                }
                if (Threat.PieceType == PieceTypeEnum.Bishop || Threat.PieceType == PieceTypeEnum.Queen) //Opposition Piece
                {
                    return false;
                }
                else //Non-threatening opposition piece
                {
                    break;
                }
            }
            for (int x = KingX + 1, y = KingY - 1; x < 8 && y >= 0; x++, y--) //diagonal SW
            {
                Piece Threat = Board[x][y].SquarePiece;
                if (x == OldX && y == OldY || (x == EnPassantX && y == EnPassantY)) //Empty Square Due To Movement
                {
                    continue;
                }
                if (x == NewX && y == NewY) //Friendly Piece Due To Movement
                {
                    break;
                }
                if (Threat.PieceColor == Color) //Friendly Piece
                {
                    break;
                }
                if (Threat.PieceColor == PieceColorEnum.Empty) //Empty Square
                {
                    continue;
                }
                if (Threat.PieceType == PieceTypeEnum.Bishop || Threat.PieceType == PieceTypeEnum.Queen) //Opposition Piece
                {
                    return false;
                }
                else //Non-threatening opposition piece
                {
                    break;
                }
            }
            for (int x = KingX + 1, y = KingY + 1; x < 8 && y < 8; x++, y++) //diagonal SE
            {
                Piece Threat = Board[x][y].SquarePiece;
                if (x == OldX && y == OldY || (x == EnPassantX && y == EnPassantY)) //Empty Square Due To Movement
                {
                    continue;
                }
                if (x == NewX && y == NewY) //Friendly Piece Due To Movement
                {
                    break;
                }
                if (Threat.PieceColor == Color) //Friendly Piece
                {
                    break;
                }
                if (Threat.PieceColor == PieceColorEnum.Empty) //Empty Square
                {
                    continue;
                }
                if (Threat.PieceType == PieceTypeEnum.Bishop || Threat.PieceType == PieceTypeEnum.Queen) //Opposition Piece
                {
                    return false;
                }
                else //Non-threatening opposition piece
                {
                    break;
                }
            }
            #endregion

            #region Checking for Pawns
            if (Color == PieceColorEnum.White) //White King
            {
                if (KingY != 7 && KingX != 0) //top right pawn
                {
                    Piece Threat = Board[KingX - 1][KingY + 1].SquarePiece;
                    if (Threat.PieceType == PieceTypeEnum.Pawn && Threat.PieceColor != Color
                        && !(KingX - 1 == NewX && KingY + 1 == NewY)
                        && !(KingX - 1 == EnPassantX && KingY + 1 == EnPassantY))
                    {
                        return false;
                    }
                }
                if (KingY != 0 && KingX != 0) //top left pawn
                {
                    Piece Threat = Board[KingX - 1][KingY - 1].SquarePiece;
                    if (Threat.PieceType == PieceTypeEnum.Pawn && Threat.PieceColor != Color
                        && !(KingX - 1 == NewX && KingY - 1 == NewY)
                        && !(KingX - 1 == EnPassantX && KingY - 1 == EnPassantY))
                    {
                        return false;
                    }
                }
            }
            else //Black King
            {
                if (KingY != 7 && KingX != 7) //bottom right pawn
                {
                    Piece Threat = Board[KingX + 1][KingY + 1].SquarePiece;
                    if (Threat.PieceType == PieceTypeEnum.Pawn && Threat.PieceColor != Color
                        && !(KingX + 1 == NewX && KingY + 1 == NewY)
                        && !(KingX + 1 == EnPassantX && KingY + 1 == EnPassantY))
                    {
                        return false;
                    }
                }
                if (KingY != 0 && KingX != 7) //bottom left pawn
                {
                    Piece Threat = Board[KingX + 1][KingY - 1].SquarePiece;
                    if (Threat.PieceType == PieceTypeEnum.Pawn && Threat.PieceColor != Color
                        && !(KingX + 1 == NewX && KingY - 1 == NewY)
                        && !(KingX + 1 == EnPassantX && KingY - 1 == EnPassantY))
                    {
                        return false;
                    }
                }
            }
            #endregion

            #region Checking for Knights 
            List<Tuple<int, int>> Pairs = new List<Tuple<int, int>>();
            Pairs.Add(new Tuple<int,int>(KingX - 2, KingY - 1));
            Pairs.Add(new Tuple<int,int>(KingX - 2, KingY + 1));
            Pairs.Add(new Tuple<int,int>(KingX + 2, KingY - 1));
            Pairs.Add(new Tuple<int,int>(KingX + 2, KingY + 1));
            Pairs.Add(new Tuple<int,int>(KingX - 1, KingY - 2));
            Pairs.Add(new Tuple<int,int>(KingX - 1, KingY + 2));
            Pairs.Add(new Tuple<int,int>(KingX + 1, KingY - 2));
            Pairs.Add(new Tuple<int,int>(KingX + 1, KingY + 2));
            foreach (Tuple<int, int> Pair in Pairs)
            {
                if (Pair.Item1 >= 0 && Pair.Item1 < 8 && Pair.Item2 >= 0 && Pair.Item2 < 8)
                {
                    Piece Threat = Board[Pair.Item1][Pair.Item2].SquarePiece;
                    if (Threat.PieceType == PieceTypeEnum.Knight && Threat.PieceColor != Color
                        && !(NewX == Pair.Item1 && NewY == Pair.Item2))
                    {
                        return false;
                    }
                }
            }
            #endregion

            return true;
        }

        public static bool IsSquareSafe(PieceColorEnum Color, int OldX, int OldY, int NewX, int NewY,
            ObservableCollection<ObservableCollection<BoardSquare>> Board)
        {

            #region Checking ranks & files for Queens and Rooks
            for (int x = NewX - 1; x >= 0; x--) //Checking file upwards
            {
                Piece Threat = Board[x][NewY].SquarePiece;
                if (x == OldX && NewX == OldY) //Empty Square Due To Movement
                {
                    continue;
                }
                if (Threat.PieceColor == Color) //Friendly Piece
                {
                    break;
                }
                if (Threat.PieceColor == PieceColorEnum.Empty) //Empty Square
                {
                    continue;
                }
                if (Threat.PieceType == PieceTypeEnum.Queen
                    || Threat.PieceType == PieceTypeEnum.Rook) //Opposition Piece
                {
                    return false;
                }
                else //Non-threatening opposition piece
                {
                    break;
                }
            }
            for (int x = NewX + 1; x < 8; x++) //Checking file downwards
            {
                Piece Threat = Board[x][NewY].SquarePiece;
                if (x == OldX && NewY == OldY) //Empty Square Due To Movement
                {
                    continue;
                }
                if (Threat.PieceColor == Color) //Friendly Piece
                {
                    break;
                }
                if (Threat.PieceColor == PieceColorEnum.Empty) //Empty Square
                {
                    continue;
                }
                if (Threat.PieceType == PieceTypeEnum.Queen
                    || Threat.PieceType == PieceTypeEnum.Rook) //Opposition Piece
                {
                    return false;
                }
                else //Non-threatening opposition piece
                {
                    break;
                }
            }
            for (int y = NewY + 1; y < 8; y++) //Checking rank rightwards
            {
                Piece Threat = Board[NewX][y].SquarePiece;
                if (NewX == OldX && y == OldY) //Empty Square Due To Movement
                {
                    continue;
                }
                if (Threat.PieceColor == Color) //Friendly Piece
                {
                    break;
                }
                if (Threat.PieceColor == PieceColorEnum.Empty) //Empty Square
                {
                    continue;
                }
                if (Threat.PieceType == PieceTypeEnum.Queen
                    || Threat.PieceType == PieceTypeEnum.Rook) //Opposition Piece
                {
                    return false;
                }
                else //Non-threatening opposition piece
                {
                    break;
                }
            }
            for (int y = NewY - 1; y >= 0; y--) //Checking rank leftwards
            {
                Piece Threat = Board[NewX][y].SquarePiece;
                if (NewX == OldX && y == OldY) //Empty Square Due To Movement
                {
                    continue;
                }
                if (Threat.PieceColor == Color) //Friendly Piece
                {
                    break;
                }
                if (Threat.PieceColor == PieceColorEnum.Empty) //Empty Square
                {
                    continue;
                }
                if (Threat.PieceType == PieceTypeEnum.Queen
                    || Threat.PieceType == PieceTypeEnum.Rook) //Opposition Piece
                {
                    return false;
                }
                else //Non-threatening opposition piece
                {
                    break;
                }
            }
            #endregion

            #region Checking diagonals for Queens and Bishops
            for (int x = NewX - 1, y = NewY + 1; x >= 0 && y < 8; x--, y++) //diagonal NE
            {
                Piece Threat = Board[x][y].SquarePiece;
                if (x == OldX && y == OldY) //Empty Square Due To Movement
                {
                    continue;
                }
                if (Threat.PieceColor == Color) //Friendly Piece
                {
                    break;
                }
                if (Threat.PieceColor == PieceColorEnum.Empty) //Empty Square
                {
                    continue;
                }
                if (Threat.PieceType == PieceTypeEnum.Bishop || Threat.PieceType == PieceTypeEnum.Queen) //Opposition Piece
                {
                    return false;
                }
                else //Non-threatening opposition piece
                {
                    break;
                }
            }
            for (int x = NewX - 1, y = NewY - 1; x >= 0 && y >= 0; x--, y--) //diagonal NW
            {
                Piece Threat = Board[x][y].SquarePiece;
                if (x == OldX && y == OldY) //Empty Square Due To Movement
                {
                    continue;
                }
                if (Threat.PieceColor == Color) //Friendly Piece
                {
                    break;
                }
                if (Threat.PieceColor == PieceColorEnum.Empty) //Empty Square
                {
                    continue;
                }
                if (Threat.PieceType == PieceTypeEnum.Bishop || Threat.PieceType == PieceTypeEnum.Queen) //Opposition Piece
                {
                    return false;
                }
                else //Non-threatening opposition piece
                {
                    break;
                }
            }
            for (int x = NewX + 1, y = NewY - 1; x < 8 && y >= 0; x++, y--) //diagonal SW
            {
                Piece Threat = Board[x][y].SquarePiece;
                if (x == OldX && y == OldY) //Empty Square Due To Movement
                {
                    continue;
                }
                if (Threat.PieceColor == Color) //Friendly Piece
                {
                    break;
                }
                if (Threat.PieceColor == PieceColorEnum.Empty) //Empty Square
                {
                    continue;
                }
                if (Threat.PieceType == PieceTypeEnum.Bishop || Threat.PieceType == PieceTypeEnum.Queen) //Opposition Piece
                {
                    return false;
                }
                else //Non-threatening opposition piece
                {
                    break;
                }
            }
            for (int x = NewX + 1, y = NewY + 1; x < 8 && y < 8; x++, y++) //diagonal SE
            {
                Piece Threat = Board[x][y].SquarePiece;
                if (x == OldX && y == OldY) //Empty Square Due To Movement
                {
                    continue;
                }
                if (Threat.PieceColor == Color) //Friendly Piece
                {
                    break;
                }
                if (Threat.PieceColor == PieceColorEnum.Empty) //Empty Square
                {
                    continue;
                }
                if (Threat.PieceType == PieceTypeEnum.Bishop || Threat.PieceType == PieceTypeEnum.Queen) //Opposition Piece
                {
                    return false;
                }
                else //Non-threatening opposition piece
                {
                    break;
                }
            }
            #endregion

            #region Checking for Pawns
            if (Color == PieceColorEnum.White) //White King
            {
                if (NewY != 7 && NewX != 0) //top right pawn
                {
                    Piece Threat = Board[NewX - 1][NewY + 1].SquarePiece;
                    if (Threat.PieceType == PieceTypeEnum.Pawn && Threat.PieceColor != Color)
                    {
                        return false;
                    }
                }
                if (NewY != 0 && NewX != 0) //top left pawn
                {
                    Piece Threat = Board[NewX - 1][NewY - 1].SquarePiece;
                    if (Threat.PieceType == PieceTypeEnum.Pawn && Threat.PieceColor != Color)
                    {
                        return false;
                    }
                }
            }
            else //Black King
            {
                if (NewY != 7 && NewX != 7) //bottom right pawn
                {
                    Piece Threat = Board[NewX + 1][NewY + 1].SquarePiece;
                    if (Threat.PieceType == PieceTypeEnum.Pawn && Threat.PieceColor != Color)
                    {
                        return false;
                    }
                }
                if (NewY != 0 && NewX != 7) //bottom left pawn
                {
                    Piece Threat = Board[NewX + 1][NewY - 1].SquarePiece;
                    if (Threat.PieceType == PieceTypeEnum.Pawn && Threat.PieceColor != Color)
                    {
                        return false;
                    }
                }
            }
            #endregion

            #region Checking for Knights 
            List<Tuple<int, int>> Pairs = new List<Tuple<int, int>>();
            Pairs.Add(new Tuple<int, int>(NewX - 2, NewY - 1));
            Pairs.Add(new Tuple<int, int>(NewX - 2, NewY + 1));
            Pairs.Add(new Tuple<int, int>(NewX + 2, NewY - 1));
            Pairs.Add(new Tuple<int, int>(NewX + 2, NewY + 1));
            Pairs.Add(new Tuple<int, int>(NewX - 1, NewY - 2));
            Pairs.Add(new Tuple<int, int>(NewX - 1, NewY + 2));
            Pairs.Add(new Tuple<int, int>(NewX + 1, NewY - 2));
            Pairs.Add(new Tuple<int, int>(NewX + 1, NewY + 2));
            foreach (Tuple<int, int> Pair in Pairs)
            {
                if (Pair.Item1 >= 0 && Pair.Item1 < 8 && Pair.Item2 >= 0 && Pair.Item2 < 8)
                {
                    Piece Threat = Board[Pair.Item1][Pair.Item2].SquarePiece;
                    if (Threat.PieceType == PieceTypeEnum.Knight && Threat.PieceColor != Color)
                    {
                        return false;
                    }
                }
            }
            #endregion

            #region Checking for Enemy King
            List<Tuple<int, int>> Pairs2 = new List<Tuple<int, int>>();
            Pairs2.Add(new Tuple<int, int>(NewX - 1, NewY - 1));
            Pairs2.Add(new Tuple<int, int>(NewX - 1, NewY));
            Pairs2.Add(new Tuple<int, int>(NewX - 1, NewY + 1));
            Pairs2.Add(new Tuple<int, int>(NewX, NewY - 1));
            Pairs2.Add(new Tuple<int, int>(NewX, NewY + 1));
            Pairs2.Add(new Tuple<int, int>(NewX + 1, NewY - 1));
            Pairs2.Add(new Tuple<int, int>(NewX + 1, NewY));
            Pairs2.Add(new Tuple<int, int>(NewX + 1, NewY + 1));
            foreach (Tuple<int, int> Pair in Pairs2)
            {
                if (Pair.Item1 >= 0 && Pair.Item1 < 8 && Pair.Item2 >= 0 && Pair.Item2 < 8)
                {
                    Piece Threat = Board[Pair.Item1][Pair.Item2].SquarePiece;
                    if (Threat.PieceType == PieceTypeEnum.King && Threat.PieceColor != Color)
                    {
                        return false;
                    }
                }
            }
            #endregion

            return true;
        }

        public static Dictionary<string, string> GenerateLegalMoves(Dictionary<string, string> PseudoLegalMoves, 
            ObservableCollection<ObservableCollection<BoardSquare>> Board, PieceColorEnum Color)
        {
            BoardSquare KingSquare = FindKing(Color, Board);
            int KingX = KingSquare.XCoordinate;
            int KingY = KingSquare.YCoordinate;

            Dictionary<string, int> MovesToRemove = new Dictionary<string, int>();

            foreach (string Move in PseudoLegalMoves.Keys)
            {
                if (IsMoveLegal(Board, Color, KingX, KingY, Move, PseudoLegalMoves[Move]) == false)
                {
                    if (!MovesToRemove.ContainsKey(Move)) { MovesToRemove.Add(Move, 1); }
                }
            }

            foreach (string Move in MovesToRemove.Keys)
            {
                PseudoLegalMoves.Remove(Move);
            }

            return PseudoLegalMoves;
        }

        public static Dictionary<string,string> GenerateKingLegalMoves(Dictionary<string, string> PseudoLegalMoves,
            ObservableCollection<ObservableCollection<BoardSquare>> Board, PieceColorEnum Color)
        {
            Dictionary<string, int> MovesToRemove = new Dictionary<string, int>();

            foreach (string Move in PseudoLegalMoves.Keys)
            {
                int[] Positions = MoveDecoder.DecodeMove(Move);
                int OldX = Positions[0];
                int OldY = Positions[1];
                int NewX = Positions[2];
                int NewY = Positions[3];

                if (String.Equals(PseudoLegalMoves[Move], "Standard"))
                {
                    bool IsSafe = IsSquareSafe(Color, OldX, OldY, NewX, NewY, Board);
                    if (IsSafe == false)
                    {
                        if (!MovesToRemove.ContainsKey(Move)) { MovesToRemove.Add(Move, 1); }
                    }
                }   
                else //Castling Move
                {
                    if (NewY > OldY)
                    {
                        for (int i = OldY; i <= NewY; i++)
                        {
                            bool IsSafe = IsSquareSafe(Color, OldX, OldY, NewX, i, Board);
                            if (IsSafe == false)
                            {
                                if (!MovesToRemove.ContainsKey(Move)) { MovesToRemove.Add(Move, 1); }
                            }
                        }
                    }
                    else
                    {
                        for (int i = OldY; i >= NewY; i--)
                        {
                            bool IsSafe = IsSquareSafe(Color, OldX, OldY, NewX, i, Board);
                            if (IsSafe == false)
                            {
                                if (!MovesToRemove.ContainsKey(Move)) { MovesToRemove.Add(Move, 1); }
                            }
                        }
                    }
                }
            }

            foreach (string Move in MovesToRemove.Keys)
            {
                PseudoLegalMoves.Remove(Move);
            }

            return PseudoLegalMoves;
        }
    }
}
