
namespace $safeprojectname$
{
    class DoubleCloud : StaticScenery, ISceneryState
    {
        public DoubleCloud(Scenery scenery)
            : base(scenery, ScenerySpriteFactory.Instance.CreateDoubleCloud()) { }
    }
}
