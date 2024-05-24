#if UNITY_EDITOR

using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Framework;
using UnityEditor;
using UnityEngine;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design.Editor.Inspectors
{

    [CustomEditor(typeof(CutsceneGroup), true)]
    public class CutsceneGroupInspector : UnityEditor.Editor
    {

        private CutsceneGroup group {
            get { return (CutsceneGroup)target; }
        }

        public override void OnInspectorGUI() {
            GUI.enabled = group.root.currentTime == 0;
            base.OnInspectorGUI();
        }
    }
}

#endif