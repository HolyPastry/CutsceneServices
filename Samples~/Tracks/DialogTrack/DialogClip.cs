using UnityEngine;
using UnityEngine.Playables;

namespace Holypastry.Bakery.Custscenes
{
    public class DialogClip : PlayableAsset
    {
        public string InkKnot;
        public bool EndCinematicWhenFinished;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<DialogBehaviour>.Create(graph);
            var behavior = playable.GetBehaviour();
            behavior.InkKnot = InkKnot;
            behavior.EndCinematicWhenFinished = EndCinematicWhenFinished;
            return playable;
        }

    }
}
