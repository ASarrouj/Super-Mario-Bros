using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class AnimatedSprite
    {
        protected Texture2D texture;
        protected Animation.Frame frame;

        public AnimationPlayer AnimationPlayer { get; set;}

        public AnimatedSprite(Texture2D texture, Animation animation, bool playing = true)
        {
            this.texture = texture;
            AnimationPlayer = new AnimationPlayer();
            AnimationPlayer.Animation = animation;
            if (playing) { AnimationPlayer.Play(); }
        }

        public void Update(GameTime gameTime)
        {
            AnimationPlayer.Update(gameTime);
        }

        public void Draw(SpriteBatch batch, Point position)
        {
            this.Draw(batch, position, Color.White);
        }

        public void Draw(SpriteBatch batch, Point position, Color color)
        {
            frame = AnimationPlayer.GetFrame();
            batch.Draw(texture,
                new Rectangle(position + frame.offset, frame.source.Size),
                frame.source,
                color,
                0.0f,
                Vector2.Zero,
                frame.effects,
                0.0f);
        }
    }
}
