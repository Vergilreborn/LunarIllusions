using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarIllusions.GameObjects
{
    class Projectile
    {
        public Rectangle Destination { get; private set;}
        public Rectangle Source { get; private set; }
        public int AnimationCounter{get; private set;}
        public int MaxAnimationCounter{get; private set; }

        public Projectile(Rectangle startRectangle, Rectangle sourceRectangle, int MaxAnimationCounter )
        {
            this.Destination = startRectangle;
            this.Source = sourceRectangle;
            this.MaxAnimationCounter = MaxAnimationCounter;
            this.AnimationCounter = 0;
        }

        public void Update()
        {
            
        }
    }
}
