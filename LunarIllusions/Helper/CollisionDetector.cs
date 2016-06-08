using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunarIllusions.GameObjects;
using Microsoft.Xna.Framework;

namespace LunarIllusions.Helper
{
    static class CollisionDetector
    {

        public static bool IsColliding(this GameObject mainPlayer, GameObject gameObject)
        {
            return mainPlayer.Destination.Intersects(gameObject.Destination);

        }

        internal static Rectangle UpdateCollision(this GameObject gameObject, Rectangle Destination, Rectangle old, MapObject currentMap)
        {
            foreach (GameTile tile in currentMap.Tiles)
            {
                if (tile.ValidTile && Destination.Intersects(tile.Destination))
                {

                    Rectangle newDestinationXOnly = new Rectangle(Destination.X, old.Y, gameObject.Width, gameObject.Height);
                    Rectangle newDestinationYOnly = new Rectangle(old.X, Destination.Y, gameObject.Width, gameObject.Height);
                    if (newDestinationXOnly.Intersects(tile.Destination))
                    {
                        Destination.X = old.X;
                    }

                    if (newDestinationYOnly.Intersects(tile.Destination))
                    {

                        Destination.Y = old.Y;

                        if (gameObject.Center.Y < tile.Destination.Y)
                        {
                            gameObject.IsJumping = false;
                            gameObject.CurrentSpeed = 0;
                        }
                    }
                }
            }

            return Destination;
        }
    }
}
