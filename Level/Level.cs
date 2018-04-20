using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace $safeprojectname$
{
    public class Level
    {
        private List<Block>       blocks;
        private List<IEnemy>      enemies;
        private List<Item>        items;
        private List<Scenery>     sceneries;
        private List<Pipe>        pipes;
        private Flagpole          flagpole;
        private Bridge            bridge;
        private List<EndObject>   endObjects;
        private List<IWeapon>     weapons;
        private List<IHazard>     hazards;
        private List<Platform>    platforms;

        private PlayerBlockCollisionDetector playerBlockCD;
        private PlayerEnemyCollisionDetector playerEnemyCD;
        private PlayerItemCollisionDetector  playerItemCD;
        private PlayerPipeCollisionDetector  playerPipeCD;
        private PlayerProjectileCollisionDetector playerProjCD;
        private PlayerFlagpoleCollisionDetector playerFlagpoleCD;
        private PlayerBridgeCollisionDetector playerBridgeCD;

        private EnemyEnemyCollisionDetector enemyEnemyCD;
        private EnemyBlockCollisionDetector enemyBlockCD;
        private EnemyPipeCollisionDetector  enemyPipeCD;
        private EnemyWeaponCollisionDetector enemyWeaponCD;
        private EnemyBridgeCollisionDetector enemyBridgeCD;
        private WeaponBlockCollisionDetector weaponBlockCD;
        private WeaponPipeCollisionDetector weaponPipeCD;
        private ItemBlockCollisionDetector itemBlockCD;
        private ItemPipeCollisionDetector itemPipeCD;
        private PlayerHazardCollisionDetector playerHazardCD;
        private PlayerPlatformCollisionDetector playerPlatformCD;

        private PhysicsEngine physics;


        public PhysicsEngine Physics {  get { return physics; } set { physics = value; } }

        private ICamera camera;
        public ICamera Camera { set { camera = value; } }

        public Color BackgroundColor { get; set; }

        public Song BackgroundMusic { get; set; }

        public bool HasNextLevel { get { return !string.IsNullOrWhiteSpace(NextLevel); } }

        public Point StartLocation { get; set; }

        public string Name { get; set; }

        public string NextLevel { get; set; }

        public Level()
        {
            blocks = new List<Block>();
            enemies = new List<IEnemy>();
            items = new List<Item>();
            sceneries = new List<Scenery>();
            pipes = new List<Pipe>();
            endObjects = new List<EndObject>();
            weapons = new List<IWeapon>();
            hazards = new List<IHazard>();
            platforms = new List<Platform>();

            playerBlockCD = new PlayerBlockCollisionDetector();
            playerEnemyCD = new PlayerEnemyCollisionDetector();
            playerItemCD = new PlayerItemCollisionDetector();
            playerPipeCD = new PlayerPipeCollisionDetector();
            playerProjCD = new PlayerProjectileCollisionDetector();
            playerFlagpoleCD = new PlayerFlagpoleCollisionDetector();
            playerHazardCD = new PlayerHazardCollisionDetector();
            playerBridgeCD = new PlayerBridgeCollisionDetector();
            playerPlatformCD = new PlayerPlatformCollisionDetector();

            enemyEnemyCD = new EnemyEnemyCollisionDetector();
            enemyBlockCD = new EnemyBlockCollisionDetector();
            enemyPipeCD = new EnemyPipeCollisionDetector();
            enemyWeaponCD = new EnemyWeaponCollisionDetector();
            enemyBridgeCD = new EnemyBridgeCollisionDetector();
            weaponBlockCD = new WeaponBlockCollisionDetector();
            weaponPipeCD = new WeaponPipeCollisionDetector();
            itemBlockCD = new ItemBlockCollisionDetector();
            itemPipeCD = new ItemPipeCollisionDetector();

            physics = new PhysicsEngine();

            BackgroundColor = Color.CornflowerBlue;
            BackgroundMusic = MusicFactory.Instance.CreateMainMusic();

            StartLocation = Point.Zero;
            Name = string.Empty;
        }

        public Pipe AddPipe(Pipe pipe) { pipes.Add(pipe); return pipe; }
        public Block AddBlock(Block block)   { blocks.Add(block); return block; }
        public IEnemy AddEnemy(IEnemy enemy ) { enemies.Add(enemy); return enemy; }
        public Item AddItem(Item item)     { items.Add(item); return item; }     
        public Scenery AddScenery(Scenery scenery) { sceneries.Add(scenery); return scenery; }
        public Bridge AddBridge(Bridge bridge) { this.bridge = bridge; return bridge; }
        public Flagpole AddFlagpole(Flagpole flagpole) {this.flagpole = flagpole; return flagpole; }
        public EndObject AddEndObject(EndObject endObject) { endObjects.Add(endObject); return endObject; }
        public IHazard AddHazard(IHazard hazard) { hazards.Add(hazard); return hazard; }
        public Platform AddPlatform(Platform platform) { platforms.Add(platform); return platform; }

        public void Update(GameTime gameTime, IPlayer player)
        {
            weapons = player.Weapons;

            foreach (Platform platform in platforms) platform.Update(gameTime);

            foreach (Platform platform in platforms)
            {
                playerPlatformCD.DetectPlatformPrepass(player, platform);
            }

            if (!player.Frozen) physics.Update(gameTime, player);

            foreach (Platform platform in platforms)
            {
                playerPlatformCD.Update(player, platform);
            }

            foreach (Scenery scenery in sceneries) {
               scenery.Update(gameTime);
            }

            foreach (IEnemy enemy in enemies) {
                
                if (enemy.CollisionRectangle.X < camera.CollisionRectangle.Right + 0x50 &&
                    enemy.CollisionRectangle.Y < camera.CollisionRectangle.Bottom + 0x50 &&
                    enemy.CollisionRectangle.Y > camera.CollisionRectangle.Top - 0x50)
                {
                    if (enemy.State.Gravity) physics.Update(gameTime, enemy);
                    else enemy.Position += (float)gameTime.ElapsedGameTime.TotalSeconds * enemy.Velocity;
                    playerEnemyCD.Update(player, enemy); 
                    foreach (Block block in blocks) enemyBlockCD.Update(enemy, block, player);
                    foreach (Pipe pipe in pipes) enemyPipeCD.Update(enemy, pipe);
                    foreach (IWeapon weapon in weapons) enemyWeaponCD.Update(enemy, weapon, player);
                    if (bridge != null) enemyBridgeCD.Update(enemy, bridge);
                    if (enemy is Bowser)
                    {
                        if (enemy.Position.X > bridge.Position.X || player.Position.X > enemy.Position.X) enemy.FollowPlayer(player);
                        else if (enemy.Velocity.X != 0) enemy.Stop();
                    }
                    enemy.Update(gameTime);
                }
                else if (enemy is Bowser && enemy.CollisionRectangle.X < camera.CollisionRectangle.Right + 0x300)
                {
                    physics.Update(gameTime, enemy);
                    foreach (Block block in blocks) enemyBlockCD.Update(enemy, block, player);
                    if (bridge != null) enemyBridgeCD.Update(enemy, bridge);
                    enemy.Update(gameTime);
                }
                foreach (IProjectile proj in enemy.Projectiles)
                {
                    if (proj.Location.X < camera.CollisionRectangle.Left - 0x10) proj.Delete();
                    proj.Update(gameTime);
                    playerProjCD.Update(player, proj);
                }   
            }  

            for (int i = 0; i < enemies.Count; i++)
            {
                for (int j = i + 1; j < enemies.Count; j++)
                {
                    enemyEnemyCD.Update(enemies[i], enemies[j], player);
                }
            }

            foreach (Item item in items)
            {
                if (item.Gravity) physics.Update(gameTime, item);
                item.Update(gameTime);
                if (item.IsVisible()) playerItemCD.Update(player, item);
                foreach (Block block in blocks)
                {
                    itemBlockCD.Update(item, block);
                }
                foreach(Pipe pipe in pipes)
                {
                    itemPipeCD.Update(item, pipe);
                }
            }

            foreach (Block block in blocks){
                block.Update(gameTime);
                playerBlockCD.Update(player, block);
            }
            playerBlockCD.HandleCollision(player);

            foreach (IHazard hazard in hazards)
            {
                hazard.Update(gameTime);
                playerHazardCD.Update(player, hazard);
            }

            foreach (IWeapon weapon in weapons)
            {
                foreach (Block block in blocks)
                {
                    weaponBlockCD.Update(weapon, block);
                }
                weaponBlockCD.HandleCollision(weapon);
            }

            foreach (Pipe pipe in pipes) {
                pipe.Update(gameTime);
                playerPipeCD.Update(player, pipe);
                foreach (IWeapon weapon in weapons)
                    weaponPipeCD.Update(weapon, pipe);
            }

            if (flagpole != null)
            {
                flagpole.Update(gameTime);
                if (flagpole.FullMast) playerFlagpoleCD.Update(player, flagpole);
            }

            if (bridge != null)
            {
                bridge.Update(gameTime);
                playerBridgeCD.Update(player, bridge);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            batch.GraphicsDevice.Clear(BackgroundColor);
            foreach (Scenery scenery in sceneries) scenery.Draw(gameTime, batch);
            foreach (EndObject endObject in endObjects) { endObject.Draw(gameTime, batch); }
            foreach (Item item in items) item.Draw(gameTime, batch);
            foreach (Block block in blocks) block.Draw(gameTime, batch);
            foreach (Platform platform in platforms) platform.Draw(gameTime, batch);
            foreach (IEnemy enemy in enemies)
            {
                if (enemy.CollisionRectangle.X < camera.CollisionRectangle.Right + 0x50 &&
                    enemy.CollisionRectangle.Y < camera.CollisionRectangle.Bottom + 0x50 &&
                    enemy.CollisionRectangle.Y > camera.CollisionRectangle.Top - 0x50)
                {
                    enemy.Draw(gameTime, batch);
                }
                foreach (IProjectile proj in enemy.Projectiles)
                {
                    proj.Draw(gameTime, batch);
                }
            }
            foreach (Pipe pipe in pipes) pipe.Draw(gameTime, batch);
            if (flagpole != null) flagpole.Draw(gameTime, batch);
            if (bridge != null) bridge.Draw(gameTime, batch);
            foreach (IHazard hazard in hazards) hazard.Draw(gameTime, batch);
        }
    }
}