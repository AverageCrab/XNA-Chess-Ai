using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame
{
    public static class Move
    {
        public static List<TilePosition> AvailableMoves(Piece piece, List<Piece> pieces)
        {
            var moves = new List<TilePosition>();
            switch (piece.Type)
            {
                case PieceType.Pawn:
                    if (piece.Type == PieceType.Pawn && piece.Colour == PieceColour.White)
                    {
                        moves.Add(Helpers.MoveXY(piece.TilePosition.Y, 0, piece.TilePosition.X, 1));
                        moves.Add(Helpers.MoveXY(piece.TilePosition.Y, 0, piece.TilePosition.X, 2));
                    }
                    else if (piece.Type == PieceType.Pawn && piece.Colour == PieceColour.Black)
                    {
                        moves.Add(Helpers.MoveXY(piece.TilePosition.Y, 0, piece.TilePosition.X, -1));
                        moves.Add(Helpers.MoveXY(piece.TilePosition.Y, 0, piece.TilePosition.X, -2));
                    }
                    break;
                case PieceType.Knight:
                    //Up left
                    moves.Add(Helpers.MoveXY(piece.TilePosition.Y, -1, piece.TilePosition.X, -2));
                    moves.Add(Helpers.MoveXY(piece.TilePosition.Y, -2, piece.TilePosition.X, -1));

                    //Up right
                    moves.Add(Helpers.MoveXY(piece.TilePosition.Y, 1, piece.TilePosition.X, -2));
                    moves.Add(Helpers.MoveXY(piece.TilePosition.Y, 2, piece.TilePosition.X, -1));

                    //Down left
                    moves.Add(Helpers.MoveXY(piece.TilePosition.Y, -1, piece.TilePosition.X, 2));
                    moves.Add(Helpers.MoveXY(piece.TilePosition.Y, -2, piece.TilePosition.X, 1));

                    //Down right
                    moves.Add(Helpers.MoveXY(piece.TilePosition.Y, 1, piece.TilePosition.X, 2));
                    moves.Add(Helpers.MoveXY(piece.TilePosition.Y, 2, piece.TilePosition.X, 1));
                    break;
                case PieceType.King:
                    //Up
                    moves.Add(Helpers.MoveXY(piece.TilePosition.Y, 0, piece.TilePosition.X, -1));
                    //Down
                    moves.Add(Helpers.MoveXY(piece.TilePosition.Y, 0, piece.TilePosition.X, 1));
                    //Left
                    moves.Add(Helpers.MoveXY(piece.TilePosition.Y, -1, piece.TilePosition.X, 0));
                    //Right
                    moves.Add(Helpers.MoveXY(piece.TilePosition.Y, 1, piece.TilePosition.X, 0));
                    //Up Left
                    moves.Add(Helpers.MoveXY(piece.TilePosition.Y, -1, piece.TilePosition.X, -1));
                    //Up Right
                    moves.Add(Helpers.MoveXY(piece.TilePosition.Y, 1, piece.TilePosition.X, -1));
                    //Down Left
                    moves.Add(Helpers.MoveXY(piece.TilePosition.Y, -1, piece.TilePosition.X, 1));
                    //Down Right
                    moves.Add(Helpers.MoveXY(piece.TilePosition.Y, 1, piece.TilePosition.X, 1));
                    break;
                case PieceType.Rook:
                case PieceType.Queen:
                    var closestPieceUp =
                   pieces.Where(p => p.TilePosition.X < piece.TilePosition.X && p.TilePosition.Y == piece.TilePosition.Y)
                       .OrderByDescending(p => p.TilePosition.X)
                       .FirstOrDefault();

                    var maxMovesUp = closestPieceUp != null ? (piece.TilePosition.X - closestPieceUp.TilePosition.X) : piece.TilePosition.X + 1;
                    for (int i = 1; i < maxMovesUp; i++)
                    {
                        moves.Add(Helpers.MoveXY(piece.TilePosition.Y, 0, piece.TilePosition.X, -i));
                    }

                    var closestPieceDown =
                        pieces.Where(p => p.TilePosition.X > piece.TilePosition.X && p.TilePosition.Y == piece.TilePosition.Y)
                            .OrderBy(p => p.TilePosition.X)
                            .FirstOrDefault();

                    var maxMovesDown = closestPieceDown != null ? (Math.Abs(piece.TilePosition.X - closestPieceDown.TilePosition.X)) : 8 - piece.TilePosition.X;
                    for (int i = 1; i < maxMovesDown; i++)
                    {
                        moves.Add(Helpers.MoveXY(piece.TilePosition.Y, 0, piece.TilePosition.X, i));
                    }

                    var closestPieceLeft =
                        pieces.Where(p => p.TilePosition.Y < piece.TilePosition.Y && p.TilePosition.X == piece.TilePosition.X)
                            .OrderByDescending(p => p.TilePosition.Y)
                            .FirstOrDefault();

                    var maxMovesLeft = closestPieceLeft != null ? (piece.TilePosition.Y - closestPieceLeft.TilePosition.Y) : piece.TilePosition.Y + 1;
                    for (int i = 1; i < maxMovesLeft; i++)
                    {
                        moves.Add(Helpers.MoveXY(piece.TilePosition.Y, -i, piece.TilePosition.X, 0));
                    }

                    var closestPieceRight =
                        pieces.Where(p => p.TilePosition.Y > piece.TilePosition.Y && p.TilePosition.X == piece.TilePosition.X)
                            .OrderBy(p => p.TilePosition.Y)
                            .FirstOrDefault();

                    var maxMovesRight = closestPieceRight != null ? (Math.Abs(piece.TilePosition.Y - closestPieceRight.TilePosition.Y)) : 8 - piece.TilePosition.Y;
                    for (int i = 1; i < maxMovesRight; i++)
                    {
                        moves.Add(Helpers.MoveXY(piece.TilePosition.Y, i, piece.TilePosition.X, 0));
                    }
                    break;

            }

            return moves;
        }
    }
}
