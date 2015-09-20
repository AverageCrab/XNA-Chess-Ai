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
                    if (piece.Colour == PieceColour.White)
                    {
                        moves.Add(Helpers.MoveXY(piece.TilePosition.X, 0, piece.TilePosition.Y, 1));
                        moves.Add(Helpers.MoveXY(piece.TilePosition.X, 0, piece.TilePosition.Y, 2));
                        moves.Add(Helpers.MoveXY(piece.TilePosition.X, 1, piece.TilePosition.Y, 1));
                        moves.Add(Helpers.MoveXY(piece.TilePosition.X, -1, piece.TilePosition.Y, 1));
                    }
                    else if (piece.Colour == PieceColour.Black)
                    {
                        var lel = GetMaxMovesUp(pieces, piece);
                        moves.Add(Helpers.MoveXY(piece.TilePosition.X, 0, piece.TilePosition.Y, -1));
                        moves.Add(Helpers.MoveXY(piece.TilePosition.X, 0, piece.TilePosition.Y, -2));
                        moves.Add(Helpers.MoveXY(piece.TilePosition.X, 1, piece.TilePosition.Y, -1));
                        moves.Add(Helpers.MoveXY(piece.TilePosition.X, -1, piece.TilePosition.Y, -1));
                    }
                    break;
                case PieceType.Knight:
                    //Up left
                    moves.Add(Helpers.MoveXY(piece.TilePosition.X, -1, piece.TilePosition.Y, -2));
                    moves.Add(Helpers.MoveXY(piece.TilePosition.X, -2, piece.TilePosition.Y, -1));

                    //Up right
                    moves.Add(Helpers.MoveXY(piece.TilePosition.X, 1, piece.TilePosition.Y, -2));
                    moves.Add(Helpers.MoveXY(piece.TilePosition.X, 2, piece.TilePosition.Y, -1));

                    //Down left
                    moves.Add(Helpers.MoveXY(piece.TilePosition.X, -1, piece.TilePosition.Y, 2));
                    moves.Add(Helpers.MoveXY(piece.TilePosition.X, -2, piece.TilePosition.Y, 1));

                    //Down right
                    moves.Add(Helpers.MoveXY(piece.TilePosition.X, 1, piece.TilePosition.Y, 2));
                    moves.Add(Helpers.MoveXY(piece.TilePosition.X, 2, piece.TilePosition.Y, 1));
                    break;
                case PieceType.King:
                    //Up
                    moves.Add(Helpers.MoveXY(piece.TilePosition.X, 0, piece.TilePosition.Y, -1));
                    //Down
                    moves.Add(Helpers.MoveXY(piece.TilePosition.X, 0, piece.TilePosition.Y, 1));
                    //Left
                    moves.Add(Helpers.MoveXY(piece.TilePosition.X, -1, piece.TilePosition.Y, 0));
                    //Right
                    moves.Add(Helpers.MoveXY(piece.TilePosition.X, 1, piece.TilePosition.Y, 0));
                    //Up Left
                    moves.Add(Helpers.MoveXY(piece.TilePosition.X, -1, piece.TilePosition.Y, -1));
                    //Up Right
                    moves.Add(Helpers.MoveXY(piece.TilePosition.X, 1, piece.TilePosition.Y, -1));
                    //Down Left
                    moves.Add(Helpers.MoveXY(piece.TilePosition.X, -1, piece.TilePosition.Y, 1));
                    //Down Right
                    moves.Add(Helpers.MoveXY(piece.TilePosition.X, 1, piece.TilePosition.Y, 1));
                    break;
                case PieceType.Rook:
                case PieceType.Queen:
                    var maxMovesUp = GetMaxMovesDown(pieces, piece);

                    for (int i = 1; i < maxMovesUp; i++)
                    {
                        moves.Add(Helpers.MoveXY(piece.TilePosition.X, 0, piece.TilePosition.Y, i));
                    }

                    var maxMovesDown = GetMaxMovesUp(pieces, piece);

                    for (int i = 1; i < maxMovesDown; i++)
                    {
                        moves.Add(Helpers.MoveXY(piece.TilePosition.X, 0, piece.TilePosition.Y, -i));
                    }

                    var maxMovesLeft = GetMaxMovesLeft(pieces, piece);

                    for (int i = 1; i < maxMovesLeft; i++)
                    {
                        moves.Add(Helpers.MoveXY(piece.TilePosition.X, -i, piece.TilePosition.Y, 0));
                    }

                    var maxMovesRight = GetMaxMovesRight(pieces, piece);
                    for (int i = 1; i < maxMovesRight; i++)
                    {
                        moves.Add(Helpers.MoveXY(piece.TilePosition.X, i, piece.TilePosition.Y, 0));
                    }
                    break;

            }

            return moves;
        }
        //todo make a function that works out if the piece is takeable
        private static int GetMaxMovesUp(List<Piece> pieces, Piece piece)
        {
                   var closestPieceUp =
                   pieces.Where(p => p.TilePosition.Y < piece.TilePosition.Y 
                       && (p.TilePosition.X == piece.TilePosition.X && p.Colour == piece.Colour))
                       .OrderByDescending(p => p.TilePosition.Y)
                       .FirstOrDefault();
                   //if this piece is takeable and we are not doing an illegal move for a pawn say

                   var maxMovesUp = closestPieceUp != null ? (piece.TilePosition.Y - closestPieceUp.TilePosition.Y) : piece.TilePosition.Y;

            return maxMovesUp;
        }
        private static int GetMaxMovesDown(List<Piece> pieces, Piece piece)
        {
            var closestPieceDown =
                       pieces.Where(p => p.TilePosition.Y > piece.TilePosition.Y 
                           && (p.TilePosition.X == piece.TilePosition.X && p.Colour == piece.Colour))
                           .OrderBy(p => p.TilePosition.Y)
                           .FirstOrDefault();
            //todo
            var maxMovesDown = closestPieceDown != null ? ( closestPieceDown.TilePosition.Y - piece.TilePosition.Y) : piece.TilePosition.Y;
            return maxMovesDown;    
        }
        private static int GetMaxMovesLeft(List<Piece> pieces, Piece piece)
        {
            var closestPieceLeft =
                                   pieces.Where(p => p.TilePosition.X < piece.TilePosition.X && p.TilePosition.Y == piece.TilePosition.Y)
                                       .OrderByDescending(p => p.TilePosition.X)
                                       .FirstOrDefault();

            var maxMovesLeft = closestPieceLeft != null ? (piece.TilePosition.X - closestPieceLeft.TilePosition.X) : piece.TilePosition.X + 1;
            return maxMovesLeft;
        }
        private static int GetMaxMovesRight(List<Piece> pieces, Piece piece)
        {
            var closestPieceRight =
                       pieces.Where(p => p.TilePosition.X > piece.TilePosition.X && p.TilePosition.Y == piece.TilePosition.Y)
                           .OrderBy(p => p.TilePosition.X)
                           .FirstOrDefault();

            var maxMovesRight = closestPieceRight != null ? (Math.Abs(piece.TilePosition.X - closestPieceRight.TilePosition.X)) : 8 - piece.TilePosition.X;
            return maxMovesRight;
        }
        /// <summary>
        /// thought this would be nice but can't be used
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="pieces"></param>
        /// <param name="piece"></param>
        /// <returns></returns>
        private static Array[] GetMaxMovesForAxis(char axis, List<Piece> pieces, Piece piece)
        {
            return null;
        }
    }
}
