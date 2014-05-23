using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Reflection;

namespace Arkanoid
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D gameBackground;
        Rectangle backgroundRectangle;

        ControlsManager controls;


        GameManager gameManager;
        public Player Player { get; set; }
        public Ball Ball { get; set; }
        HUD hud;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 480;
            graphics.PreferredBackBufferWidth = 320;

            Content.RootDirectory = "Content";
            

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Player = new Player(this);

            Ball = new Ball(this, Player.GetBallStartingPos());

            backgroundRectangle = new Rectangle(0, 0,
                Window.ClientBounds.Width,
                Window.ClientBounds.Height);

            hud = new HUD(this);
            

            gameManager = new GameManager(this);
            controls = new ControlsManager(this);

            

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

            gameBackground = Content.Load<Texture2D>(@"Images/background");
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
            controls.Update();
            if (Ball.Launched) Ball.Move();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //Draw Background
            //spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.Opaque, SamplerState.LinearWrap,
            //    DepthStencilState.Default, RasterizerState.CullNone);
            //spriteBatch.Draw(gameBackground, Vector2.Zero, backgroundRectangle, Color.White);
            //spriteBatch.End();

            //Other stuff
            spriteBatch.Begin();
            hud.Draw(spriteBatch);
            Player.Draw(spriteBatch);
            Ball.Draw(spriteBatch);
            


            spriteBatch.End();

            base.Draw(gameTime);
        }


        internal void LostBall()
        {
            Player.Lives--;
            Ball.Reset(Player);
            if (Player.Lives <= 0)
                GameOver();
        }

        private void GameOver()
        {
            hud.LoadDialog();
        }

        

        
    }
}
