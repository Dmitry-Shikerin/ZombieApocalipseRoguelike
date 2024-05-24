#if UNITY_EDITOR

using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design.Editor.Inspectors;
using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Clips.Runtime.ActionTrack.ActorActions.Paths;
using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Paths;
using UnityEditor;
using UnityEngine;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Clips.Editor
{

    [CustomEditor(typeof(FollowPath))]
    public class FollowPathInspector : ActionClipInspector<FollowPath>
    {
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            if ( action.path == null ) {
                if ( GUILayout.Button("Create New Path") ) {
                    action.path = BezierPath.Create(action.root.context.transform);
                    UnityEditor.Selection.activeObject = action.path;
                }
            }
        }
    }
}

#endif