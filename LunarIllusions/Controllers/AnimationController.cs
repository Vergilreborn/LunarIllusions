using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunarIllusions.Controllers.Objects;
using System.Runtime.Serialization;

namespace LunarIllusions.Controllers
{
    [Serializable]

    class AnimationController
    {
        [DataMember()]
        Dictionary<String, Animation> Name_Animation;
        [NonSerialized()]
        public Animation CurrentAnimation;

        public AnimationController()
        {
            Name_Animation = new Dictionary<string, Animation>();
        }

        public void AddAnimation(string animationName, Animation animation)
        {
            Name_Animation.Add(animationName, animation);
        }

        public void SetAnimation(string animationName)
        {
            if (CurrentAnimation == null || CurrentAnimation.ActionName != animationName)
            {
                CurrentAnimation = Name_Animation[animationName];
                CurrentAnimation.CurrentFrame = 0;
                
            }

        }

        public Animation GetAnimation(String animationName)
        {
            return Name_Animation[animationName];
        }

        public void SetDefaultAnimation()
        {
            if (CurrentAnimation == null || CurrentAnimation.ActionName != "Default")
            {
                CurrentAnimation = Name_Animation["Default"];
                CurrentAnimation.CurrentFrame = 0;
                
            }
        }
    }
}
