using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Holypastry.Bakery.Custscenes
{
    [TrackClipType(typeof(MusicClip))]

    public class MusicTrack : TrackAsset
    {

        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            foreach (TimelineClip clip in m_Clips)
            {
                MusicClip fadeClip = clip.asset as MusicClip;
                // the template variable comes from classes made with the playable wizard

                if (fadeClip.MusicAction == MusicAction.PlayMusic)
                {
                    clip.displayName = "Play";
                }
                else if (fadeClip.MusicAction == MusicAction.StopMusic)
                {
                    clip.displayName = "Stop";
                }

            }

            ScriptPlayable<MusicBehaviour> playable = ScriptPlayable<MusicBehaviour>.Create(graph, inputCount);
            //  playable.GetBehaviour().bodyTarget = go.GetComponent<PlayableDirector>().GetGenericBinding(this) as PetTimelineBodyTarget;
            return playable;
        }
    }
}
