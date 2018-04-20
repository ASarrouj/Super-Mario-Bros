using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace $safeprojectname$
{
    class SoundFactory
    {
        private SoundEffect jump;
        private SoundEffect stomp;
        private SoundEffect coin;
        private SoundEffect marioPowerup;
        private SoundEffect breakblock;
        private SoundEffect powerupAppears;
        private SoundEffect bump;
        private SoundEffect fireball;
        private SoundEffect bowserFire;
        private SoundEffect oneup;
        private SoundEffect pause;
        private SoundEffect flagpole;
        private SoundEffect bridge;
        private SoundEffect castleComplete;
        private SoundEffect pipe_damage;
        private SoundEffect warning;
        private SoundEffect stageClear;
        private SoundEffect marioDie;
        private SoundEffect swordSlash;
        private SoundEffect linkPowerup;

        private static SoundFactory instance = new SoundFactory();

        public static SoundFactory Instance {  get { return instance; } }

        public void LoadAllSounds(ContentManager content)
        {
            jump = content.Load<SoundEffect>("sound_jump");
            stomp = content.Load<SoundEffect>("sound_stomp");
            coin = content.Load<SoundEffect>("sound_coin");
            marioPowerup = content.Load<SoundEffect>("sound_powerup");
            breakblock = content.Load<SoundEffect>("sound_breakblock");
            powerupAppears = content.Load<SoundEffect>("sound_powerup_appears");
            bump = content.Load<SoundEffect>("sound_bump");
            fireball = content.Load<SoundEffect>("sound_fireball");
            bowserFire = content.Load<SoundEffect>("sound_bowser_fire");
            oneup = content.Load<SoundEffect>("sound_1up");
            pause = content.Load<SoundEffect>("sound_pause");
            flagpole = content.Load<SoundEffect>("sound_flagpole");
            bridge = content.Load<SoundEffect>("sound_bridge");
            castleComplete = content.Load<SoundEffect>("sound_castle_complete");
            pipe_damage = content.Load<SoundEffect>("sound_pipe");
            warning = content.Load<SoundEffect>("sound_warning");
            stageClear = content.Load<SoundEffect>("sound_stage_clear");
            marioDie = content.Load<SoundEffect>("sound_mario_die");
            swordSlash = content.Load<SoundEffect>("sound_link_slash");
            linkPowerup = content.Load<SoundEffect>("sound_link_powerup");
        }

        public SoundEffect CreateJumpSound() { return jump; }
        public SoundEffect CreateStompSound() { return stomp; }
        public SoundEffect CreateCoinSound() { return coin; }
        public SoundEffect CreateMarioPowerupSound() { return marioPowerup; }
        public SoundEffect CreateBreakBlockSound() { return breakblock; }
        public SoundEffect CreatePowerupAppearsSound() { return powerupAppears; }
        public SoundEffect CreateBumpSound() { return bump; }
        public SoundEffect CreateFireballSound() { return fireball; }
        public SoundEffect CreateBowserFireSound() { return bowserFire; }
        public SoundEffect Create1UpSound() { return oneup; }
        public SoundEffect CreatePauseSound() { return pause; }
        public SoundEffect CreateFlagpoleSound() { return flagpole; }
        public SoundEffect CreateBridgeSound() { return bridge; }
        public SoundEffect CreateCastleCompleteSound() { return castleComplete; }
        public SoundEffect CreatePipeSound() { return pipe_damage; }
        public SoundEffect CreateWarningSound() { return warning; }
        public SoundEffect CreateStageClearSound() { return stageClear; }
        public SoundEffect CreateMarioDieSound() { return marioDie; }
        public SoundEffect CreatePlayerDamageSound() { return pipe_damage; }
        public SoundEffect CreateSwordSlashSound() { return swordSlash; }
        public SoundEffect CreateLinkPowerupSound() { return linkPowerup; }
    }
}
