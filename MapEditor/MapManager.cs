using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LunarIllusions.Map;
using LunarIllusions.Controllers;
using System.Reflection;
using LunarIllusions.Sprites;

namespace LunarIllusions
{
    internal class MapManager
    {

        private MapScreen CurrentMap;

        public MouseController MouseObject { get; }
        public KeyboardController KeyboardObject { get; }

        private static MapManager instance;

        public static MapManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new MapManager();
                }
                return instance;
            }
        }

        public MapManager()
        {
            
            CurrentMap = new MapScreen(Configuration.DefaultXTiles, Configuration.DefaultYTiles);
            MouseObject = new MouseController();
            KeyboardObject = new KeyboardController();

            instance = this;

        }

        internal void Initialize(GraphicsDeviceManager graphics)
        {
        //    throw new NotImplementedException();
        }

        internal void Update(GameTime gameTime)
        {
            MouseObject.Update(gameTime);
            KeyboardObject.Update(gameTime);

            if(!SpriteSheetManager.Instance.IsOpen)
                CurrentMap.Update(gameTime, MouseObject);
            //    throw new NotImplementedException();
        }

        internal void LoadContent(SpriteBatch spriteBatch)
        {
        //    throw new NotImplementedException();
        }

        internal void UnloadContent()
        {
        //    throw new NotImplementedException();
        }

        internal void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //    throw new NotImplementedException();
            CurrentMap.Draw(spriteBatch);
        }

        //typeof(MyType).GetMethod("add").Invoke(null, new [] {arg1, arg2})

        internal void CallFunction(String action)
        {
            Type thisType = this.GetType();
            MethodInfo theMethod = thisType.GetMethod(action);
            theMethod.Invoke(this, null);

        }

        //Testing the dynamic function call 
        public void LoremIpsum()
        {
            Console.WriteLine("LoremIpsum");
        }

    }
}