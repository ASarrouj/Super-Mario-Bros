using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace $safeprojectname$
{
    public class Block : IGameObject, ICollidable
    {
        public bool bumped;

        public IBlockState State { get; set;}

        public Point Position { get; set; }

        protected Block(Point position)
        {
            bumped = false;
            Position = position;
        }

        public void BeHit(IPlayer player)
        {
            State.BeHit(player);
        }

        public void BeBumped(IPlayer player)
        {
            State.BeBumped(player);
        }

        public static Block CreateBrickBlock(Point position, Queue<Item> items)
        {
            Block block = new Block(position);
            block.State = new BrickBlockState(block, items);
            return block;
        }

        public static Block CreateCrackedBlock(Point position)
        {
            Block block = new Block(position);
            block.State = new CrackedBlockState(block);
            return block;
        }

        public static Block CreateStoneBlock(Point position)
        {
            Block block = new Block(position);
            block.State = new StoneBlockState(block);
            return block;
        }

        public static Block CreateHiddenBlock(Point position, Queue<Item> items)
        {
            Block block = new Block(position);
            block.State = new HiddenBlockState(block, items);
            return block;
        }

        public static Block CreateUndergroundBrickBlock(Point position, Queue<Item> items)
        {
            Block block = new Block(position);
            block.State = new UndergroundBrickBlockState(block, items);
            return block;
        }

        public static Block CreateUndergroundCrackedBlock(Point position)
        {
            Block block = new Block(position);
            block.State = new UndergroundCrackedBlockState(block);
            return block;
        }

        public static Block CreateUndergroundStoneBlock(Point position)
        {
            Block block = new Block(position);
            block.State = new StoneBlockState(block);
            return block;
        }

        public static Block CreateUndergroundHiddenBlock(Point position, Queue<Item> items)
        {
            Block block = new Block(position);
            block.State = new HiddenBlockState(block, items);
            return block;
        }

        public static Block CreateCastleBrickBlock(Point position)
        {
            Block block = new Block(position);
            block.State = new CastleBrickBlockState(block);
            return block;
        }

        public static Block CreateItemBlock(Point position, Queue<Item> items)
        {
            Block block = new Block(position);
            block.State = new ItemBlockState(block, items);
            return block;
        }

        public static Block CreateUsedBlock(Point position)
        {
            Block block = new Block(position);
            block.State = new UsedBlockState(block);
            return block;
        }

        public static Block CreateLeftVerticalPipeBlock(Point position)
        {
            Block block = new Block(position);
            block.State = new LeftVerticalPipeBlockState(block);
            return block;
        }

        public static Block CreateRightVerticalPipeBlock(Point position)
        {
            Block block = new Block(position);
            block.State = new RightVerticalPipeBlockState(block);
            return block;
        }

        public static Block CreateTopHorizontalPipeBlock(Point position)
        {
            Block block = new Block(position);
            block.State = new TopHorizontalPipeBlockState(block);
            return block;
        }

        public static Block CreateBottomHorizontalPipeBlock(Point position)
        {
            Block block = new Block(position);
            block.State = new BottomHorizontalPipeBlockState(block);
            return block;
        }


        public Rectangle CollisionRectangle { get { return this.State.CollisionRectangle; } }

        public void Update(GameTime gameTime)
        {
            State.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            State.Draw(gameTime, spriteBatch);
        }
    }
}
