using System.Collections.Generic;

namespace ChessGame
{
    public static class Move
    {
        public static List<TilePosition> AvailableMoves(Piece piece)
        {
            var moves = new List<TilePosition>();
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
            if (piece.Type == PieceType.Knight)
            {
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
            }
            if (piece.Type == PieceType.King)
            {
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
            }
            return moves;
        }
    }
}
