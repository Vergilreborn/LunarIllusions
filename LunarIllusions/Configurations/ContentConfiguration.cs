using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using LunarIllusions.Services;

namespace LunarIllusions.Configurations
{
    class ContentConfiguration
    {

        private static ContentConfiguration instance;

        #region Get Declarations
        public static ContentConfiguration Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ContentConfiguration();
                }
                return instance;
            }
        }
        #endregion

        private Dictionary<String, Texture2D> loadedTextures;

        public ContentConfiguration()
        {
            loadedTextures = new Dictionary<string, Texture2D>();
        }

        public Texture2D EmptyTexture()
        {
            bool textureNeeded = !loadedTextures.ContainsKey(Configuration.EmptyTextureName);
            if (textureNeeded)
            {
                Texture2D texture = new Texture2D(GameServices.Instance.GetService<GraphicsDevice>(), 1, 1);
                texture.SetData(new[] { Color.White });
                loadedTextures.Add(Configuration.EmptyTextureName, texture);
            }

            return loadedTextures[Configuration.EmptyTextureName];
        }

        public Texture2D LoadGlobalTexture(String TextureName)
        {

            bool textureNeeded = !loadedTextures.ContainsKey(TextureName);
            if (textureNeeded)
            {
                ContentManager contentManager = GameServices.GetService<ContentManager>();
                Texture2D texture = contentManager.Load<Texture2D>(TextureName);
                loadedTextures.Add(TextureName, texture);
            }

            return loadedTextures[TextureName];
        }

        public void SaveGlobalTexture(Texture2D Texture, String TextureName)
        {
            bool textureNeeded = !loadedTextures.ContainsKey(TextureName);
            if (textureNeeded)
            {
                Texture2D texture = Texture;
                loadedTextures.Add(TextureName, texture);
            }
        }

        public void DeleteTexture(String TextureName)
        {
            bool textureExists = loadedTextures.ContainsKey(TextureName);
            if(textureExists)
            {
                loadedTextures.Remove(TextureName);
            }
        }

        //Resets the dictionary to get rid of textures not being used.
        //TODO: Find a way to execute this sparingly
        public void ResetTextures() 
        {
            loadedTextures.Clear();
        }

        public void DrawRectangle(SpriteBatch spriteBatch, Rectangle rectangle, Color color)
        {
            spriteBatch.Draw(EmptyTexture(), new Rectangle(rectangle.X, rectangle.Y, Configuration.LineWidth, rectangle.Height + Configuration.LineWidth), color);
            spriteBatch.Draw(EmptyTexture(), new Rectangle(rectangle.X, rectangle.Y, rectangle.Width + Configuration.LineWidth, Configuration.LineWidth), color);
            spriteBatch.Draw(EmptyTexture(), new Rectangle(rectangle.X + rectangle.Width, rectangle.Y, Configuration.LineWidth, rectangle.Height + Configuration.LineWidth), color);
            spriteBatch.Draw(EmptyTexture(), new Rectangle(rectangle.X, rectangle.Y + rectangle.Height, rectangle.Width + Configuration.LineWidth, Configuration.LineWidth), color);
        }

    }
}
