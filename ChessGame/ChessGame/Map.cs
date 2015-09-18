using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame
{
    public class Map
    {
        private List<Sprite> collisionTiles = new List<Sprite>();

        public List<Sprite> CollisionTiles
        {
            get { return collisionTiles; }
        }
        // Generate board, int size = size of tiles
        //TODO pass size to Vector2
        public void Generate(int[,] map, int size)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int number = map[y, x];
                    collisionTiles.Add(new Sprite(number,new Vector2(x*132,y*132)));
                }
            }
        }
        //Draw 
        public void Draw(SpriteBatch spriteBatch)
        {

            foreach (var tile in CollisionTiles)
            {
                tile.Draw(spriteBatch);
            }
        }
    }
}
