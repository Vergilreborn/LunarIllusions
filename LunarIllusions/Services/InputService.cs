using LunarIllusions.Controllers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarIllusions.Services
{
    class InputService
    {

        private static InputService _instance;
        public static InputService Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new InputService();
                }
                return _instance;
            }
        }

        public KeyboardController Keyboard {   get; private set;}
        public MouseController Mouse { get; private set; }

        public InputService()
        {
            Keyboard = new KeyboardController();
            Mouse = new MouseController();
        }

        public void Initalize()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            Keyboard.Update(gameTime);
            Mouse.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //Keyboard.Draw(gameTime);
            //Mouse.Draw(gameTime);
        }
    }
}
