#if UNITY_EDITOR

using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design.Editor.Windows;
using UnityEditor;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design.Editor.Other
{

    public class AssetProcessor : AssetPostprocessor
    {

        //We stop the cutscene preview if any before importing new model because it causes crash if animations used by cutscene are re-imported.
        void OnPreprocessModel() {
            if ( CutsceneEditor.current != null && CutsceneEditor.current.cutscene != null ) {
                CutsceneEditor.current.Stop(true);
            }
        }
    }
}

#endif