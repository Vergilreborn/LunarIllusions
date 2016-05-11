using LunarIllusions.Configurations;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LunarIllusions.Managers
{
    class FrameRateManager
    {

        private bool SetFixedFPS;
        private int FrameRate;

        private float MillisecondsPassed;
        private float FrameRateTime;

        private bool update = true;

        public FrameRateManager()
        {
            this.SetFixedFPS = Configuration.SetFixedFPS;
            this.FrameRate = Configuration.FixedFPS;

            this.FrameRateTime = 1000 / this.FrameRate;
        }

        public void Update(GameTime gameTime)
        {
            MillisecondsPassed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            update = MillisecondsPassed > this.FrameRateTime;
            if (update)
                MillisecondsPassed %= this.FrameRateTime;


        
        }

        public bool AllowUpdate()
        {
            return (update && SetFixedFPS) || !SetFixedFPS;
        }

    }
}
