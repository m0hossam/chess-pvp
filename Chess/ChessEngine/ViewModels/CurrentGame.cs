using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Collections.ObjectModel;
using ChessEngine.Models;

namespace ChessEngine.ViewModels
{
    public class CurrentGame : BaseNotificationClass
    {
        private string _gameState;
        public string GameState
        {
            get { return _gameState; }
            set
            {
                _gameState = value;
                OnPropertyChanged(nameof(GameState));
            }
        }

        private List<BoardSquare> _lastMoveSquares;

        private Dictionary<string, string> _currentMoves;

        private ObservableCollection<ObservableCollection<BoardSquare>> _board;
        public ObservableCollection<ObservableCollection<BoardSquare>> Board
        {
            get { return _board; }
            set
            {
                _board = value;
                OnPropertyChanged(nameof(Board));
            }
        }
        private BoardSquare _currentSquare;
        private Piece _currentPiece;
        private int _currentTurn;
        private string _promotionPieceType;

        private System.Media.SoundPlayer MoveSound;
        private System.Media.SoundPlayer CaptureSound;

        private void CreateBoard()
        {
            Board = new ObservableCollection<ObservableCollection<BoardSquare>>();
            for (int i = 0; i < 8; i++)
            {
                Board.Add(new ObservableCollection<BoardSquare>());
                for (int j = 0; j < 8; j++)
                {
                    Board[i].Add(new BoardSquare(i, j));
                }
            }
        }

        public void NewGame()
        {
            CreateBoard();
            GameState = "Game State: Ongoing";
            _currentMoves = null;
            _lastMoveSquares = new List<BoardSquare>();
            _currentSquare = null;
            _currentPiece = null;
            _currentTurn = 1;
        }

        public CurrentGame()
        {
            NewGame();
            _promotionPieceType = "Queen";

            System.IO.Stream stream = Properties.Resources.Move;
            MoveSound = new System.Media.SoundPlayer(stream);
            stream = Properties.Resources.Capture;
            CaptureSound = new System.Media.SoundPlayer(stream);
        }

