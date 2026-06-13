
using UnityEngine;
using UnityEngine.Playables;

namespace Holypastry.Bakery.Custscenes
{
    public class PlaceBehaviour : PlayableBehaviour
    {
        public Transform PositionReference;

        public Transform ObjectToPlace;

        // public override void OnBehaviourPlay(Playable playable, FrameData info)
        // {
        //     base.OnBehaviourPlay(playable, info);

        // }

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            base.ProcessFrame(playable, info, playerData);

            ObjectToPlace.SetPositionAndRotation(PositionReference.position, PositionReference.rotation);
        }
        // public override void OnBehaviourPause(Playable playable, FrameData info)
        // {
        //     base.OnBehaviourPause(playable, info);
        //     // Debug.Log("Transition Pause");
        // }

    }
}
