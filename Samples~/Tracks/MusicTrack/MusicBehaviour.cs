using UnityEngine;
using UnityEngine.Playables;

namespace Holypastry.Bakery.Custscenes
{
    public class MusicBehaviour : PlayableBehaviour
    {
        public MusicAction MusicAction;
        public AudioClip AudioClip;
        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            base.OnBehaviourPlay(playable, info);
            if (MusicAction == MusicAction.PlayMusic)
            {
                MusicServices.PlayOneShotCustomFade(AudioClip, (float)playable.GetDuration());
            }
            else if (MusicAction == MusicAction.StopMusic)
            {
                MusicServices.StopMusicCustomFade((float)playable.GetDuration());
            }

            else if (MusicAction == MusicAction.DuckMusic)
            {
                MusicServices.DuckMusic();
            }
            else if (MusicAction == MusicAction.UnduckMusic)
            {
                MusicServices.UnduckMusic();
            }

        }

    }
}
