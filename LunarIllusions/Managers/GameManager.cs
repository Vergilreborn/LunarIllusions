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
            player = XmlObject<PlayerObject>.Load(@"PlayerBase.xml");//HardCode.HardCoded.GeneratePlayerObject();
            player.Destination = new Rectangle(32, 32, 32, 32); //Set when loading Map
        }
       
        public void Initialize()
        {
            
            player.Initialize();
            
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
