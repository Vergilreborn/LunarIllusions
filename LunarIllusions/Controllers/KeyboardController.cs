using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace LunarIllusions.Controllers
{
    class KeyboardController
    {
        
        private KeyboardState Current;
        private KeyboardState Previous;
        private KeyboardState PreviousPrevious;


        public KeyboardController()
        {
            this.Current = Keyboard.GetState();
            this.Previous = Current;
            this.PreviousPrevious = Previous;
        }

        public void Update(GameTime gameTime)
        {
            PreviousPrevious = Previous;
            Previous = Current;
            Current = Keyboard.GetState();
        }

        public bool KeyDown(String key)
        {
            Keys checkKey = (Keys)Enum.Parse(typeof(Keys), key.ToString());
            bool keyPressed = Current.IsKeyDown(checkKey);

            return keyPressed;
        }

        public bool KeyPressed(String key)
        {
            Keys checkKey = (Keys)Enum.Parse(typeof(Keys), key.ToString());
            bool keyPressed = Current.IsKeyDown(checkKey) && Previous.IsKeyUp(checkKey);

            return keyPressed;
        }
    }
}
