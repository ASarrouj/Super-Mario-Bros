using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace $safeprojectname$
{
    class MusicFactory
    {
        private Song main;
        private Song underground;
        private Song castle;
        private Song star;
        private Song hurry;
        private Song gameOver;

        private static MusicFactory instance = new MusicFactory();

        public static MusicFactory Instance {  get { return instance; } }

        public void LoadAllMusic(ContentManager content)
        {
            main = content.Load<Song>("music_main");
            underground = content.Load<Song>("music_underground");
            castle = content.Load<Song>("music_castle");
            star = content.Load<Song>("music_star");
            hurry = content.Load<Song>("music_hurry");
            gameOver = content.Load<Song>("music_game_over");
        }

        public Song CreateMainMusic() { return main; }
        public Song CreateUndergroundMusic() { return underground; }
        public Song CreateCastleMusic() { return castle; }
        public Song CreateStarMusic() { return star; }
        public Song CreateHurryMusic() { return hurry; }
        public Song CreateGameOverMusic() { return gameOver; }
    }
}
