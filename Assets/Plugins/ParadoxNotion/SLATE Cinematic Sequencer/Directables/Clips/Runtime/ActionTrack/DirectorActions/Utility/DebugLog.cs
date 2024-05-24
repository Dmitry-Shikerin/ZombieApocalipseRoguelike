using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design;
using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Framework;
using UnityEngine;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Clips.Runtime.ActionTrack.DirectorActions.Utility
{

    [Category("Utility")]
    public class DebugLog : DirectorActionClip
    {

        [LeftToggle]
        public bool neverSkip;
        public string text;

        public override string info {
            get { return string.Format("Debug Log\n'{0}'", text); }
        }

        protected override void OnEnter() {
            if ( this.WithinBufferTriggerRange(root.currentTime, startTime, neverSkip) ) {
                Debug.Log(string.Format("<b>Cutscene:</b> {0}", text));
            }
        }
    }
}