using System.Linq;
using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design;
using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Clips.Runtime.ActionTrack.ActorActions;
using UnityEngine;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Clips.Runtime.MecanimTrack
{

    [Attachable(typeof(Tracks.Runtime.Actor.MecanimTrack))]
    abstract public class MecanimBaseClip : ActorActionClip<Animator>
    {

        public override bool isValid {
            get { return actor != null && actor.runtimeAnimatorController != null; }
        }

        protected bool HasParameter(string name) {
            if ( actor == null ) {
                return false;
            }

            if ( !actor.isInitialized ) {
                return true;
            }

            //workaround Unity bug that takes place as soon as a scene is saved that renders animator error: "Animator is not playing an AnimatorController" when accessing parameters etc.
            if ( actor.runtimeAnimatorController != null && actor.GetCurrentAnimatorStateInfo(0).length == 0 ) {
                var wasActive = actor.gameObject.activeSelf;
                actor.gameObject.SetActive(false);
                actor.gameObject.SetActive(wasActive);
            }

            var parameters = actor.parameters;
            return parameters != null && parameters.FirstOrDefault(p => p.name == name) != null;
        }
    }
}