using LunarIllusions.Controllers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LunarIllusions.GameObjects
{
    [Serializable]
    abstract class GameObject
    {
        [DataMember()]
        public AnimationController AnimationHandler;
        [DataMember()]
        public Rectangle Source;
        [DataMember()]
        public String Name;
        [DataMember()]
        public int Width;
        [DataMember()]
        public int Height;
        [DataMember()]
        public float Speed = 0f;
        [DataMember()]
        public bool StaticSpeed;
        [DataMember()]
        public float MaxSpeed = 0f;
        [DataMember()]
        private float Velocity = 0f;
        [DataMember()]
        private bool Gravity = false;
        [NonSerialized()]
        public Rectangle Destination;
        [NonSerialized()]
        public float CurrentSpeed = 0f;
        [NonSerialized()]
        private Vector2 _Origin;
        [NonSerialized()]
        public bool IsJumping = false;
        [NonSerialized()]
        private Vector2 _Center;

        public bool GravitySet
        {
            get
            {
                return Gravity;
            }
             set
            {
                Gravity = value;
            }
        }

        public Vector2 Origin
        {
            get
            {
                if (_Origin == null)
                    _Origin = new Vector2(Width / 2, Height / 2);
                return _Origin;
            }
        }
        
        public Vector2 Center
        {
            get
            {
                
                    
                return new Vector2(Destination.X + Width / 2, Destination.Y + Height / 2);
            }
        }



        public abstract void Initialize();
        public abstract void Load();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public void SetScreenLocation(int x, int y)
        {
         
            Destination = new Rectangle(0, 0, Width, Height);
            Destination.X = x;
            Destination.Y = y;

        }
    }
}
