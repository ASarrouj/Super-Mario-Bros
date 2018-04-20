
namespace $safeprojectname$
{
    class SingleBush : StaticScenery, ISceneryState
    {
        public SingleBush(Scenery scenery)
            : base(scenery, ScenerySpriteFactory.Instance.CreateSingleBush()) { }
    }
}
