using Bakery;
using UnityEngine.Playables;

namespace Holypastry.Bakery.Custscenes
{
    public class FadeBehaviour : PlayableBehaviour
    {
        public FadeType transitionType = FadeType.NoFade;
        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            base.OnBehaviourPlay(playable, info);

            if (transitionType == FadeType.FadeIn)
                Flow.Visuals().FadeIn((float)playable.GetDuration());
            else if (transitionType == FadeType.FadeOut)
                Flow.Visuals().FadeOut((float)playable.GetDuration());
        }
        public override void OnBehaviourPause(Playable playable, FrameData info)
        {
            base.OnBehaviourPause(playable, info);
        }

    }
}
