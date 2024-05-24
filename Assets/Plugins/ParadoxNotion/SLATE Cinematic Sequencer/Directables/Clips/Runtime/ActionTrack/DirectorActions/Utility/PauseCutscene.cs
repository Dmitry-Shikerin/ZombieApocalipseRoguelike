using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Clips.Runtime.ActionTrack.DirectorActions.Utility
{

    [Category("Utility")]
    [Description("Pauses the Cutscene (PlayMode Only). It's up to other scripts to resume it.")]
    public class PauseCutscene : DirectorActionClip
    {
        protected override void OnEnter() {
            if ( !UnityEngine.Application.isPlaying ) {
                return;
            }

            if ( ( root.currentTime - this.startTime ) < ( UnityEngine.Time.deltaTime * root.playbackSpeed ) ) {
                root.Pause();
                root.Sample(this.startTime);
            }
        }
    }
}