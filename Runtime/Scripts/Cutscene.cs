using System;
using System.Collections;

using UnityEngine;
using UnityEngine.Playables;



namespace Holypastry.Bakery.Cutscenes
{
    public class Cutscene : MonoBehaviour
    {
        [SerializeField] private CutsceneTag _cutsceneTag;
        [SerializeField] private PlayableDirector _playableDirector;

        private bool _ended;

        public WaitUntil WaitUntilEnded => new(() => _ended);
        public CutsceneTag Tag => _cutsceneTag;

        public static event Action<CutsceneTag> OnCutsceneEnd = delegate { };
        public static event Action<CutsceneTag> OnCutsceneStart = delegate { };
        public static event Action<CutsceneTag> OnCutsceneSkipped = delegate { };

        public static Action<CutsceneTag> PlayRequest = delegate { };
        public Func<bool> IsPlaying = () => false;


        void OnEnable()
        {
            PlayRequest += Play;
            IsPlaying = () => !_ended;
        }

        void OnDisable()
        {
            PlayRequest -= Play;
            IsPlaying = () => false;
        }

        void OnDestroy()
        {
            StopAllCoroutines();
        }

        private void Play(CutsceneTag tag)
        {
            if (_cutsceneTag != tag) return;

            PlayCutscene();
        }

        public void PlayCutscene()
        {
            _ended = false;
            _playableDirector.Play();
            OnCutsceneStart.Invoke(_cutsceneTag);
            StartCoroutine(CheckTimelineEnd());

        }

        private IEnumerator CheckTimelineEnd()
        {
            while (true)
            {
                yield return null;
                switch (_playableDirector.extrapolationMode)
                {
                    case DirectorWrapMode.Loop:
                        yield break;

                    case DirectorWrapMode.Hold:
                        if (_playableDirector.time >= _playableDirector.duration)
                            EndCutscene();
                        break;

                    case DirectorWrapMode.None:
                        if (_playableDirector.state != PlayState.Playing)
                            EndCutscene();
                        break;
                }
            }
        }

        public void Skip()
        {
            _playableDirector.Stop();
            OnCutsceneSkipped.Invoke(_cutsceneTag);
        }

        private void EndCutscene()
        {
            StopAllCoroutines();
            _ended = true;
            OnCutsceneEnd?.Invoke(_cutsceneTag);
        }
    }
}