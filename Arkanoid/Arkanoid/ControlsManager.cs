using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arkanoid
{
    class ControlsManager
    {
        Game1 game;
        MouseState prevMouseState; //Mouse state from previous frame stored here

        public ControlsManager(Game1 g)
        {
            game = g;
        }

        public void Update()
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                game.Exit();

            // Keyboard controls
            KeyboardState keyboardsState = Keyboard.GetState();

            if (keyboardsState.IsKeyDown(Keys.Left))
                game.Player.position.X -= game.Player.Speed;
            else if (keyboardsState.IsKeyDown(Keys.Right))
                game.Player.position.X += game.Player.Speed;

            //Move mouse along with the player
            if (keyboardsState.GetPressedKeys().Length != 0)
            {
                Mouse.SetPosition((int)game.Player.position.X,
                    (int)game.Player.position.Y);
            }

            //Mouse controls
            MouseState mouseState = Mouse.GetState();
            if (mouseState.X != prevMouseState.X ||
            mouseState.Y != prevMouseState.Y)
               game.Player.position.X = mouseState.X;
            prevMouseState = mouseState;
        }
    }
}
