using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Holypastry.Bakery.Custscenes
{

    [TrackClipType(typeof(PlaceClip))]

    public class PlaceTrack : TrackAsset
    {

        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            foreach (TimelineClip clip in m_Clips)
            {
                PlaceClip placeClip = clip.asset as PlaceClip;
                Transform PositionReference = placeClip.PositionReference.Resolve(graph.GetResolver());
                Transform ObjectToPlace = placeClip.ObjectToPlace.Resolve(graph.GetResolver());
                if (placeClip != null && PositionReference != null && ObjectToPlace != null)
                {
                    clip.displayName = $"{ObjectToPlace.name} to {PositionReference.name}";
                }
            }

            ScriptPlayable<PlaceBehaviour> playable = ScriptPlayable<PlaceBehaviour>.Create(graph, inputCount);
            return playable;
        }

    }
}
