using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.Sprites
{
    class SpriteSheet
    {

        public String TabName { get; private set; }
        public SpriteSheetType Type { get; private set; }
        private Texture2D Texture;

        public SpriteSheet(String spriteSheet, SpriteSheetType type, SpriteSheetConfiguration Config)
        {
            this.TabName = spriteSheet;
            this.Texture = ContentConfiguration.Instance.LoadGlobalTexture(spriteSheet);
            this.Type = type;
            
            if(type == SpriteSheetType.Tile)
            {
                
            }

        }

        public void Update()
        {

        }

        public void Draw()
        {

        }
    }
}
