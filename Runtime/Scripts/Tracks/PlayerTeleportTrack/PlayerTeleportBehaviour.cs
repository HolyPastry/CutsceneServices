using UnityEngine;
using UnityEngine.Playables;

namespace Holypastry.Bakery.Custscenes
{
    public class PlayerTeleportBehaviour : PlayableBehaviour
    {
        public GameObject TeleportLocation;
        internal GameObject DonkeyLocation;

        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            base.OnBehaviourPlay(playable, info);
            // if (TeleportLocation != null)
            //     PlayerServices.TeleportPlayer(TeleportLocation.transform);

            // if (DonkeyLocation != null)
            //     DonkeyServices.Teleport(DonkeyLocation.transform);
        }

    }
}
