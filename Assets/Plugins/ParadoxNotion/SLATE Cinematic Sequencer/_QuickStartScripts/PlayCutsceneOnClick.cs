using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Framework;
using UnityEngine;
using UnityEngine.Events;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer._QuickStartScripts
{
    [AddComponentMenu("SLATE/Play Cutscene On Click")]
    public class PlayCutsceneOnClick : MonoBehaviour
    {
        public Cutscene cutscene;
        public float startTime;
        public UnityEvent onFinish;

        public void OnMouseDown() {

            if ( cutscene == null ) {
                Debug.LogError("Cutscene is not provided", gameObject);
                return;
            }

            cutscene.Play(startTime, () => { onFinish.Invoke(); });
        }

        void Reset() {
            var collider = GetComponent<Collider>();
            if ( collider == null ) {
                collider = gameObject.AddComponent<BoxCollider>();
            }
        }

        public static GameObject Create() {
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.name = "Cutscene Click Trigger";
            go.AddComponent<PlayCutsceneOnClick>();
            return go;
        }
    }
}