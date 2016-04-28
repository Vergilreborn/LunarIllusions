using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MapEditor.Controllers;
using MapEditor.Sprites;

namespace MapEditor.Map
{
    class TileSet
    {

        private int TileXCount;
        private int TileYCount;

        private Tile[,] Tiles;
        private Tile CurrentOver;

        /// <summary>
        ///  Create a TileSet of X and Y Tiles
        /// </summary>
        /// <param name="_TileXCount">Tile Set * of X Tiles</param>
        /// <param name="_TileYCount">Tile Set * of Y Tiles</param>
        public TileSet(int _TileXCount, int _TileYCount)
        {
            this.TileXCount = _TileXCount;
            this.TileYCount = _TileYCount;

           


            this.Tiles = NewTileSet();
        }

        /// <summary>
        /// Creates an empty map of tiles with the width and height of the current TileSet
        /// </summary>
        /// <returns></returns>
        private Tile[,] NewTileSet()
        {
            Tile[,] tileSet = new Tile[this.TileXCount, this.TileYCount];

            for(int x = 0; x < TileXCount; x++)
            {
                for (int y = 0; y < TileYCount; y++)
                {
                    tileSet[x, y] = new Tile(x, y,Configuration.DefaultTileWidth, Configuration.DefaultTileHeight);
                }
            }

            return tileSet;
        }


        public void Update(GameTime gameTime, MouseController mouse)
        {
            /*TODO: DO NOT ASSUME STARING POSITION IS 0,0 (IMAGINE POSSIBILITY OF OFFSET) */
            int xTileOver = (int)(mouse.Position.X / Configuration.DefaultTileWidth);
            int yTileOver = (int)(mouse.Position.Y / Configuration.DefaultTileHeight);
            bool validXTile = xTileOver < TileXCount && xTileOver > -1;
            bool validYTile = yTileOver < TileYCount && yTileOver > -1;

            CurrentOver = null;

            if (validXTile && validYTile) {
                CurrentOver = Tiles[xTileOver, yTileOver];
            }

            //Clear current Tile
            if (mouse.RightMouseAction == MouseAction.MouseDown) 
            {
                if(CurrentOver != null)
                    CurrentOver.Reset();
            }

            //Draw selected Tile
            if(mouse.LeftMouseAction == MouseAction.MouseDown)
            {
                if (CurrentOver != null)
                {
                    CurrentOver.SetTile(SpriteSheetManager.Instance.GetSelectedSpriteSheet());
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            Texture2D whiteRectangle = ContentConfiguration.Instance.EmptyTexture();


            foreach (Tile tile in Tiles)
            {
                if (tile.HasSelectedTile())
                {
                    spriteBatch.Draw(tile.GetTexture(), tile.DestinationRectangle, tile.GetSourceRectangle(), Color.White);
                }
                else
                {
                    spriteBatch.Draw(whiteRectangle, tile.DestinationRectangle, Color.White);
                }
                ContentConfiguration.Instance.DrawRectangle(spriteBatch, tile.DestinationRectangle, Color.DarkGray);
            }

            if (CurrentOver != null)
            {

                spriteBatch.Draw(whiteRectangle, CurrentOver.DestinationRectangle, new Color(Color.Red,0.5f));
                ContentConfiguration.Instance.DrawRectangle(spriteBatch, CurrentOver.DestinationRectangle, Color.DarkRed);
            }


        }
    }
}
