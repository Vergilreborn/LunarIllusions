using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunarIllusions.Configurations
{
    class Configuration
    {
        #region Integer based configuration
        public static int DefaultXTiles     = 40; //Default number of X column of tiles
        public static int DefaultYTiles     = 40; //Default number of Y column of tiles
        public static int DefaultTileWidth  = 32; //Default tile width
        public static int DefaultTileHeight = 32; //Default tile height
        public static int LineWidth         = 1;  //Default line thickness of outlining tiles
        #endregion

        #region Float based configuration
        public static float ClickTimer = 300f;    //Time to check click
        public static float OpacityLevel = 0.30f;  //Opacity of the overlay 0.0 - 1.0
        #endregion

        #region String based configuration
        public static string EmptyTextureName = "Empty"; //
        public static string SpriteSheetConfigurationFile = "Configuration/SpriteSheetConfiguration.xml";  //Xml location of the sprite sheet information
        #endregion



    }
}
