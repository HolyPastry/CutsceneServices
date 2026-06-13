
using UnityEngine.Playables;

namespace Holypastry.Bakery.Custscenes
{
    public class PlayerVisibilityBehaviour : PlayableBehaviour
    {
        public PlayerVisibility PlayerVisibility;

        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            base.OnBehaviourPlay(playable, info);
            if (PlayerVisibility == PlayerVisibility.On)
            {
                // PlayerServices.ShowPlayer();
                // DialogServices.ShowInteractiveNPCs();
                // DonkeyServices.ShowDonkey();

            }
            else if (PlayerVisibility == PlayerVisibility.Off)
            {
                // PlayerServices.HidePlayer();
                // DialogServices.HideInteractiveNPCs();
                // DonkeyServices.HideDonkey();
            }

        }

    }
}
