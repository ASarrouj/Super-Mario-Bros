using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace $safeprojectname$
{
    class Animation
    {
        public struct Frame
        {
            public Rectangle    source;
            public float        duration;
            public SpriteEffects effects;
            public Point offset;

            public Frame(Rectangle source, float duration, SpriteEffects effects = SpriteEffects.None)
                : this(source, duration, Point.Zero, effects) { }

            public Frame(Rectangle source, float duration, Point offset, SpriteEffects effects = SpriteEffects.None)
            {
                this.source = source;
                this.duration = duration;
                this.offset = offset;
                this.effects = effects;
            }
        }

        public List<Frame> Frames { get; private set; }

        public Animation()
        {
            Frames = new List<Frame>();
        }

        public void AddFrame(Frame frame)
        {
            Frames.Add(frame);
        }
    }
}
