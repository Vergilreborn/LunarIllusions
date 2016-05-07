using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LunarIllusions.GameObjects;
using LunarIllusions.Helper;

namespace LunarIllusions.Managers
{
    class GameManager
    {
        PlayerObject player;

        public GameManager()
        {
            player = HardCode.HardCoded.GeneratePlayerObject();
        }
       
        public void Initialize()
        {
            
            player.Initialize();
            XmlObject<PlayerObject>.Save(@"C:\Users\Alexander\Desktop\PlayerObject.xml", player);
        }

        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
        }
        
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            player.Draw(gameTime,spriteBatch);
        }

        internal void UnloadContent()
        {
           
        }

        internal void LoadContent()
        {
           
        }
    }
}
