using UnityEngine;
using UnityEngine.Playables;

namespace Holypastry.Bakery.Custscenes
{
    public class PlayerTeleportClip : PlayableAsset
    {
        public ExposedReference<GameObject> Destination;
        public ExposedReference<GameObject> DonkeyPosition;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<PlayerTeleportBehaviour>.Create(graph);
            var behavior = playable.GetBehaviour();
            behavior.TeleportLocation = Destination.Resolve(graph.GetResolver());
            behavior.DonkeyLocation = DonkeyPosition.Resolve(graph.GetResolver());
            return playable;
        }
    }
}
