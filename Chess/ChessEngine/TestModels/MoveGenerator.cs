using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ChessEngine.Models;

namespace ChessEngine.TestModels
{
    public class MoveGenerator
    {
        private ObservableCollection<ObservableCollection<BoardSquare>> _board;

        private Stack<Piece> _capturedPiece;
        
        private int _currentTurn;

        private void CreateBoard()
        {
            _board = new ObservableCollection<ObservableCollection<BoardSquare>>();
            for (int i = 0; i < 8; i++)
            {
                _board.Add(new ObservableCollection<BoardSquare>());
                for (int j = 0; j < 8; j++)
                {
                    _board[i].Add(new BoardSquare(i, j));
                }
            }
        }

        private void NewGame()
        {
            CreateBoard();
            _capturedPiece = new Stack<Piece>();
            _currentTurn = 1;
        }

        public MoveGenerator()
        {
            NewGame();
        }

        private Dictionary<string, string> GetAllPossibleMoves(PieceColorEnum Color)
        {
            Dictionary<string, string> Moves = new Dictionary<string, string>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (_board[i][j].SquarePiece.PieceColor == Color)
                    {
                        Dictionary<string, string> PieceMoves = _board[i][j].SquarePiece.GenerateLegalMoves(_currentTurn, i, j, _board);
                        foreach (KeyValuePair<string, string> Move in PieceMoves)
                        {
                            Moves.Add(Move.Key, Move.Value);
                        }
                    }
                }
            }
            return Moves;
        }

        private void ExecuteMove(string Move, string Type)
        {
            int[] Positions = MoveDecoder.DecodeMove(Move);
            int x1 = Positions[0];
            int y1 = Positions[1];
            int x2 = Positions[2];
            int y2 = Positions[3];

            if (_board[x2][y2].SquarePiece.PieceType != PieceTypeEnum.Empty)
            {
                _capturedPiece.Push(_board[x2][y2].SquarePiece);
            }
            else
            {
                _capturedPiece.Push(new EmptyPiece(PieceColorEnum.Empty));
            }

            _board[x2][y2].SquarePiece = _board[x1][y1].SquarePiece;
            _board[x1][y1].SquarePiece = new EmptyPiece(PieceColorEnum.Empty);

            switch (Type)
            {

                case "PawnFirst":
                    var pawn = (Pawn)_board[x2][y2].SquarePiece;
                    pawn.Moved = true;
                    break;
                case "PawnDoubleFirst":
                    var doublepawn = (Pawn)_board[x2][y2].SquarePiece;
                    doublepawn.Moved = true;
                    break;
                default:
                    break;
            }

            _currentTurn++;
        }

        private void UndoMove(string Move, string Type)
        {
            int[] Positions = MoveDecoder.DecodeMove(Move);
            int x1 = Positions[0];
            int y1 = Positions[1];
            int x2 = Positions[2];
            int y2 = Positions[3];

            switch (Type)
            {
                case "PawnFirst":
                    var pawn = (Pawn)_board[x2][y2].SquarePiece;
                    pawn.Moved = false;
                    break;
                case "PawnDoubleFirst":
                    var doublepawn = (Pawn)_board[x2][y2].SquarePiece;
                    doublepawn.Moved = false;
                    break;
                default:
                    break;
            }
            _board[x1][y1].SquarePiece = _board[x2][y2].SquarePiece;
            _board[x2][y2].SquarePiece = _capturedPiece.Pop();

            _currentTurn--;
        }

        public UInt64 Perft(int Depth)
        {
            PieceColorEnum Color = ((_currentTurn % 2) == 1 ? PieceColorEnum.White : PieceColorEnum.Black);
            Dictionary<string, string> Moves;
            UInt64 Nodes = 0;

            if (Depth == 0)
            {
                return (UInt64)1;
            }

            Moves = GetAllPossibleMoves(Color);
            foreach (KeyValuePair<string, string> Pair in Moves)
            {
                ExecuteMove(Pair.Key, Pair.Value);
                UInt64 LeafNodes = Perft(Depth - 1);
                Nodes += LeafNodes;
                UndoMove(Pair.Key, Pair.Value);
            }
            return Nodes;
        }
    }
}
