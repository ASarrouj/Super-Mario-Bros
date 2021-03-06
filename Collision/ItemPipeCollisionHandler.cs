﻿using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class ItemPipeCollisionHandler
    {
        public ItemPipeCollisionHandler()
        {
            
        }

        public void HandleCollision(Item item, Pipe pipe, ICollision collision)
        {
                if (collision is LeftCollision)
                {
                    item.Location = new Point(item.Location.X + collision.GetIntersectDistance(), item.Location.Y);
                    item.ChangeDirection();
                }
                else if (collision is RightCollision)
                {
                    item.Location = new Point(item.Location.X - collision.GetIntersectDistance(), item.Location.Y);
                    item.ChangeDirection();
                }
                else if (collision is TopCollision)
                {
                }
                else if (collision is BottomCollision)
                {
                    item.Location = new Point(item.Location.X, item.Location.Y - collision.GetIntersectDistance());
                    item.Velocity = new Vector2(item.Velocity.X, 0.0f);
                }
        }
    }
}