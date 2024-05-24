using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Framework;
using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Utility;
using UnityEngine;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer._QuickStartScripts
{

    [AddComponentMenu("SLATE/Stop Cutscene On Trigger")]
    public class StopCutsceneOnTrigger : MonoBehaviour
    {

        public Cutscene cutscene;
        public bool checkSpecificTagOnly = true;
        public string tagName = "Player";
        public Cutscene.StopMode stopMode;

        void OnTriggerEnter(Collider other) {
            if ( cutscene == null ) {
                Debug.LogError("Cutscene is not provided", gameObject);
                return;
            }

            if ( checkSpecificTagOnly && !string.IsNullOrEmpty(tagName) ) {
                if ( other.gameObject.tag != tagName ) {
                    return;
                }
            }

            enabled = false;
            cutscene.Stop(stopMode);
        }

        void Reset() {
            var collider = gameObject.GetAddComponent<BoxCollider>();
            collider.isTrigger = true;
        }
    }
}