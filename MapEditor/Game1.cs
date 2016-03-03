﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MapEditor.Controllers;
using MapEditor.Sprites;

namespace MapEditor
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        MapManager mapManager;
        ScreenController Screen;
        SpriteSheetManager SpriteSheetManager;
       // ButtonController btn;
        SpriteFont spriteFont;
      //  TileSelectorController tileSelector;

        /////TESTING BUTTONS END
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.IsMouseVisible = true;
            
            mapManager = new MapManager();
            SpriteSheetManager = new SpriteSheetManager();
        //    tileSelector = new TileSelectorController();


        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            GameServices.Instance.AddService(GraphicsDevice);
            GameServices.Instance.AddService(Content);
            //mapManager.Initialize(graphics);
           // btn = new ButtonController("File", 20, 20, 200, 50, "LoremIpsum");
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            mapManager.LoadContent(spriteBatch);
            Screen = new ScreenController(graphics.GraphicsDevice.Viewport, Vector2.Zero);

            SpriteSheetManager.LoadContent(Content);

            spriteFont = Content.Load<SpriteFont>("LunchdoubleSo");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            mapManager.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
          //  if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
          //      this.Exit();// Exit();

            // TODO: Add your update logic here
            Screen.Update(gameTime);
            mapManager.Update(gameTime);
            if(mapManager.KeyboardObject.KeyDown("Tab")) //TO DO REMOVE
                SpriteSheetManager.Update(Screen.PositionOffset);
           // btn.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            //spriteBatch.Begin();
            
            Screen.Draw(spriteBatch);
            mapManager.Draw(spriteBatch,gameTime);
           // btn.Draw(spriteBatch, spriteFont);
            if (mapManager.KeyboardObject.KeyDown("Tab")) //TO DO REMOVE
                 SpriteSheetManager.Draw(spriteBatch,Screen.PositionOffset);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
