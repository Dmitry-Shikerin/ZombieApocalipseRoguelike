#if UNITY_EDITOR

using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Utility;
using UnityEditor;
using UnityEngine;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design.Editor.Drawers
{

    [CustomPropertyDrawer(typeof(CallbackAttribute))]
    public class CallbackDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            var att = (CallbackAttribute)attribute;
            EditorGUI.BeginChangeCheck();
            EditorGUI.PropertyField(position, property, label);
            if ( EditorGUI.EndChangeCheck() ) {
                var parent = ReflectionTools.GetRelativeMemberParent(property.serializedObject.targetObject, property.propertyPath);
                var method = parent.GetType().RTGetMethod(att.methodName);
                method.Invoke(parent, null);
            }
        }
    }
}

#endif