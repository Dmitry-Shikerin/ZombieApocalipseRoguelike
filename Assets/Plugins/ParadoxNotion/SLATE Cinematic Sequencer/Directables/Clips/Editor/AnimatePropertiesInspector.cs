#if UNITY_EDITOR

using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design.Editor.Inspectors;
using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design.Partial_Editor;
using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Clips.Runtime.ActionTrack.ActorActions;
using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Framework;
using UnityEditor;
using UnityEngine;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Clips.Editor
{

    [CustomEditor(typeof(AnimateProperties))]
    public class AnimatePropertiesInspector : ActionClipInspector<AnimateProperties>
    {

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            GUILayout.Space(10);
            if ( GUILayout.Button("Add Property") ) {
                EditorTools.ShowAnimatedPropertySelectionMenu(action.actor.gameObject, action.TryAddParameter);
            }
        }
    }
}

#endif