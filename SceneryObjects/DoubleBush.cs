
namespace $safeprojectname$
{
    class DoubleBush : StaticScenery, ISceneryState
    {
        public DoubleBush(Scenery scenery)
            : base(scenery, ScenerySpriteFactory.Instance.CreateDoubleBush()) { }
    }
}
