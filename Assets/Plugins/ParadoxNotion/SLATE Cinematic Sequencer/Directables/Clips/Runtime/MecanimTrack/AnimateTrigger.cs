using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design;
using UnityEngine;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Clips.Runtime.MecanimTrack
{

    public class AnimateTrigger : MecanimBaseClip
    {

        [SerializeField]
        [HideInInspector]
        private float _length = 1f;

        public string triggerName;
        [AnimatableParameter]
        public bool value;

        public override bool isValid {
            get { return base.isValid && HasParameter(triggerName); }
        }

        public override string info {
            get { return string.Format("'{0}' Trigger", triggerName); }
        }

        public override float length {
            get { return _length; }
            set { _length = value; }
        }

        protected override void OnUpdate(float time) {
            if ( value ) {
                actor.SetTrigger(triggerName);
            } else {
                actor.ResetTrigger(triggerName);
            }
        }
    }
}