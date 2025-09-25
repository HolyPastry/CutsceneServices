using System.Collections;

using Holypastry.Bakery.Flow;
using UnityEngine;

namespace Holypastry.Bakery.Cutscenes
{
    public class SceneSetupCutscene : SceneSetupScript
    {
        [SerializeField] private Cutscene _cutscene;

        public override IEnumerator Routine()
        {
            yield return FlowServices.WaitUntilReady();

            _cutscene.PlayCutscene();
            yield return _cutscene.WaitUntilEnded;
        }
    }
}
