
namespace $safeprojectname$
{
    class TripleBush : StaticScenery, ISceneryState
    {
        public TripleBush(Scenery scenery)
            : base(scenery, ScenerySpriteFactory.Instance.CreateTripleBush()) { }
    }
}
