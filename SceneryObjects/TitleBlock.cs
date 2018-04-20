
namespace $safeprojectname$
{
    class TitleBlock : StaticScenery, ISceneryState
    {
        public TitleBlock(Scenery scenery)
            : base(scenery, ScenerySpriteFactory.Instance.CreateTitleBlock()) { }
    }
}
