
namespace $safeprojectname$
{
    class SmallHill : StaticScenery, ISceneryState
    {
        public SmallHill(Scenery scenery)
            : base(scenery, ScenerySpriteFactory.Instance.CreateSmallHill()) { }
    }
}
