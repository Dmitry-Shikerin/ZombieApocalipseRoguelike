using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design;
using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Framework;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Clips.Runtime.ActionTrack.ActorActions.GameObject
{

    [Category("GameObject")]
    [Description("Make the actor target for the currently active Dynamic Shot Controller (if used by the current active Camera Shot in the cutscene).")]
    public class MakeCameraTarget : ActorActionClip
    {
        public bool setTransposerTarget = true;
        public bool setComposerTarget = true;

        private UnityEngine.Transform wasTransposerTarget;
        private UnityEngine.Transform wasComposerTarget;

        protected override void OnEnter() {
            var cameraTrack = ( root as Cutscene ).cameraTrack;
            if ( cameraTrack != null ) {
                var dynamicController = cameraTrack.currentShot.targetShot.dynamicController;
                wasTransposerTarget = dynamicController.transposer.target;
                wasComposerTarget = dynamicController.composer.target;
                if ( setTransposerTarget ) { dynamicController.transposer.target = actor.transform; }
                if ( setComposerTarget ) { dynamicController.composer.target = actor.transform; }
            }
        }

        protected override void OnReverse() {
            if ( wasTransposerTarget != null || wasComposerTarget != null ) {
                var dynamicController = ( root as Cutscene ).cameraTrack.currentShot.targetShot.dynamicController;
                dynamicController.transposer.target = wasTransposerTarget;
                dynamicController.composer.target = wasComposerTarget;
            }
        }
    }
}