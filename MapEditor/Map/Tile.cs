using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

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
        }        

        public void SetType(TileType newType)
        {
            this.type = newType;
        }

        public void Reset()
        {
            this.type = TileType.Default;
        }
    }
}
