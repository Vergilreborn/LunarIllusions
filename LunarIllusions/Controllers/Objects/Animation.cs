using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LunarIllusions.GameObjects;
using LunarIllusions.Configurations;
using System.Runtime.Serialization;

namespace LunarIllusions.Controllers.Objects
{
    [Serializable]

    class Animation
    {
        [DataMember()]
        public bool IsLooping;
        [DataMember()]
        public float AnimationTimer;
        [DataMember()]
        public int AnimationFrames;
        [DataMember()]
        public string TextureName;
        [DataMember()]
        public string ActionName;
        [DataMember()]
        public Rectangle StartSource;

        [NonSerialized()]
        public bool IsHorFlip;
        [NonSerialized()]
        public int CurrentFrame;
        [NonSerialized()]
        public float CurrentTimeElapsed;
        [NonSerialized()]
        public bool AnimationComplete;
        [NonSerialized()]
        public Rectangle CurrentSource;


        public Animation()
        {
            this.AnimationComplete = true;
            this.IsLooping = false;
            this.IsHorFlip = false;
            this.AnimationTimer = 0f;
            this.CurrentFrame = 0;
            this.AnimationFrames = 0;
            this.TextureName = "";
            this.CurrentTimeElapsed = 0f;
        }

        public void Update(GameTime gameTime, bool IsHorFlip)
        {
            this.IsHorFlip = IsHorFlip;
            if (!AnimationComplete || IsLooping)
            {
                CurrentTimeElapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if(AnimationTimer < CurrentTimeElapsed)
                {
                    CurrentTimeElapsed = 0f;
                    CurrentFrame++;
                    AnimationComplete = CurrentFrame == AnimationFrames;
                    CurrentFrame = CurrentFrame % AnimationFrames;                  
                }
            }
        }
        
        public void Draw(GameTime gameTime ,SpriteBatch spriteBatch, GameObject gameObject)
        {
            CurrentSource = StartSource;
            CurrentSource.X += (gameObject.Width * CurrentFrame);
            spriteBatch.Draw(ContentConfiguration.Instance.LoadGlobalTexture(TextureName),
                            gameObject.Destination, CurrentSource, Color.White, 0f, gameObject.Origin,
                            IsHorFlip ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 1f);
        }
    }
}
