using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame
{
    public static class Move
    {
        public static List<BoardCoord> AvailableMoves(Piece piece)
        {
            var moves = new List<BoardCoord>();
            if (piece.Type == PieceType.Pawn && piece.Colour == PieceColour.White)
            {
                moves.Add(new BoardCoord() {XRank = piece.BoardTile.XRank, YRank = Helpers.DecrementYRank(piece.BoardTile.YRank,1)});
                moves.Add(new BoardCoord() { XRank = piece.BoardTile.XRank, YRank = Helpers.DecrementYRank(piece.BoardTile.YRank,2)});
            } else
            if (piece.Type == PieceType.Pawn && piece.Colour == PieceColour.Black)
            {
                moves.Add(new BoardCoord() { XRank = piece.BoardTile.XRank, YRank = Helpers.IncrementYRank(piece.BoardTile.YRank, 1) });
                moves.Add(new BoardCoord() { XRank = piece.BoardTile.XRank, YRank = Helpers.IncrementYRank(piece.BoardTile.YRank, 2) });
            }
            if (piece.Type == PieceType.Knight)
            {
                //up left
                moves.Add(Helpers.MoveXY(piece.BoardTile.XRank, -1, piece.BoardTile.YRank, 2));
                //UP AND LEFFT
                moves.Add(Helpers.MoveXY(piece.BoardTile.XRank, -2, piece.BoardTile.YRank, 1));
                //down left
                moves.Add(Helpers.MoveXY(piece.BoardTile.XRank, -2, piece.BoardTile.YRank, -1));
                //DOWN LEFT AGAIN
                moves.Add(Helpers.MoveXY(piece.BoardTile.XRank, -1, piece.BoardTile.YRank, -2));
                //up right
                moves.Add(Helpers.MoveXY(piece.BoardTile.XRank, 1, piece.BoardTile.YRank, 2));
                //UP AND RIGHT?lol
                moves.Add(Helpers.MoveXY(piece.BoardTile.XRank, 2, piece.BoardTile.YRank, 1));
                //down right
                moves.Add(Helpers.MoveXY(piece.BoardTile.XRank, 1, piece.BoardTile.YRank, -2));
                //DOWN RIGHT AGAIN
                moves.Add(Helpers.MoveXY(piece.BoardTile.XRank, 2, piece.BoardTile.YRank, -1));
            }
            return moves;
        }
    }
}
