using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.Serialization;

namespace LunarIllusions.GameObjects
{
    [Serializable]
    class MapObject : GameObject
    {

        [DataMember()]
        GameTile[][] Tiles;
        [DataMember()]
        int Width;
        [DataMember()]
        int Height;
        public override void Initialize()
        {
         
        }

        public override void Load()
        {
         
        }

        public override void Update(GameTime gameTime)
        {
    
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
         
        }
    }
}
