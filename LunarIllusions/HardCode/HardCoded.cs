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
            pobject.MaxSpeed = 15;
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

        public static WeaponObject GenerateWeaponObject()
        {
            WeaponObject weapon = new WeaponObject();
            weapon.AnimationHandler = new AnimationController();
            weapon.MaxSpeed = 16;
            weapon.Speed = 16;
            weapon.StaticSpeed = true;
            weapon.Name = "Default";
            weapon.IsProjectile = true;
            weapon.AnimationHandler.AddAnimation("Bullet", new Animation()
            {
                ActionName = "Default",
                IsLooping = true,
                AnimationFrames = 4,
                AnimationTimer = 200f,
                TextureName = "Bullet/Default",
                StartSource = new Rectangle(0, 0, 16, 16)

            });

            return weapon;
        }

        public static EnemyObject GenerateEnemyObject()
        {
            EnemyObject eobject = new EnemyObject();
            eobject.Height = 32;
            eobject.Width = 32;
            eobject.Name = "EnemyMan";
            eobject.Speed = 5;
            eobject.MaxSpeed = 15;
            eobject.Source = new Rectangle(0, 0, 32, 32);
            eobject.AnimationHandler = new AnimationController();
            eobject.Destination = new Rectangle(400, 300, 32, 32);
            eobject.SetScreenLocation(400, 300);
            eobject.GravitySet = true;
            eobject.AnimationHandler.AddAnimation("Default", new Animation()
            {
                ActionName = "Default",
                IsLooping = true,
                AnimationFrames = 4,
                AnimationTimer = 200f,
                TextureName = "Enemy/enemy",
                StartSource = new Rectangle(0, 0, 32, 32)

            });
            eobject.AnimationHandler.AddAnimation("Walking", new Animation()
            {
                ActionName = "Walking",
                IsLooping = true,
                AnimationFrames = 4,
                AnimationTimer = 175f,
                TextureName = "Enemy/enemy",
                StartSource = new Rectangle(0, 32, 32, 32)

            });


            return eobject;
        }


        public static MapObject GenerateMapObject()
        {
            MapObject map = new MapObject();

            map.Height = 1024;
            map.Width = 1024;
            map.SetScreenLocation(0, 0);
            map.Texture = "Map/Tiles";
            map.TotalXTiles = 32;
            map.TotalYTiles = 32;
            map.Tiles = new GameTile[32,32];
            map.StartLocation = new Vector2(200, 200);

            for (int x = 0; x < map.TotalXTiles; x++)
            {
                for (int y = 0; y < map.TotalYTiles; y++)
                {
                    map.Tiles[x, y] = new GameTile()
                    {
                        ValidTile = y == 3 || y == 12,
                        Destination = new Rectangle(32 * x, 32 * y, 32, 32),
                        Source = (y == 3 || y == 12) ? new Rectangle(0, 0, 32, 32) : new Rectangle(-1, -1, 0, 0),
                        type = (y == 3 || y == 12) ? Enumerators.TileType.B : Enumerators.TileType.E
                    };
                    
                }
            }

            map.Tiles[2, 11].Source = new Rectangle(0, 0, 32, 32);
            map.Tiles[2, 11].ValidTile = true;
            map.Tiles[2, 11].type = Enumerators.TileType.B;

            map.Tiles[3, 11].Source = new Rectangle(0, 0, 32, 32);
            map.Tiles[3, 11].ValidTile = true;
            map.Tiles[3, 11].type = Enumerators.TileType.B;

            map.Tiles[2, 11].Source = new Rectangle(0, 0, 32, 32);
            map.Tiles[2, 11].ValidTile = true;
            map.Tiles[2, 11].type = Enumerators.TileType.B;

            map.Tiles[15, 11].Source = new Rectangle(0, 0, 32, 32);
            map.Tiles[15, 11].ValidTile = true;
            map.Tiles[15, 11].type = Enumerators.TileType.B;

            map.Tiles[15, 10].Source = new Rectangle(0, 0, 32, 32);
            map.Tiles[15, 10].ValidTile = true;
            map.Tiles[15, 10].type = Enumerators.TileType.B;
            map.Tiles[15, 9].Source = new Rectangle(0, 0, 32, 32);
            map.Tiles[15, 9].ValidTile = true;
            map.Tiles[15, 9].type = Enumerators.TileType.B;

            map.Tiles[2, 6].Source = new Rectangle(0, 0, 32, 32);
            map.Tiles[2, 6].ValidTile = true;
            map.Tiles[2, 6].type = Enumerators.TileType.B;


            return map;
        }
    }
}
