using LunarIllusions.Controllers;
using LunarIllusions.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarIllusions.Services
{
    class GameCameraService
    {

        public Viewport View { get { return view; } }
        public Vector2 Position { get { return position; } }
        public Vector2 FocusPoint { get { return focusPoint; } }
        public Vector2 PositionOffset { get { return currentOffset; } }
        public Rectangle ScreenView
        {
            get
            {
                return new Rectangle((int)-transform.M41, (int)-transform.M42, view.Height, view.Width);
            }
        }

        private Viewport view;
        private Vector2 position;
        private Vector2 focusPoint;
        private float zoom;
        private Matrix transform;
        private Vector2 source = Vector2.Zero;
        public Vector2 currentOffset = Vector2.Zero;

        public GameCameraService(Viewport view)
        {
            this.view = view;
            this.position = Vector2.Zero;
            this.zoom = 1.0f;
            this.focusPoint = new Vector2(view.Width / 2, view.Height / 2);
            this.source = new Vector2(view.Width / 2, view.Height / 2);

        }

        public void SetFocus(GameObject objects)
        {
           this.source = objects.Center;
        }


        public void MoveCamera(Vector2 offset)
        {
            this.focusPoint += offset;
        }

        public void Update(GameTime gametime)
        {

            Vector2 objectPosition = source;

            this.transform = Matrix.CreateTranslation(new Vector3(-objectPosition, 0)) *
                Matrix.CreateTranslation(new Vector3(focusPoint.X, focusPoint.Y, 0));
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            //GameState will dictate the order and alpha state of drawings
            //moves the camera around depending on the position
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, null, this.transform);

            //spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, transform);

        }
    }
}
