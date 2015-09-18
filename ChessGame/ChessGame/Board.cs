using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame
{
    public class Board
    {
        private string[,] _pieceGrid = new string[8, 8]
        {
            {"wrook","wknight","wbishop","wking","wqueen","wbishop","wknight","wrook"},
            {"wpawn","wpawn","wpawn","wpawn","wpawn","wpawn","wpawn","wpawn"},
            {"","","","","","","",""},
            {"","","","","","","",""},
            {"","","","","","","",""},
            {"","","","","","","",""},
            {"bpawn","bpawn","bpawn","bpawn","bpawn","bpawn","bpawn","bpawn"},
            {"brook","bknight","bbishop","bking","bqueen","bbishop","bknight","brook"}
        };
        public List<Piece> Pieces = new List<Piece>();

        public void InitialLayout()
        {
            for (int x = 0; x < _pieceGrid.GetLength(1); x++)
            {
                for (int y = 0; y < _pieceGrid.GetLength(0); y++)
                {
                    string name = _pieceGrid[y, x];
                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        Pieces.Add(new Piece(name, name.StartsWith("w") ? PieceColour.White : PieceColour.Black, new Vector2(x, y)));  
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var piece in Pieces)
            {
                piece.Draw(spriteBatch);
            }
        }
    }
}
