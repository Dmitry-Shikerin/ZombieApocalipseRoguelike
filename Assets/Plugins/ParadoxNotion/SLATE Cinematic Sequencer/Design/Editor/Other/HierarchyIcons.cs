#if UNITY_EDITOR

using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Cameras;
using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design.Partial_Editor;
using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Framework;
using UnityEditor;
using UnityEngine;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design.Editor.Other
{

    [InitializeOnLoad]
    public static class HierarchyIcons
    {

        static HierarchyIcons() {
            EditorApplication.hierarchyWindowItemOnGUI += ShowIcons;
            Styles.cutsceneIcon = (Texture2D)Resources.Load("Cutscene Icon"); //ensure
        }

        static void ShowIcons(int ID, Rect r) {
            var go = EditorUtility.InstanceIDToObject(ID) as GameObject;
            if ( go == null ) {
                return;
            }

            if ( go.GetComponent<Cutscene>() != null ) {
                r.x = r.xMax - 16;
                r.width = 16;
                GUI.DrawTexture(r, Styles.cutsceneIcon);
            }

            if ( go.GetComponent(typeof(IDirectableCamera)) != null ) {
                r.x = r.xMax - 16;
                r.width = 16;
                GUI.DrawTexture(r, Styles.cameraIcon);
            }
        }
    }
}

#endif