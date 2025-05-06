using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Holypastry.Bakery.Custscenes
{
    // public class TransitionTrackAsset
    // {

    // }
    // [TrackBindingType(typeof(TransitionTrackAsset))]
    [TrackClipType(typeof(FadeClip))]

    public class FadeTrack : TrackAsset
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            foreach (TimelineClip clip in m_Clips)
            {
                FadeClip fadeClip = clip.asset as FadeClip;
                // the template variable comes from classes made with the playable wizard

                if (fadeClip.transitionType == FadeType.FadeIn)
                {
                    clip.displayName = "Fade In";
                }
                else if (fadeClip.transitionType == FadeType.FadeOut)
                {
                    clip.displayName = "Fade Out";
                }
                else if (fadeClip.transitionType == FadeType.NoFade)
                {
                    clip.displayName = "No Fade";
                }
            }

            ScriptPlayable<FadeBehaviour> playable = ScriptPlayable<FadeBehaviour>.Create(graph, inputCount);
            //  playable.GetBehaviour().bodyTarget = go.GetComponent<PlayableDirector>().GetGenericBinding(this) as PetTimelineBodyTarget;
            return playable;
        }

    }
}
