using Microsoft.Xna.Framework;

namespace DefaultSlap.Message
{
    public readonly struct SlapMessage
    {
        public readonly Rectangle DeathZone;

        public SlapMessage(Rectangle deathZone)
        {
            DeathZone = deathZone;
        }
    }
}
