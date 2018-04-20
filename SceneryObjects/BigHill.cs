
namespace $safeprojectname$
{
    class BigHill : StaticScenery, ISceneryState
    {
        public BigHill(Scenery scenery)
            : base(scenery, ScenerySpriteFactory.Instance.CreateBigHill()) { }
    }
}
