using LunarIllusions.Controllers;
using LunarIllusions.Controllers.Objects;
using LunarIllusions.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarIllusions.HardCode
{
    class HardCoded
    {
        public static PlayerObject GeneratePlayerObject()
        {
            PlayerObject pobject = new PlayerObject();
            pobject.Height = 32;
            pobject.Width = 32;
            pobject.Name = "BoxMan";
            pobject.Speed = 5;
            pobject.Source = new Rectangle(0, 0, 32, 32);
            pobject.AnimationHandler = new AnimationController();
            pobject.SetScreenLocation(300, 300);
            pobject.AnimationHandler.AddAnimation("Default", new Animation()
            {
                ActionName = "Default",
                IsLooping = true,
                AnimationFrames = 4,
                AnimationTimer = 200f,
                TextureName = "Player/player",
                StartSource = new Rectangle(0,0,32,32)

            });
            pobject.AnimationHandler.AddAnimation("Walking", new Animation()
            {
                ActionName = "Walking",
                IsLooping = true,
                AnimationFrames = 4,
                AnimationTimer = 175f,
                TextureName = "Player/player",
                StartSource = new Rectangle(0, 32, 32, 32)

            });
         

            return pobject;

        }
    }
}
