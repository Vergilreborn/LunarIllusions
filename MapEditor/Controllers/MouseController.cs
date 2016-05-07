using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace LunarIllusions.Controllers
{
    class MouseController
    {
        #region fields
        private MouseState Current;
        private MouseState Previous;

        private MouseAction leftMouseAction;
        private MouseAction rightMouseAction;

        private Vector2 position;
        private Vector2 currentOffset;

        private float leftMouseCounter = 0f;
        private float rightMouseCounter = 0f;


        #endregion

        #region Properties
        //Property gets the current position (cannot update the mouse position)
        public Vector2 Position
        {
            get
            {
                return position + currentOffset;
            }
        }

        public MouseAction LeftMouseAction
        {
            get
            {
                return leftMouseAction;
            }
        }

        public MouseAction RightMouseAction
        {
            get
            {
                return rightMouseAction;
            }
        }
        #endregion

        public MouseController()
        {
            this.Current = Mouse.GetState();
            this.Previous = this.Current;
            this.currentOffset = Vector2.Zero;
        }

        public void Update(GameTime gameTime)
        {
            //this.PreviousPrevious = this.Previous;
            this.Previous = this.Current;
            this.Current = Mouse.GetState();

            this.position = this.Current.Position.ToVector2();

            bool leftMouseDown = this.Current.LeftButton == ButtonState.Pressed;
            bool leftMouseClick = this.leftMouseCounter < Configuration.ClickTimer
                               && this.Previous.LeftButton == ButtonState.Pressed
                               && this.Current.LeftButton == ButtonState.Released;


            bool rightMouseDown = this.Current.RightButton == ButtonState.Pressed;
            bool rightMouseClick = this.rightMouseCounter < Configuration.ClickTimer
                                && this.Previous.RightButton == ButtonState.Pressed
                                && this.Current.RightButton == ButtonState.Released;


            if (leftMouseClick)
            {
                this.leftMouseAction = MouseAction.MouseClick;
            }
            else if (leftMouseDown)
            {
                this.leftMouseAction = MouseAction.MouseDown;
                this.leftMouseCounter += gameTime.ElapsedGameTime.Milliseconds;
            }
            else
            {
                this.leftMouseAction = MouseAction.MouseUp;
                this.leftMouseCounter = 0;
            }


            if (rightMouseClick)
            {
                this.rightMouseAction = MouseAction.MouseClick;
            }
            else if (rightMouseDown)
            {
                this.rightMouseAction = MouseAction.MouseDown;
                this.rightMouseCounter += gameTime.ElapsedGameTime.Milliseconds;
            }
            else
            {
                this.rightMouseAction = MouseAction.MouseUp;
                this.rightMouseCounter = 0;
            }
        }

        internal void UpdateOffset(Vector2 moveOffset)
        {
            currentOffset += moveOffset;
        }
    }
}
