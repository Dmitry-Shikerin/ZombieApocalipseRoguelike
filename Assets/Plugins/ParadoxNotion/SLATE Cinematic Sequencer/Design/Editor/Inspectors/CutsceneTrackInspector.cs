#if UNITY_EDITOR

using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Framework;
using UnityEditor;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design.Editor.Inspectors
{

    [CustomEditor(typeof(CutsceneTrack), true)]
    public class CutsceneTrackInspector : UnityEditor.Editor
    {

        private CutsceneTrack track {
            get { return (CutsceneTrack)target; }
        }

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            /*		
                        if (track is IKeyable){
                            var keyable = track as IKeyable;
                            if (keyable.animationData != null && keyable.animationData.isValid){
                                for (var i = 0; i < keyable.animationData.animatedParameters.Count; i++){
                                    GUILayout.Space(2);
                                    AnimatableParameterEditor.ShowParameter(keyable.animationData.animatedParameters[i], keyable);
                                }
                            }
                        }
            */
        }
    }
}

#endif