
using UnityEngine;
using UnityEngine.Playables;

namespace Holypastry.Bakery.Custscenes
{
    public class PlaceClip : PlayableAsset
    {
        public ExposedReference<Transform> PositionReference;
        public ExposedReference<Transform> ObjectToPlace;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<PlaceBehaviour>.Create(graph);
            var behavior = playable.GetBehaviour();
            behavior.PositionReference = PositionReference.Resolve(graph.GetResolver());
            behavior.ObjectToPlace = ObjectToPlace.Resolve(graph.GetResolver());

            return playable;
        }
    }
}
