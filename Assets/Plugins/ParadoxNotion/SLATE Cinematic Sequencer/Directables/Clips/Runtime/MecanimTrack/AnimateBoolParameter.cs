using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design;
using UnityEngine;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Clips.Runtime.MecanimTrack
{

    [Description("Animate a bool Animator parameter and reset it back to previous value after a period of time.")]
    public class AnimateBoolParameter : MecanimBaseClip
    {

        [SerializeField]
        [HideInInspector]
        private float _length = 1f;

        public string parameterName;
        [AnimatableParameter]
        public bool value = true;

        private bool lastValue;

        public override bool isValid {
            get { return base.isValid && HasParameter(parameterName); }
        }

        public override string info {
            get { return string.Format("'{0}' Parameter", parameterName); }
        }

        public override float length {
            get { return _length; }
            set { _length = value; }
        }

        protected override void OnEnter() {
            lastValue = actor.GetBool(parameterName);
        }

        protected override void OnUpdate(float time) {
            actor.SetBool(parameterName, value);
        }

        protected override void OnExit() {
            if ( length > 0 ) {
                actor.SetBool(parameterName, lastValue);
            }
        }

        protected override void OnReverse() {
            if ( Application.isPlaying ) {
                actor.SetBool(parameterName, lastValue);
            }
        }
    }
}