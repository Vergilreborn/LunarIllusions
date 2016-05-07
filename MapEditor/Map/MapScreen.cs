using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LunarIllusions.Controllers;

namespace LunarIllusions.Map
{
    class MapScreen
    {
        private TileSet _backgroundLayer;  //background layer
        private TileSet _normalLayer;      //default layer 
        private TileSet _foregroundLayer;  //foreground layer
        private TileSet selectedLayer;
        public int XTotalTiles { get; }   //X axis # of tiles
        public int YTotalTiles { get; }   //Y axis # of tiles

        
        //Initializes the Map with a default x number of tiles and y number of tiles
        public MapScreen(int _XTotalTiles, int _YTotalTiles)
        {
            this.XTotalTiles = _XTotalTiles;
            this.YTotalTiles = _YTotalTiles;

            _backgroundLayer = new TileSet(_XTotalTiles, _YTotalTiles);
            _normalLayer     = new TileSet(_XTotalTiles, _YTotalTiles);
            _foregroundLayer = new TileSet(_XTotalTiles, _YTotalTiles);

            selectedLayer = _normalLayer;

        }

      
        public void Update(GameTime gameTime,MouseController mouseObject)
        {
            selectedLayer.Update(gameTime, mouseObject);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //_backgroundLayer.Draw(spriteBatch);
            //_normalLayer.Draw(spriteBatch);
            //_foregroundLayer.Draw(spriteBatch);

            selectedLayer.Draw(spriteBatch);
        }
    }
}
