using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace $safeprojectname$
{
    public abstract class MarioGameLevelLoader : ILevelLoader
    {
        protected Level level;

        protected MarioGameLevelLoader()
        {
            level = new Level();
        }

        abstract public Level LoadLevel(string levelname);

        protected Point ShiftPosition(Point point) { return point + new Point(0, 0x10); }

        protected void AddBrickBlock(Point point, string[] args)   {  level.AddBlock(Block.CreateBrickBlock(point, new Queue<Item>())); }

        protected void AddCrackedBlock(Point point, string[] args) {   level.AddBlock(Block.CreateCrackedBlock(point)); }

        protected void AddHiddenBlock(Point point, string[] args)  {   level.AddBlock(Block.CreateHiddenBlock(point, new Queue<Item>())); }

        protected void AddStoneBlock(Point point, string[] args)   {   level.AddBlock(Block.CreateStoneBlock(point)); }

        protected void AddItemBlock(Point point, string[] args)    {   level.AddBlock(Block.CreateItemBlock(point, new Queue<Item>())); }

        protected void AddUndergroundBrickBlock(Point point, string[] args) {   level.AddBlock(Block.CreateUndergroundBrickBlock(point, new Queue<Item>())); }

        protected void AddUndergroundCrackedBlock(Point point, string[] args) {   level.AddBlock(Block.CreateUndergroundCrackedBlock(point)); }

        protected void AddUndergroundHiddenBlock(Point point, string[] args) {   level.AddBlock(Block.CreateUndergroundHiddenBlock(point, new Queue<Item>())); }

        protected void AddUndergroundStoneBlock(Point point, string[] args) {   level.AddBlock(Block.CreateUndergroundStoneBlock(point)); }

        protected void AddCastleBrickBlock(Point point, string[] args) { level.AddBlock(Block.CreateCastleBrickBlock(point)); }

        protected void AddUpPipe (Point point, string[] args)      {   level.AddPipe(Pipe.CreateUpPipe(point)); }

        protected void AddLeftPipe(Point point, string[] args)     {   level.AddPipe(Pipe.CreateLeftPipe(point)); }

        protected void AddLeftVerticalPipeBlock(Point point, string[] args) { level.AddBlock(Block.CreateLeftVerticalPipeBlock(point)); }

        protected void AddRightVerticalPipeBlock(Point point, string[] args) { level.AddBlock(Block.CreateRightVerticalPipeBlock(point)); }

        protected void AddTopHorizontalPipeBlock(Point point, string[] args) { level.AddBlock(Block.CreateTopHorizontalPipeBlock(point)); }

        protected void AddBottomHorizontalPipeBlock(Point point, string[] args) { level.AddBlock(Block.CreateBottomHorizontalPipeBlock(point)); }

        protected void AddGoomba(Point point, string[] args)       {   level.AddEnemy(new Goomba(ShiftPosition(point))); }

        protected void AddGreenKoopa(Point point, string[] args)        {   level.AddEnemy(Koopa.CreateWalkingGreenKoopa(ShiftPosition(point))); }

        protected void AddRedKoopa(Point point, string[] args) {   level.AddEnemy(Koopa.CreateWalkingRedKoopa(ShiftPosition(point))); }

        protected void AddVerticalParakoopa(Point point, string[] args) {   level.AddEnemy(Koopa.CreateVerticalParakoopa(ShiftPosition(point))); }

        protected void AddHorizontalParakoopa(Point point, string[] args)  {   level.AddEnemy(Koopa.CreateHorizontalParakoopa(ShiftPosition(point))); }

        protected void AddBouncingParakoopa(Point point, string[] args) {   level.AddEnemy(Koopa.CreateBouncingParakoopa(ShiftPosition(point))); }

        protected void AddBowser(Point point, string[] args) { level.AddEnemy(new Bowser(ShiftPosition(point)));  }

        protected void AddCoin(Point point, string[] args)         {   level.AddItem(new Coin(point, false)); }

        protected void AddFireFlower(Point point, string[] args)   {   level.AddItem(new FireFlower(point, false)); }

        protected void AddRedMushroom(Point point, string[] args)  {   level.AddItem(new RedMushroom(point, false)); }

        protected void AddGreenMushroom(Point point, string[] args) {   level.AddItem(new GreenMushroom(point, false)); }

        protected void AddStar(Point point, string[] args)         {   level.AddItem(new Star(point, false)); }

        protected void AddBigHill(Point point, string[] args)      {   level.AddScenery(Scenery.CreateBigHill(point)); }

        protected void AddDoubleBush(Point point, string[] args)   {   level.AddScenery(Scenery.CreateDoubleBush(point)); }

        protected void AddDoubleCloud(Point point, string[] args) {   level.AddScenery(Scenery.CreateDoubleCloud(point)); }

        protected void AddSingleBush(Point point, string[] args) {   level.AddScenery(Scenery.CreateSingleBush(point)); }

        protected void AddSingleCloud(Point point, string[] args) {   level.AddScenery(Scenery.CreateSingleCloud(point)); }

        protected void AddSmallHill(Point point, string[] args) {   level.AddScenery(Scenery.CreateSmallHill(point)); }

        protected void AddTripleBush(Point point, string[] args) {   level.AddScenery(Scenery.CreateTripleBush(point)); }

        protected void AddTripleCloud(Point point, string[] args) {   level.AddScenery(Scenery.CreateTripleCloud(point)); }

        protected void AddBridge(Point point, string[] args) { level.AddBridge(new Bridge(point, int.Parse(args[1]))); }

        protected void AddCastle(Point point, string[] args) {   level.AddEndObject(EndObject.CreateCastle(point)); }
        protected void AddToad(Point point, string[] args) { level.AddEndObject(EndObject.CreateToad(point - new Point(0, 0x8))); }

        protected void AddFlagpole(Point point, string[] args) {
            Point polePoint = new Point(point.X + 4, point.Y + 9);
            Point blockPoint = new Point(point.X, point.Y + 160);
            level.AddFlagpole(new Flagpole(polePoint));
            level.AddBlock(Block.CreateStoneBlock(blockPoint));
        }

        protected void AddTitleBlock(Point point, string[] args)
        {
            Point newPoint = new Point(point.X + 8, point.Y);
            level.AddScenery(Scenery.CreateTitleBlock(newPoint));
        }

        protected void AddLavaTop(Point point, string[] args) { level.AddHazard(new LavaTop(point)); }

        protected void AddLava(Point point, string[] args) { level.AddHazard(new Lava(point)); }

        protected void AddSpinnyFireBlock(Point point, string[] args)
        {
            for(int b = 0; b < ConstantValues.SPINNY_FIREBALL_COUNT; b++)
            {
                level.AddHazard(new SpinnyFireball(
                    new Point(point.X + ConstantValues.FIREBALL_SIZE.X / 2, point.Y + ConstantValues.FIREBALL_SIZE.Y / 2),
                    b * ConstantValues.SPINNY_FIREBALL_SPACING, 0.0f, ConstantValues.SPINNY_ANGULAR_VELOCITY));
            }

            level.AddBlock(Block.CreateUsedBlock(point));
        }
    }
}
