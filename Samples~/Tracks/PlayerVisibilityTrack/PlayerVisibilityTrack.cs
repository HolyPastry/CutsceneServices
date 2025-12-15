using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Holypastry.Bakery.Custscenes
{
    [TrackClipType(typeof(PlayerVisibilityClip))]
    public class PlayerVisibilityTrack : TrackAsset
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            foreach (TimelineClip clip in m_Clips)
            {
                PlayerVisibilityClip playerClip = clip.asset as PlayerVisibilityClip;
                // the template variable comes from classes made with the playable wizard

                if (playerClip.PlayerVisibility == PlayerVisibility.On)
                {
                    clip.displayName = "Show";
                }
                else if (playerClip.PlayerVisibility == PlayerVisibility.Off)
                {
                    clip.displayName = "Hide";
                }

            }

            ScriptPlayable<PlayerVisibilityBehaviour> playable = ScriptPlayable<PlayerVisibilityBehaviour>.Create(graph, inputCount);
            //  playable.GetBehaviour().bodyTarget = go.GetComponent<PlayableDirector>().GetGenericBinding(this) as PetTimelineBodyTarget;
            return playable;
        }
    }
}
