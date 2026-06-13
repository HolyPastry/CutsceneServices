using UnityEngine;
using UnityEngine.Playables;

namespace Holypastry.Bakery.Custscenes
{
    public class FadeClip : PlayableAsset
    {
        public FadeType transitionType = FadeType.NoFade;
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<FadeBehaviour>.Create(graph);
            var behavior = playable.GetBehaviour();
            behavior.transitionType = transitionType;

            return playable;
        }
    }
}
