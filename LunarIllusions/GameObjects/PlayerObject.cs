using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LunarIllusions.Services;
using LunarIllusions.Configurations;
using System.Runtime.Serialization;
using LunarIllusions.Controllers;

namespace LunarIllusions.GameObjects
{   
    [Serializable]

    class PlayerObject : GameObject
    {

        [NonSerialized()]
        private bool horizontalFlip = false;
        
        public PlayerObject()
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

            if (InputService.Instance.Keyboard.KeyDown("Left"))
            {
                
                Destination.X -= (int)Speed;
                AnimationHandler.SetAnimation("Walking");
                horizontalFlip = true;
            }
            else if (InputService.Instance.Keyboard.KeyDown("Right"))
            {
                
                Destination.X += (int)Speed;
                AnimationHandler.SetAnimation("Walking");
                horizontalFlip = false;
            }
            else
            {
                AnimationHandler.SetDefaultAnimation();
                Source.X = 0;
            }

            AnimationHandler.CurrentAnimation.Update(gameTime, horizontalFlip);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            AnimationHandler.CurrentAnimation.Draw(gameTime, spriteBatch, this);
                
        }
    }
}
