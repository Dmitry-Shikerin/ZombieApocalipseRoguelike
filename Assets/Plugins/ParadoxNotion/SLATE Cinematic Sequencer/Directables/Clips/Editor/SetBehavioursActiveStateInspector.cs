#if UNITY_EDITOR

using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design.Editor.Inspectors;
using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Clips.Runtime.ActionTrack.ActorActions.GameObject;
using UnityEditor;
using UnityEngine;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Clips.Editor
{

    [CustomEditor(typeof(SetBehavioursActiveState))]
    public class SetBehavioursActiveStateInspector : ActionClipInspector<SetBehavioursActiveState>
    {

        public override void OnInspectorGUI() {

            base.OnInspectorGUI();

            if ( action.actor != null ) {

                var behaviours = action.actor.GetComponents<Behaviour>();
                if ( behaviours.Length == 0 ) {
                    EditorGUILayout.HelpBox("There are no Behaviours attached on the actor", MessageType.Warning);
                    return;
                }

                GUILayout.BeginVertical("box");
                GUILayout.Label("Choose Behaviours to affect:");

                foreach ( var b in behaviours ) {
                    var typeName = b.GetType().Name;
                    var toggle = action.behaviourNames.Contains(typeName);
                    toggle = EditorGUILayout.Toggle(typeName, toggle);
                    if ( toggle ) {
                        if ( !action.behaviourNames.Contains(typeName) ) {
                            action.behaviourNames.Add(typeName);
                        }
                    } else {
                        if ( action.behaviourNames.Contains(typeName) ) {
                            action.behaviourNames.Remove(typeName);
                        }
                    }
                }

                GUILayout.EndVertical();
            }
        }
    }
}

#endif