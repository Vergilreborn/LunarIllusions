using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LunarIllusions.Configurations;
using LunarIllusions.Helper;

namespace LunarIllusions.GameObjects
{
    [Serializable]
    class EnemyObject : GameObject
    {
        [NonSerialized()]
        private bool horizontalFlip = false;

        [NonSerialized()]
        private MapObject currentMap;


        public EnemyObject()
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
            Rectangle previousDestination = Destination;

            //if (InputService.Instance.Keyboard.KeyDown("Left"))
            //{

            //    Destination.X -= (int)Speed;
            //    AnimationHandler.SetAnimation("Walking");
            //    horizontalFlip = true;
            //}
            //else if (InputService.Instance.Keyboard.KeyDown("Right"))
            //{

            //    Destination.X += (int)Speed;
            //    AnimationHandler.SetAnimation("Walking");
            //    horizontalFlip = false;
            //}
            //else
            //{
                AnimationHandler.SetDefaultAnimation();
                Source.X = 0;
            //}

            //if (InputService.Instance.Keyboard.KeyDown("Space") && !IsJumping)
            //{
            //    IsJumping = true;
            //    CurrentSpeed = -15;

            //}

            if (GravitySet)
            {
                if (CurrentSpeed >= MaxSpeed)
                    CurrentSpeed = MaxSpeed;
                else
                    CurrentSpeed++;

                Destination.Y += (int)CurrentSpeed;

            }

           Destination = this.UpdateCollision(Destination,previousDestination, currentMap);

            AnimationHandler.CurrentAnimation.Update(gameTime, horizontalFlip);
        }


        internal void Update(GameTime gameTime, MapObject map)
        {
            currentMap = map;
            Update(gameTime);

        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            AnimationHandler.CurrentAnimation.Draw(gameTime, spriteBatch, this);

            /**Debuging content**/
            Texture2D whiteRectangle = ContentConfiguration.Instance.EmptyTexture();
            ContentConfiguration.Instance.DrawRectangle(spriteBatch, Destination, Color.Red);
        }
    }
}
