
using Holypastry.Bakery.Cameras;
using UnityEngine;
using UnityEngine.Playables;

namespace Holypastry.Bakery.Custscenes
{
    public class CameraClip : PlayableAsset
    {
        public CameraReference CameraReference;
        public ExposedReference<CameraController> CameraControllerReference;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<CameraBehaviour>.Create(graph);
            var behavior = playable.GetBehaviour();
            behavior.CameraReference = CameraReference;
            behavior.CameraController = CameraControllerReference.Resolve(graph.GetResolver());

            return playable;
        }
    }
}
