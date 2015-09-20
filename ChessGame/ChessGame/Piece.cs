using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame
{
    public class Piece
    {
        //The current position of the Sprite
        public Vector2 Position = new Vector2(0, 0);

        //The texture object used when drawing the sprite
        private Texture2D mPieceTexture;

        public Rectangle CollisionRect;

        private static ContentManager content;

        public BoardCoord BoardTile;

        public TilePosition TilePosition;

        public PieceType Type;

        public PieceColour Colour;

        public static ContentManager Content
        {
            protected get { return content; }
            set { content = value; }
        }

        public void Move(Vector2 pos)
        {
            BoardTile = Helpers.TileToBoardCoord((int)pos.X, (int)pos.Y);
            Position = Helpers.TileToPixel((int)pos.X, (int)pos.Y);
            TilePosition = new TilePosition() { X = (int)pos.X, Y = (int)pos.Y };
            CollisionRect = new Rectangle((int)Position.X, (int)Position.Y, 132, 132);
        }

        public Piece(string stringType, PieceColour pieceColour, Vector2 pos)
        {
            //Constants
            mPieceTexture = Content.Load<Texture2D>(stringType);
            Type = Helpers.GetPieceType(stringType);
            Colour = pieceColour;

            //Updated on move
            BoardTile = Helpers.TileToBoardCoord((int)pos.X,(int)pos.Y);
            Position = Helpers.TileToPixel((int) pos.X, (int) pos.Y);
            TilePosition = new TilePosition(){ X = (int)pos.X,Y = (int)pos.Y};
            CollisionRect = new Rectangle((int)Position.X, (int)Position.Y, 64, 64);
        }

        //Draw the sprite to the screen
        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(mPieceTexture, Position, Color.White);
        }
    }
}