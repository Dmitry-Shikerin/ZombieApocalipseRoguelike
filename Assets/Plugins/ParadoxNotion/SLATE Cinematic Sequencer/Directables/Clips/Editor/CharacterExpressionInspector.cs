#if UNITY_EDITOR

using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Characters;
using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design.Editor.Inspectors;
using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design.Partial_Editor;
using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Clips.Runtime.ActionTrack.ActorActions.Character;
using UnityEditor;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Clips.Editor
{

    [CustomEditor(typeof(CharacterExpression))]
    public class CharacterExpressionInspector : ActionClipInspector<CharacterExpression>
    {

        public override void OnInspectorGUI() {

            base.ShowCommonInspector();

            if ( action.actor != null ) {
                var character = action.actor.GetComponent<Character>();
                if ( character != null ) {
                    BlendShapeGroup current = null;
                    if ( !string.IsNullOrEmpty(action.expressionUID) ) { current = character.FindExpressionByUID(action.expressionUID); } else { current = character.FindExpressionByName(action.expressionName); }
                    var newExp = EditorTools.Popup<BlendShapeGroup>("Expression", current, character.expressions);
                    action.expressionName = newExp != null ? newExp.name : null;
                    action.expressionUID = newExp != null ? newExp.UID : null;
                }
            }

            base.ShowAnimatableParameters();
        }
    }
}

#endif