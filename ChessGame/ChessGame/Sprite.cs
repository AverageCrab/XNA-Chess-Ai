using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame
{
    public class Sprite
    {
        //The current position of the Sprite
        public Vector2 Position = new Vector2(0, 0);

        //The texture object used when drawing the sprite
        private Texture2D mSpriteTexture;

        private static ContentManager content;

        public static ContentManager Content
        {
            protected get { return content; }
            set { content = value; }
        }

        private string colour;

        public Sprite(int i, Vector2 pos)
        {
            Position = pos;
            switch (i)
            {
                case 0:
                    colour = "white";
                    break;
                case 1:
                    colour = "black";
                    break;
                case 2:
                    colour = "green";
                    break;
                case 3:
                    colour = "blue";
                    break;
                default:
                    break;
            }
            mSpriteTexture = Content.Load<Texture2D>(colour);
        }

        //Draw the sprite to the screen
        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(mSpriteTexture, Position, Color.White);
        }
    }
}
