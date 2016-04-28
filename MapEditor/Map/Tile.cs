using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using MapEditor.Sprites;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.Map
{
    class Tile
    {
        

        public int Width { get; }
        public int Height { get; }

        private float X;
        private float Y;        
        private int defaultTileWidth;
        private int defaultTileHeight;

        private TileType type = TileType.Default;

        private SpriteSheet connectedSheet = null;
        private Tile SelectedTile;

        public Rectangle DestinationRectangle
        {
            get
            {
                return new Rectangle((int)(X * defaultTileWidth), (int)(Y * defaultTileHeight),defaultTileWidth, defaultTileHeight);
            }
        }
        public TileType Type
        {
            get
            {
                return type;
            }
        }

        public Tile(int x, int y, int defaultTileWidth, int defaultTileHeight)
        {
            this.X = x;
            this.Y = y;

            this.defaultTileWidth = defaultTileWidth;
            this.defaultTileHeight = defaultTileHeight;
            this.type = TileType.Default;
        }        

        public void SetType(TileType newType)
        {
            this.type = newType;
        }

        public void Reset()
        {
            this.type = TileType.Default;
            this.connectedSheet = null;
            this.SelectedTile = null;
        }

        internal void SetTile(SpriteSheet spriteSheet)
        {
           
            if (spriteSheet != null)
            {
                connectedSheet = spriteSheet;
                this.SelectedTile = connectedSheet.SelectedTile();
                this.type = SelectedTile.GetTileType();
            }

        }

        private TileType GetTileType()
        {
            return this.type;
        }

        internal bool HasSelectedTile()
        {
            return connectedSheet != null;
        }

        internal Texture2D GetTexture()
        {
            return connectedSheet.GetTexture();
        }

        internal Rectangle? GetSourceRectangle()
        {
            return SelectedTile.DestinationRectangle;
        }
    }
}
