

using UnityEngine.Playables;

namespace Holypastry.Bakery.Custscenes
{
    public class DialogBehaviour : PlayableBehaviour
    {
        public string InkKnot;
        internal bool EndCinematicWhenFinished;

        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            base.OnBehaviourPlay(playable, info);
            if (string.IsNullOrEmpty(InkKnot)) return;

            // var transition = new SceneTransition((float)playable.GetDuration());
            DialogServices.Start(InkKnot);
            // if (EndCinematicWhenFinished)
            //     DialogEvents.OnDialogEnd += OnDialogEnd;

        }

        // private void OnDialogEnd()
        // {
        //     DialogEvents.OnDialogEnd -= OnDialogEnd;
        //     PlayerServices.SetCinematicMode(false);
        // }

        // public override void OnBehaviourPause(Playable playable, FrameData info)
        // {
        //     base.OnBehaviourPause(playable, info);
        //     if (!Application.isPlaying)
        //         DialogServices.InterruptDialog();
        //     // Debug.Log("Transition Pause");
        // }

    }
}
