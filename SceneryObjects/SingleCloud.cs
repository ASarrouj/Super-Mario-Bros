
namespace $safeprojectname$
{
    class SingleCloud : StaticScenery, ISceneryState
    {
        public SingleCloud(Scenery scenery)
            : base(scenery, ScenerySpriteFactory.Instance.CreateSingleCloud()) { }
    }
}
