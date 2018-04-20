using Microsoft.Xna.Framework;
namespace $safeprojectname$
{
    public class PlayerFlagpoleCollisionHandler
    {
        int diff, points;
        string flagpoleReward;
        public PlayerFlagpoleCollisionHandler()
        {

        }

        public void HandleCollision(IPlayer player, Flagpole flagpole, ICollision collision)
        {
            if (player.Location.Y < (flagpole.Position.Y - 8))
            {
                player.Lives = player.Lives + 1;
                player.Points += 100;
                SoundFactory.Instance.Create1UpSound().Play();
                flagpoleReward = "1-UP";
            }
            else
            {
                if ((diff = player.CollisionRectangle.Bottom - flagpole.CollisionRectangle.Top) <= 0x10)
                {
                    points = ConstantValues.POINTS_FLAG;
                }
                else
                {
                    double flagPortion = 10 * (diff / (double)flagpole.CollisionRectangle.Height);
                    points = (int)flagPortion * 100;
                }
                player.Points += points;
                flagpoleReward = points.ToString();
            }

            player.Location = new Point(flagpole.Position.X - 10, player.Location.Y);
            player.TouchFlagpole();

            flagpole.DisplayReward(flagpoleReward, player.Location.Y);
            flagpole.LowerFlag();
        }
    }
}