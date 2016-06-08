using LunarIllusions.GameObjects;
using LunarIllusions.HardCode;
using LunarIllusions.Helper;
using LunarIllusions.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace LunarIllusions.Managers
{
    
    class MapManager
    {
    
        MapObject Map;
        PlayerObject player;
        List<EnemyObject> enemySet;
        GameCameraService cam;

        public MapManager() {
            enemySet = new List<EnemyObject>();
            Map = HardCoded.GenerateMapObject();
            player = XmlObject<PlayerObject>.Load(@"PlayerBase.xml");//HardCode.HardCoded.GeneratePlayerObject();
            //player.Destination = new Rectangle(32, 32, 32, 32); //Set when loading Map
            player.Destination = new Rectangle(Map.StartLocation.ToPoint(), new Point(player.Width, player.Height));

            EnemyObject enemy2 = XmlObject<EnemyObject>.Load(@"EnemyBase.xml");
            enemy2.SetScreenLocation(100, 300);
            enemySet.Add(enemy2);
            enemySet.Add(HardCoded.GenerateEnemyObject());
          
            
        }

        public void Initialize()
        {
            cam = GameServices.GetService<GameCameraService>();
            player.Initialize();
            cam.SetFocus(player);
        }

        public void Update(GameTime gameTime)
        {
            player.Update(gameTime, Map);
            foreach (EnemyObject enemy in enemySet)
            {
                enemy.Update(gameTime, Map);
            }

            cam.SetFocus(player);
            cam.Update(gameTime);
        }

        public void Draw(GameTime gameTime,SpriteBatch spriteBatch)
        {
            cam.Draw(spriteBatch);
            Map.Draw(gameTime, spriteBatch);
            player.Draw(gameTime, spriteBatch);
            
            foreach (EnemyObject enemy in enemySet)
                enemy.Draw(gameTime, spriteBatch);
            
                
            //Map.DrawBoundBox(player, spriteBatch);
        }

        internal void UnloadContent()
        {

        }

        internal void LoadContent()
        {

        }
    }
}
