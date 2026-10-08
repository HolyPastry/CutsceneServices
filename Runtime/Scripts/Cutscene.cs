using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

namespace Bakery.Cutscenes
{
    public class Cutscene : MonoBehaviour
    {
        [SerializeField]
        private CutsceneTag _cutsceneTag;

        [SerializeField]
        private PlayableDirector _playableDirector;

        private bool _ended;

        public WaitUntil WaitUntilEnded => new(() => _ended);
        public CutsceneTag Tag => _cutsceneTag;

        public static event Action<CutsceneTag> OnCutsceneEnd = delegate { };
        public static event Action<CutsceneTag> OnCutsceneStart = delegate { };
        public static event Action<CutsceneTag> OnCutsceneSkipped = delegate { };

        public static Action<CutsceneTag> PlayRequest = delegate { };
        public static bool IsPlaying = false;
        private bool _paused;

        void OnEnable()
        {
            PlayRequest += Play;
        }

        void OnDisable()
        {
            PlayRequest -= Play;
        }

        void OnDestroy()
        {
            StopAllCoroutines();
        }

        private void Play(CutsceneTag tag)
        {
            if (_cutsceneTag != tag)
                return;

            PlayCutscene();
        }

        private Coroutine WaitUntilReady()
        {
            return StartCoroutine(WaitUntilReadyCoroutine());
        }

        private IEnumerator WaitUntilReadyCoroutine()
        {
            yield return new WaitUntil(() => _playableDirector.state == PlayState.Playing);
        }

        void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus && !_paused)
            {
                _paused = true;
                Pause();
            }
            if (hasFocus && _paused)
            {
                _paused = false;
                Resume();
            }
        }

        private void Pause()
        {
            _playableDirector.Pause();
        }

        private void Resume()
        {
            _playableDirector.Resume();
        }

        public void PlayCutscene()
        {
            _ended = false;
            IsPlaying = true;
            _playableDirector.Play();
            OnCutsceneStart.Invoke(_cutsceneTag);
            StartCoroutine(CheckTimelineEnd());
        }

        private IEnumerator CheckTimelineEnd()
        {
            while (true)
            {
                yield return null;
                if (_paused)
                    continue;

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
            _ended = true;
            IsPlaying = false;
            StopAllCoroutines();
        }

        private void EndCutscene()
        {
            StopAllCoroutines();
            _ended = true;
            IsPlaying = false;
            OnCutsceneEnd?.Invoke(_cutsceneTag);
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        public static void ResetStatics()
        {
            OnCutsceneEnd = delegate { };
            OnCutsceneStart = delegate { };
            OnCutsceneSkipped = delegate { };
            PlayRequest = delegate { };
            IsPlaying = false;

#if UNITY_EDITOR
            Debug.Log("[Cutscenes] Static fields reset");
#endif
        }
    }
}
