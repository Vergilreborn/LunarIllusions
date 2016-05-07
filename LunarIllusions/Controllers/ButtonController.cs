using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LunarIllusions.Configurations;

namespace LunarIllusions.Controllers
{
    class ButtonController
    {


        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }

        public Rectangle BoundingBox { get; }
        public bool CenterText;
        public string Text { get; }

        public string MapAction { get; }
        private bool isOver;
        private bool mouseDown;
        


        public ButtonController(String Text,int X, int Y, int Width, int Height, String MapAction)
        {
            this.Text = Text;
            this.MapAction= MapAction;
            this.CenterText = true;
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.BoundingBox = new Rectangle(X, Y, Width, Height);
            this.isOver = false;
            this.mouseDown = false;

        }

        public void Update()
        {
            //MouseController currentMouse = MapManager.Instance.MouseObject;
            //this.isOver = BoundingBox.Contains(currentMouse.Position);
            //this.mouseDown = this.isOver && MouseAction.MouseDown == currentMouse.LeftMouseAction; ;
            //bool clickInside = this.isOver && MouseAction.MouseClick == currentMouse.LeftMouseAction;
            

            //if (clickInside)
            //{
            //    MapManager.Instance.CallFunction(MapAction);
                
            //}

            
        }



        public void Draw(SpriteBatch spriteBatch, SpriteFont spriteFont)
        {

            Texture2D topLeft = ContentConfiguration.Instance.LoadGlobalTexture("Button/TopLeft");
            Texture2D topRight = ContentConfiguration.Instance.LoadGlobalTexture("Button/TopRight");
            Texture2D bottomLeft = ContentConfiguration.Instance.LoadGlobalTexture("Button/BottomLeft");
            Texture2D bottomRight = ContentConfiguration.Instance.LoadGlobalTexture("Button/BottomRight");
            Texture2D left = ContentConfiguration.Instance.LoadGlobalTexture("Button/Left");
            Texture2D right = ContentConfiguration.Instance.LoadGlobalTexture("Button/Right");
            Texture2D top = ContentConfiguration.Instance.LoadGlobalTexture("Button/Top");
            Texture2D bottom = ContentConfiguration.Instance.LoadGlobalTexture("Button/Bottom");
            Texture2D color = ContentConfiguration.Instance.EmptyTexture();

            Vector2 topLeftPosition = new Vector2(X, Y);
            Vector2 topRightPosition = new Vector2(X + Width - topRight.Width, Y);
            Vector2 bottomLeftPosition = new Vector2(X, Y + Height - bottomLeft.Height);
            Vector2 bottomRightPosition = new Vector2(X + Width - bottomRight.Width, Y + Height - bottomRight.Height);

            Rectangle LeftPosition = new Rectangle(X, Y + topLeft.Height, left.Width, Height - topLeft.Height - bottomLeft.Height);
            Rectangle RightPosition = new Rectangle(X + Width - right.Width, Y + topRight.Height, left.Width, Height - topRight.Height - bottomRight.Height);
            Rectangle TopPosition = new Rectangle(X + topLeft.Width , Y, Width - topLeft.Width - topRight.Width, top.Height);
            Rectangle BottomPosition = new Rectangle(X + bottomLeft.Width, Y + Height - bottom.Height, Width - bottomLeft.Width - bottomRight.Width, bottom.Height);

            Rectangle ColorBox = new Rectangle(X+ topLeft.Width, Y + topLeft.Height, Width - bottomLeft.Width - bottomRight.Width, Height - topRight.Height - bottomRight.Height);

            //Draw Button
            spriteBatch.Draw(topLeft, topLeftPosition, Color.White);
            spriteBatch.Draw(topRight, topRightPosition, Color.White);
            spriteBatch.Draw(bottomLeft, bottomLeftPosition, Color.White);
            spriteBatch.Draw(bottomRight, bottomRightPosition, Color.White);
            spriteBatch.Draw(left, LeftPosition, Color.White);
            spriteBatch.Draw(right, RightPosition, Color.White);
            spriteBatch.Draw(top, TopPosition, Color.White);
            spriteBatch.Draw(bottom, BottomPosition, Color.White);
            spriteBatch.Draw(color, ColorBox, Color.Black);

            Vector2 textPosition = Vector2.Zero;
            Vector2 widthHeight = spriteFont.MeasureString(Text);
            float yTextPos = (Y + (Height / 2)) - (widthHeight.Y / 2);
            float xTextPos = (X + (Width / 2)) - (widthHeight.X / 2);

            if (CenterText)
            {
                textPosition = new Vector2((int)xTextPos, (int)yTextPos);
            }
            else
            {
                textPosition = new Vector2(X + RightPosition.Width + 10, yTextPos);
            }


            Color drawColor = this.mouseDown ? Color.Red : 
                              this.isOver ?    Color.Yellow :
                                               Color.White;

            spriteBatch.DrawString(spriteFont, Text, textPosition, drawColor);


        }
    }
}