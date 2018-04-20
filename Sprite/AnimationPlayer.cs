using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class AnimationPlayer
    {
        protected int frameIndex;

        protected float frameProgress;

        protected Animation animation;

        public bool Playing { get; private set; }

        public int FrameIndex
        {
            get { return frameIndex; }
            set
            {
                frameIndex = value % animation.Frames.Count;
                frameProgress = 0.0f;
            }
        }

        public Animation Animation
        {
            get { return animation; }
            set {
                if (value != animation)
                {
                    animation = value;
                    frameIndex = 0;
                    frameProgress = 0.0f;
                    Playing = false;
                }
            }
        }

        public void Play()
        {
            Playing = true;
        }

        public void Stop()
        {
            Playing = false;
        }

        public AnimationPlayer()
        {
            Playing = false;
            animation = null;
            frameIndex = 0;
        }

        public Animation.Frame GetFrame()
        {
            return this.animation.Frames[frameIndex];
        }

        protected float GetFrameTimeRemaining()
        {
            return GetFrame().duration * (1.0f - frameProgress);
        }

        public void Update(GameTime gameTime)
        {
            if (!Playing)
                return;

            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            while(elapsedTime > GetFrameTimeRemaining())
            {
                elapsedTime -= GetFrameTimeRemaining();
                FrameIndex++;
            }

            frameProgress += elapsedTime / GetFrame().duration;
        }        
    }
}
