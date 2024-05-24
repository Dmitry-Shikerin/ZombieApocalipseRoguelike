using UnityEngine;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Clips.Runtime.ActionTrack.DirectorActions.Events
{

    abstract public class SendGlobalMessage<T> : SendGlobalMessage
    {

        public T value;

        public override string info {
            get { return string.Format("Global Message\n'{0}'({1})", message, value != null ? value.ToString() : "null"); }
        }

        protected override void OnEnter() {

            if ( !Application.isPlaying ) {
                return;
            }

            this.root.SendGlobalMessage(message, value);
        }
    }
}