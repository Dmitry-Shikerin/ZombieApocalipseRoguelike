using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Framework;
using UnityEngine;
using UnityEngine.Events;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer._QuickStartScripts
{

    [AddComponentMenu("SLATE/Play Cutscene On Start")]
    public class PlayCutsceneOnStart : MonoBehaviour
    {

        public Cutscene cutscene;
        public float startTime;
        public UnityEvent onFinish;

        void Start() {
            if ( cutscene == null ) {
                Debug.LogError("Cutscene is not provided", gameObject);
                return;
            }

            cutscene.Play(startTime, () => { onFinish.Invoke(); });
        }

        public static GameObject Create() {
            return new GameObject("Cutscene Starter").AddComponent<PlayCutsceneOnStart>().gameObject;
        }
    }
}