using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ChessGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch spriteBatch;
        private int[,] _currentGrid = new int[8, 8]
        {
            {0,1,0,1,0,1,0,1},
            {1,0,1,0,1,0,1,0},
            {0,1,0,1,0,1,0,1},
            {1,0,1,0,1,0,1,0},
            {0,1,0,1,0,1,0,1},
            {1,0,1,0,1,0,1,0},
            {0,1,0,1,0,1,0,1},
            {1,0,1,0,1,0,1,0},
        };

        Sprite mSprite;
        Map _map = new Map();
        Board _board = new Board();
        private MouseState currentMouseState;
        private MouseState lastMouseState;
        private Piece PieceSelected;
        private List<TilePosition> AvailableMoves;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Sprite.Content = Content;
            Piece.Content = Content;
            _map.Generate(_currentGrid, 132);
            _board.InitialLayout();
            // TODO: use this.Content to load your game content here

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // The active state from the last frame is now old
            lastMouseState = currentMouseState;

            // Get the mouse state relevant for this frame
            currentMouseState = Mouse.GetState();

            // Recognize a single click of the left mouse button
            if (lastMouseState.LeftButton == ButtonState.Released && currentMouseState.LeftButton == ButtonState.Pressed)
            {
                if (PieceSelected != null)
                {
                    var tileReference = Helpers.PixelToTile(currentMouseState.X, currentMouseState.Y);
                    // helper.inbounds
                    if (tileReference.X >= 0 && tileReference.X <= 7 && tileReference.Y >= 0 && tileReference.Y <= 7)
                    {
                        if (_currentGrid[(int)tileReference.Y, (int)tileReference.X] == 3)
                        {
                            PieceSelected.Move(tileReference);
                        }
                    }
                    PieceSelected = null;
                    _currentGrid = new int[8, 8]
                            {
                                {0, 1, 0, 1, 0, 1, 0, 1},
                                {1, 0, 1, 0, 1, 0, 1, 0},
                                {0, 1, 0, 1, 0, 1, 0, 1},
                                {1, 0, 1, 0, 1, 0, 1, 0},
                                {0, 1, 0, 1, 0, 1, 0, 1},
                                {1, 0, 1, 0, 1, 0, 1, 0},
                                {0, 1, 0, 1, 0, 1, 0, 1},
                                {1, 0, 1, 0, 1, 0, 1, 0},
                            };
                    _map.Generate(_currentGrid, 132);
                }
                else
                {
                    CheckForMouseClick();
                }
            }
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }
        //Checks for move mouse click 
        private void CheckForMouseClick()
        {
            foreach (var piece in _board.Pieces)
            {
                bool pieceClicked = piece.CollisionRect.Contains(currentMouseState.X, currentMouseState.Y);
                if (pieceClicked)
                {
                    _currentGrid = new int[8, 8]
                            {
                                {0, 1, 0, 1, 0, 1, 0, 1},
                                {1, 0, 1, 0, 1, 0, 1, 0},
                                {0, 1, 0, 1, 0, 1, 0, 1},
                                {1, 0, 1, 0, 1, 0, 1, 0},
                                {0, 1, 0, 1, 0, 1, 0, 1},
                                {1, 0, 1, 0, 1, 0, 1, 0},
                                {0, 1, 0, 1, 0, 1, 0, 1},
                                {1, 0, 1, 0, 1, 0, 1, 0},
                            };
                    _currentGrid[piece.TilePosition.X, piece.TilePosition.Y] = 2;
                    PieceSelected = piece;
                    //Where can we move 
                    AvailableMoves = Move.AvailableMoves(PieceSelected,_board.Pieces);
                    foreach (var move in AvailableMoves.Where(am => (am.X >= 0 && am.X <= 7) && (am.Y >= 0 && am.Y <= 7)))
                    {
                        //colour 
                        _currentGrid[move.Y, move.X] = 3;
                    }
                    _map.Generate(_currentGrid, 132);
                }
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            _graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            _map.Draw(spriteBatch);
            _board.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
