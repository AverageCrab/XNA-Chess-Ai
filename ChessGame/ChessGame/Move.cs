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
            return moves;
        }
    }
}
