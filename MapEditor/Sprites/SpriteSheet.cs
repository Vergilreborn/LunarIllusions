﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LunarIllusions.Map;
using LunarIllusions.Controllers;
using Microsoft.Xna.Framework.Content;

namespace LunarIllusions.Sprites
{
    public class SpriteSheet
    {

        public String TabName;
        public String ImageFile;
        public int TileWidth;
        public int TileHeight;


        private Texture2D Texture;
        private Tile[,] Tiles;
        private int TileXCount;
        private int TileYCount;
        private Tile CurrentOver;
        private Tile Selected;

      
        public SpriteSheet()
        {
            this.TabName = "";
            this.TileWidth= Configuration.DefaultTileWidth;
            this.TileHeight = Configuration.DefaultTileHeight;
            this.ImageFile = "";
            Tiles = new Tile[0,0]; //Defaulting to an empty set of tiles
            TileXCount = 0;
            TileYCount = 0;
        }

        internal void Setup(ContentManager Content)
        {
            
            Texture = Content.Load<Texture2D>(ImageFile);
            ContentConfiguration.Instance.SaveGlobalTexture(Texture, ImageFile);

            TileXCount = Texture.Width / TileHeight;
            TileYCount = Texture.Height / TileWidth;

            Tiles = new Tile[TileXCount, TileYCount];

            for(int x = 0; x < TileXCount; x++)
            {
                for (int y = 0; y < TileYCount; y++)
                {
                    Tiles[x, y] = new Tile(x, y, TileWidth, TileHeight);
                }
            }

        }
        
        public void Update(Vector2 camPosition)
        {
            
            MouseController mouse = MapManager.Instance.MouseObject; 
            
            int xTileOver = (int)((mouse.Position.X - camPosition.X) / Configuration.DefaultTileWidth);
            int yTileOver = (int)((mouse.Position.Y - camPosition.Y)  / Configuration.DefaultTileHeight);
            bool validXTile = xTileOver < TileXCount && xTileOver > -1;
            bool validYTile = yTileOver < TileYCount && yTileOver > -1;

            CurrentOver = null;

            if (validXTile && validYTile)
            {
                CurrentOver = Tiles[xTileOver, yTileOver];
            }
            
            if (mouse.LeftMouseAction == MouseAction.MouseDown && validXTile && validYTile)
            {
                //set Selected
                Selected = Tiles[xTileOver, yTileOver];
                
            }
        }

        internal Texture2D GetTexture()
        {
            return Texture;
        }

        internal Tile SelectedTile()
        {
            return Selected;
        }

        

        internal void Draw(SpriteBatch spriteBatch, Vector2 camPosition)
        {
            Texture2D whiteRectangle = ContentConfiguration.Instance.EmptyTexture();
            
            //TO DO: Draw the tile in the correct position with the correct
            //source object (THIS WILL BE USED WITH THE TILESET ON THE MAP SCREEN
            //Texture 
            foreach (Tile tile in Tiles)
            {
             
                Rectangle destRec = new Rectangle(tile.DestinationRectangle.X + (int)camPosition.X
                                                , tile.DestinationRectangle.Y + (int)camPosition.Y
                                                , tile.DestinationRectangle.Width
                                                , tile.DestinationRectangle.Height);
                spriteBatch.Draw(Texture, destRec,tile.DestinationRectangle, Color.White);
                ContentConfiguration.Instance.DrawRectangle(spriteBatch, destRec, Color.DarkGray);
            }

            if (Selected != null)
            {
                Rectangle destRec = new Rectangle(Selected.DestinationRectangle.X + (int)camPosition.X
                                                , Selected.DestinationRectangle.Y + (int)camPosition.Y
                                                , Selected.DestinationRectangle.Width
                                                , Selected.DestinationRectangle.Height);
                spriteBatch.Draw(whiteRectangle, destRec, Selected.DestinationRectangle, new Color(Color.Blue, Configuration.OpacityLevel));
                ContentConfiguration.Instance.DrawRectangle(spriteBatch, destRec, Color.DarkRed);
            }

            if (CurrentOver != null)
            {
                Rectangle destRec = new Rectangle(CurrentOver.DestinationRectangle.X + (int)camPosition.X
                                                , CurrentOver.DestinationRectangle.Y + (int)camPosition.Y
                                                , CurrentOver.DestinationRectangle.Width
                                                , CurrentOver.DestinationRectangle.Height);
                spriteBatch.Draw(whiteRectangle, destRec,CurrentOver.DestinationRectangle, new Color(Color.Red,Configuration.OpacityLevel));
                ContentConfiguration.Instance.DrawRectangle(spriteBatch, destRec, Color.DarkRed);
            }

          
        }


    }
}
