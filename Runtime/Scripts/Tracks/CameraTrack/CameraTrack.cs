using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Holypastry.Bakery.Custscenes
{

    [TrackClipType(typeof(CameraClip))]

    public class CameraTrack : TrackAsset
    {

        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            foreach (TimelineClip clip in m_Clips)
            {
                CameraClip cameraClip = clip.asset as CameraClip;
                if (cameraClip != null && cameraClip.CameraReference != null)
                {
                    clip.displayName = cameraClip.CameraReference.name;
                }
            }

            ScriptPlayable<CameraBehaviour> playable = ScriptPlayable<CameraBehaviour>.Create(graph, inputCount);
            return playable;
        }

    }
}
