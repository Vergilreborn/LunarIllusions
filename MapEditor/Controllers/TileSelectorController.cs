using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using LunarIllusions.Map;
namespace LunarIllusions.Controllers
{
    //This object is connected to the mouse
    class TileSelectorController
    {

        private static TileSelectorController instance;
        public static TileSelectorController Instance
        {
            get
            {
                if (instance == null)
                    instance = new TileSelectorController();
                return instance;
            }
        }

        private Tile tile;
        


        public TileSelectorController()
        {
        }

        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
