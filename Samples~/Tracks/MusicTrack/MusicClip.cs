using UnityEngine;
using UnityEngine.Playables;

namespace Holypastry.Bakery.Custscenes
{
    public class MusicClip : PlayableAsset
    {
        public MusicAction MusicAction;
        public AudioClip AudioClip;
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<MusicBehaviour>.Create(graph);
            var behaviour = playable.GetBehaviour();
            behaviour.MusicAction = MusicAction;
            behaviour.AudioClip = AudioClip;
            return playable;
        }
    }
}
