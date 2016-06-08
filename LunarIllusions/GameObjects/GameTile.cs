using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.Serialization;
using LunarIllusions.Enumerators;

namespace LunarIllusions.GameObjects
{
    [Serializable]
    class GameTile : GameObject
    {

        [DataMember()]
        public Vector2 position;
        [DataMember()]
        public TileType type;
        [DataMember()]
        public bool ValidTile;

        public GameTile()
        {

        }

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
