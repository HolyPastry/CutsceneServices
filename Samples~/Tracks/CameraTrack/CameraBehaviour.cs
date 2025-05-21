
using Holypastry.Bakery.Cameras;
using UnityEngine.Playables;

namespace Holypastry.Bakery.Custscenes
{
    public class CameraBehaviour : PlayableBehaviour
    {
        public CameraReference CameraReference;
        public CameraController CameraController;

        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            base.OnBehaviourPlay(playable, info);

            if (CameraController != null)
                CameraReference = CameraController.CameraReference;

            if (CameraReference != null)
                CameraServices.SetCamera(CameraReference);
        }

        public override void OnBehaviourPause(Playable playable, FrameData info)
        {
            base.OnBehaviourPause(playable, info);
            // Debug
            // .Log("Transition Pause");
        }
    }
}
