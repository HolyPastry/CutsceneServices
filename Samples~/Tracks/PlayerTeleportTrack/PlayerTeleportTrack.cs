using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Holypastry.Bakery.Custscenes
{
    [TrackClipType(typeof(PlayerTeleportClip))]
    public class PlayerTeleportTrack : TrackAsset
    {

        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            foreach (TimelineClip clip in m_Clips)
            {
                PlayerTeleportClip playerClip = clip.asset as PlayerTeleportClip;
                var destination = playerClip.Destination.Resolve(graph.GetResolver());
                if (destination != null)
                {
                    clip.displayName = destination.name;
                }
                else
                {
                    clip.displayName = "Teleport";
                }
            }
            ScriptPlayable<PlayerTeleportBehaviour> playable = ScriptPlayable<PlayerTeleportBehaviour>.Create(graph, inputCount);
            //  playable.GetBehaviour().bodyTarget = go.GetComponent<PlayableDirector>().GetGenericBinding(this) as PetTimelineBodyTarget;
            return playable;
        }
    }

}