
namespace $safeprojectname$
{
    class TripleCloud : StaticScenery, ISceneryState
    {
        public TripleCloud(Scenery scenery)
            : base(scenery, ScenerySpriteFactory.Instance.CreateTripleCloud()) { }
    }
}
