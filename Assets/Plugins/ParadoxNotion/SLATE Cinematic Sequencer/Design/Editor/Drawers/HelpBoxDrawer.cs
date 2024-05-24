#if UNITY_EDITOR

using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design.Partial_Editor;
using UnityEditor;
using UnityEngine;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design.Editor.Drawers
{

    [CustomPropertyDrawer(typeof(HelpBoxAttribute))]
    public class HelpBoxDrawer : DecoratorDrawer
    {
        public override float GetHeight() { return -2; }
        public override void OnGUI(Rect position) {
            if ( Prefs.showDescriptions ) {
                EditorGUILayout.HelpBox(( attribute as HelpBoxAttribute ).text, MessageType.None);
            }
        }
    }
}

#endif