using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LunarIllusions.Helper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using LunarIllusions.Map;

namespace LunarIllusions.Sprites
{
    class SpriteSheetManager
    {
        //Create spritesheet tabs

        SpriteSheetConfiguration SpriteSheetConfig;

        private static SpriteSheetManager _instance;
        public static SpriteSheetManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SpriteSheetManager();
                return _instance;
            }
        }


        public bool IsOpen = false;

        public SpriteSheetManager()
        {
            this.SpriteSheetConfig = XmlObject<SpriteSheetConfiguration>.Load(Configuration.SpriteSheetConfigurationFile);

            
            /*Testing Saving the Xml Serializer output*/
            //SpriteSheetConfig = new SpriteSheetConfiguration();
            //SpriteSheetConfig.SpriteSheets = new SpriteSheet[2];
            //SpriteSheetConfig.SpriteSheets[0] = new SpriteSheet() { Image = "Testing/This", TabName = "TestingAgain", TileHeight = 10, TileWidth = 10 };
            //SpriteSheetConfig.SpriteSheets[1] = new SpriteSheet() { Image = "Testing/This222", TabName = "TestingAgain222", TileHeight = 90, TileWidth = 90 };
            //XmlObject<SpriteSheetConfiguration>.Save(@"C:\users\Alexander\desktop\testingThisFile.xml", SpriteSheetConfig);


        }

        public void LoadContent(ContentManager Content)
        {
            this.SpriteSheetConfig.LoadContent(Content);
        }

        public void Update(Vector2 camPosition)
        {
            this.SpriteSheetConfig.Update(camPosition);
        }

        internal void Draw(SpriteBatch spriteBatch, Vector2 camPosition)
        {
            this.SpriteSheetConfig.Draw(spriteBatch, camPosition);
        }

        internal SpriteSheet GetSelectedSpriteSheet()
        {
            return this.SpriteSheetConfig.SelectedSpriteSheet();
        }
    }
}
