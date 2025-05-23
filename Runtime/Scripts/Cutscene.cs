using System;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Playables;



namespace Holypastry.Bakery.Cutscenes
{
    public class Cutscene : MonoBehaviour
    {
        [SerializeField] private CutsceneTag _cutsceneTag;
        [SerializeField] private PlayableDirector _playableDirector;

        //   [SerializeField] private List<Cutscene> _nextCutscenes;

        [SerializeField] private bool _goBackToGameplayAfterCutscene = true;

        private bool _ended;

        public WaitUntil WaitUntilEnded => new(() => _ended);
        public CutsceneTag Tag => _cutsceneTag;

        public static event Action<CutsceneTag> OnCutsceneEnd = delegate { };
        public static event Action<CutsceneTag> OnCutsceneStart = delegate { };
        public static event Action<CutsceneTag> OnCutsceneSkipped = delegate { };

        public static Action<CutsceneTag> PlayCutsceneRequest = delegate { };


        void OnEnable()
        {
            PlayCutsceneRequest += PlayCutscene;
        }

        void OnDisable()
        {
            PlayCutsceneRequest -= PlayCutscene;
        }

        void OnDestroy()
        {
            _playableDirector.stopped -= EndCutscene;

        }

        private void PlayCutscene(CutsceneTag tag)
        {
            if (_cutsceneTag == tag)
            {
                PlayCutscene();
            }
        }



        public void PlayCutscene()
        {
            _ended = false;

            _playableDirector.stopped += EndCutscene;

            _playableDirector.Play();
            OnCutsceneStart.Invoke(_cutsceneTag);

        }

        public void Skip()
        {
            _playableDirector.Stop();
            OnCutsceneSkipped.Invoke(_cutsceneTag);
        }

        private void EndCutscene(PlayableDirector director)
        {
            _playableDirector.stopped -= EndCutscene;

            //bool anyCutscenePlayed = false;
            // if (_nextCutscenes.Count > 0)
            //     foreach (var cutscene in _nextCutscenes)
            //         anyCutscenePlayed |= cutscene.PlayCutscene();

            if (_goBackToGameplayAfterCutscene)
            {
                _ended = true;
                OnCutsceneEnd?.Invoke(_cutsceneTag);
            }

        }
    }
}