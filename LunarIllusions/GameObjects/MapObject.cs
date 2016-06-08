using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.Serialization;
using LunarIllusions.Configurations;

namespace LunarIllusions.GameObjects
{
    [Serializable]
    class MapObject : GameObject
    {

        [DataMember()]
        public GameTile[,] Tiles;
        [DataMember()]
        public string Texture;
        [DataMember()]
        public int TotalXTiles;
        [DataMember()]
        public int TotalYTiles;
        [DataMember()]
        public Vector2 StartLocation;

        public override void Initialize()
        {
         
        }

        public override void Load()
        {
         
        }

        public override void Update(GameTime gameTime)
        {
    
        }

        public void DrawBoundBox(GameObject player, SpriteBatch spriteBatch)
        {
            int x1 = (player.Destination.X / 32);// - 1;
            int y1 = (player.Destination.Y / 32);// - 1;
            int x2 = player.Destination.X / 32 + /*1 +*/ (player.Destination.X % 32 > 0 ? 1 : 0);
            int y2 = player.Destination.Y / 32 + /*1 +*/ (player.Destination.Y % 32 > 0 ? 1 : 0);

            Texture2D whiteRectangle = ContentConfiguration.Instance.EmptyTexture();
            
            for (var x = x1; x <= x2; x++)
            {
                for (var y = y1; y <= y2; y++)
                {
                    spriteBatch.Draw(whiteRectangle, Tiles[x,y].Destination, new Color(Color.Red, 0.25f));
                    ContentConfiguration.Instance.DrawRectangle(spriteBatch, Tiles[x, y].Destination, Color.DarkSalmon);
                }
            }

            ContentConfiguration.Instance.DrawRectangle(spriteBatch, player.Destination, Color.DarkSlateBlue);

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            for (int x = 0; x < TotalXTiles; x++)
            {
                for (int y = 0; y < TotalYTiles; y++)
                {
                    GameTile tile = Tiles[x, y];
                    if (tile.ValidTile)
                    {

                        spriteBatch.Draw(ContentConfiguration.Instance.LoadGlobalTexture(Texture),
                            tile.Destination, tile.Source, Color.White);
                    }
                }
            }
        }
    }
}
