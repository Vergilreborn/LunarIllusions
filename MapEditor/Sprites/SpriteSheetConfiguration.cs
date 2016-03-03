using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MapEditor.Sprites
{
    public class SpriteSheetConfiguration
    {

        public SpriteSheet[] SpriteSheets;
        public SpriteSheet active;

        public SpriteSheetConfiguration()
        {
            SpriteSheets = new SpriteSheet[0]; //Setting up an empty array
        }

        public void LoadContent(ContentManager Content)
        {

            foreach(SpriteSheet sheet in SpriteSheets)
            {
                sheet.Setup(Content);
            }
        }


        public void Update(Vector2 camPosition)
        {
            foreach (SpriteSheet sheet in SpriteSheets)
            {
                sheet.Update(camPosition);
            }

            //TODO: Remove the hardcoded spriteSheet selected. Udating the code to actually use sprite sheet graphics
            active = SpriteSheets[0];
        }

        internal void Draw(SpriteBatch spriteBatch, Vector2 camPosition)
        {
            foreach (SpriteSheet sheet in SpriteSheets)
            {
                sheet.Draw(spriteBatch,camPosition);
            }
        }
    }
}
