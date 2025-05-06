using Holypastry.Bakery.Flow;
using UnityEngine.Playables;

namespace Holypastry.Bakery.Custscenes
{
    public class FadeBehaviour : PlayableBehaviour
    {
        public FadeType transitionType = FadeType.NoFade;
        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            base.OnBehaviourPlay(playable, info);
            var transition = new SceneTransition((float)playable.GetDuration());
            if (transitionType == FadeType.FadeIn)
                FlowServices.FadeIn(transition);
            else if (transitionType == FadeType.FadeOut)
                FlowServices.FadeOut(transition);

            // Debug.Log($"Transition Play: {playable.GetDuration()}");

        }
        public override void OnBehaviourPause(Playable playable, FrameData info)
        {
            base.OnBehaviourPause(playable, info);
            // Debug.Log("Transition Pause");
        }

    }
}
