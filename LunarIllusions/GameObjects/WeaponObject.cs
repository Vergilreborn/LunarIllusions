using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.Serialization;
using LunarIllusions.Controllers;

namespace LunarIllusions.GameObjects
{
    [Serializable]
    class WeaponObject
    {

        [DataMember()]
        public AnimationController AnimationHandler;
        [DataMember()]
        public String Name;
        [DataMember()]
        public bool IsProjectile;
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
        List<Projectile> projectiles = new List<Projectile>();

        public WeaponObject()
        {
            this.projectiles = new List<Projectile>();
        }

        internal void Update(GameTime gameTime)
        {

        }
        public void Attack(bool horizontalFlip, Rectangle destination, string weaponType)
        {
            if (projectiles == null)
                this.projectiles = new List<Projectile>();

            this.projectiles.Add(new Projectile(destination,horizontalFlip,))
            //newProjectile
        }
    }
}
