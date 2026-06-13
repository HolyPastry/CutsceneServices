using UnityEngine;
using UnityEngine.Playables;

namespace Holypastry.Bakery.Custscenes
{
    public class PlayerVisibilityClip : PlayableAsset
    {
        public PlayerVisibility PlayerVisibility;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<PlayerVisibilityBehaviour>.Create(graph);
            var behaviour = playable.GetBehaviour();
            behaviour.PlayerVisibility = PlayerVisibility;

            return playable;
        }
    }
}
