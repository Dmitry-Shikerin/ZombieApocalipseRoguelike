#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design.Editor.Drawers
{

    [CustomPropertyDrawer(typeof(ExampleTextAttribute))]
    public class ExampleTextDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            var attribute = (ExampleTextAttribute)base.attribute;
            if ( property.propertyType == SerializedPropertyType.String ) {
                property.stringValue = EditorGUI.TextField(position, label, property.stringValue);
                if ( string.IsNullOrEmpty(property.stringValue) ) {
                    var wasEnabled = GUI.enabled;
                    GUI.enabled = false;
                    GUI.color = new Color(1, 1, 1, 0.5f);
                    EditorGUI.TextField(position, " ", attribute.text);
                    GUI.color = Color.white;
                    GUI.enabled = wasEnabled;
                }
            } else {
                EditorGUI.LabelField(position, label.text, "Use [ExampleText] with string.");
            }
        }
    }
}

#endif