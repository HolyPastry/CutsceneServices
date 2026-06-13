using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Holypastry.Bakery.Custscenes
{

    [TrackClipType(typeof(DialogClip))]

    public class DialogTrack : TrackAsset
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            foreach (TimelineClip clip in m_Clips)
            {
                DialogClip dialogClip = clip.asset as DialogClip;
                if (dialogClip != null)
                {
                    clip.displayName = dialogClip.InkKnot;
                }
            }

            ScriptPlayable<DialogBehaviour> playable = ScriptPlayable<DialogBehaviour>.Create(graph, inputCount);
            return playable;
        }

    }
}