        private Dictionary<string, string> GetAllPossibleMoves(PieceColorEnum Color)
        {
            Dictionary<string, string> Moves = new Dictionary<string, string>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Board[i][j].SquarePiece.PieceColor == Color)
                    {
                        Dictionary<string, string> PieceMoves = Board[i][j].SquarePiece.GenerateLegalMoves(_currentTurn, i, j, Board);
                        foreach (KeyValuePair<string, string> Move in PieceMoves)
                        {
                            Moves.Add(Move.Key, Move.Value);
                        }
                    }
                }
            }
            return Moves;
        }

        private void ResetSelection()
        {
            _currentPiece = null;
            _currentSquare.OriginalSquare();
            _currentSquare = null;
        }

        private void LastMoveHighlight(int x1, int y1, int x2, int y2)
        {
            foreach (BoardSquare square in _lastMoveSquares)
            {
                square.OriginalSquare();
            }
            _lastMoveSquares = new List<BoardSquare>();
            _lastMoveSquares.Add(Board[x1][y1]);
            _lastMoveSquares.Add(Board[x2][y2]);
            foreach (BoardSquare square in _lastMoveSquares)
            {
                square.LastMoveSquare();
            }
        }

        private void ExecuteMove(string Move, string Type)
        {
            ResetSelection();
            int[] Positions = MoveDecoder.DecodeMove(Move);
            int x1 = Positions[0];
            int y1 = Positions[1];
            int x2 = Positions[2];
            int y2 = Positions[3];

            if (Board[x2][y2].SquarePiece.PieceType != PieceTypeEnum.Empty
                || String.Equals(Type, "EnPassant"))
            {

                CaptureSound.Play();
            }
            else
            {
                MoveSound.Play();
            }

            Board[x2][y2].SquarePiece = Board[x1][y1].SquarePiece;
            Board[x1][y1].SquarePiece = new EmptyPiece(PieceColorEnum.Empty);
            switch (Type)
            {
                case "Standard":
                    if (Board[x2][y2].SquarePiece.PieceType == PieceTypeEnum.King)
                    {
                        var tempking = (King)Board[x2][y2].SquarePiece;
                        tempking.Moved = true;
                    }
                    if (Board[x2][y2].SquarePiece.PieceType == PieceTypeEnum.Rook)
                    {
                        var temprook = (Rook)Board[x2][y2].SquarePiece;
                        temprook.Moved = true;
                    }
                    break;
                case "PawnFirst":
                    var pawn = (Pawn)Board[x2][y2].SquarePiece;
                    pawn.Moved = true;
                    break;
                case "PawnDoubleFirst":
                    var enpassantpawn = (Pawn)Board[x2][y2].SquarePiece;
                    enpassantpawn.Moved = true;
                    enpassantpawn.EnPassantTurn = _currentTurn;
                    break;
                case "EnPassant":
                    if (y1 > y2)
                    {
                        Board[x1][y1 - 1].SquarePiece = new EmptyPiece(PieceColorEnum.Empty);
                    }
                    else
                    {
                        Board[x1][y1 + 1].SquarePiece = new EmptyPiece(PieceColorEnum.Empty);
                    }
                    break;
                case "Castling":
                    var castleking = (King)Board[x2][y2].SquarePiece;
                    castleking.Moved = true;
                    if (y1 > y2)
                    {
                        var castlerook = (Rook)Board[x2][0].SquarePiece;
                        castlerook.Moved = true;
                        Board[x2][y2 + 1].SquarePiece = Board[x2][0].SquarePiece;
                        Board[x2][0].SquarePiece = new EmptyPiece(PieceColorEnum.Empty);
                    }
                    else
                    {
                        var castlerook = (Rook)Board[x2][7].SquarePiece;
                        castlerook.Moved = true;
                        Board[x2][y2 - 1].SquarePiece = Board[x2][7].SquarePiece;
                        Board[x2][7].SquarePiece = new EmptyPiece(PieceColorEnum.Empty);
                    }
                    break;
                case "Promotion":
                    PieceColorEnum PromoColor = Board[x2][y2].SquarePiece.PieceColor;
                    switch (_promotionPieceType)
                    {
                        case "Queen":
                            Board[x2][y2].SquarePiece = new Queen(PromoColor);
                            break;
                        case "Rook":
                            Board[x2][y2].SquarePiece = new Rook(PromoColor);
                            break;
                        case "Bishop":
                            Board[x2][y2].SquarePiece = new Bishop(PromoColor);
                            break;
                        case "Knight":
                            Board[x2][y2].SquarePiece = new Knight(PromoColor);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            //Last move highlights
            if (String.Equals(Type, "Castling"))
            {
                if (y1 > y2) //Long Castling
                {
                    LastMoveHighlight(x1, y1, x2, 0);
                }
                else //Short Castling
                {
                    LastMoveHighlight(x1, y1, x2, 7);
                }
            }
            else
            {
                LastMoveHighlight(x1, y1, x2, y2);
            }

            //Remove current player's king from check
            PieceColorEnum Color = (_currentTurn % 2 == 0 ? PieceColorEnum.Black : PieceColorEnum.White);
            BoardSquare KingSquare = LegalMoveGenerator.FindKing(Color, Board);
            var king = (King)KingSquare.SquarePiece;
            king.RemoveRedHighlight();
        }

        private void EvaluateGameState()
        {
            //Evaluate next player's king safety and possible moves
            PieceColorEnum Color = (_currentTurn % 2 == 1 ? PieceColorEnum.Black : PieceColorEnum.White);
            BoardSquare KingSquare = LegalMoveGenerator.FindKing(Color, Board);
            bool IsKingChecked = !LegalMoveGenerator.IsSquareSafe(Color, KingSquare.XCoordinate,
                KingSquare.YCoordinate, KingSquare.XCoordinate, KingSquare.YCoordinate, Board);

            if (IsKingChecked)
            {
                var king = (King)KingSquare.SquarePiece;
                king.RedHighlight();
            }

            _currentMoves = GetAllPossibleMoves(Color);
            if (_currentMoves.Count() != 0)
            {
                _currentTurn++;
            }
            else
            {
                if (IsKingChecked)
                {
                    GameState = (Color == PieceColorEnum.Black ? "Game State: White won!" : "Game State: Black won!");
                }
                else
                {
                    GameState = "Game State: Stalemate!";
                }
            }
        }

        public void SelectSquare(int x, int y)
        {
            if (!String.Equals(GameState, "Game State: Ongoing")) //guard clause
            {
                return;
            }
            if (_currentTurn == 1 && _currentMoves == null)
            {
                _currentMoves = GetAllPossibleMoves(PieceColorEnum.White);
            }
            //choosing
            if (_currentPiece == null)
            {
                PieceColorEnum CurrentColor = (_currentTurn % 2 == 0 ? PieceColorEnum.Black : PieceColorEnum.White);
                if (Board[x][y].SquarePiece.PieceColor == CurrentColor)
                {
                    _currentSquare = Board[x][y];
                    _currentSquare.HighlightSquare();
                    _currentPiece = _currentSquare.SquarePiece;
                }
            }
            else
            {
                if (Board[x][y].SquarePiece.PieceColor != _currentPiece.PieceColor)
                {
                    string Move = MoveEncoder.EncodeMove(_currentSquare.XCoordinate, _currentSquare.YCoordinate, x, y);
                    if (_currentMoves.ContainsKey(Move))
                    {
                        ExecuteMove(Move, _currentMoves[Move]);
                        EvaluateGameState();
                    }
                    else
                    {
                        ResetSelection();
                    }
                }
                else if (_currentSquare != Board[x][y])
                {
                    ResetSelection();
                    _currentSquare = Board[x][y];
                    _currentSquare.HighlightSquare();
                    _currentPiece = _currentSquare.SquarePiece;
                }
                else
                {
                    ResetSelection();
                }
            }
        }

        public void ChangePromotionPiece(string PieceType)
        {
            _promotionPieceType = PieceType;
        }
    }
}