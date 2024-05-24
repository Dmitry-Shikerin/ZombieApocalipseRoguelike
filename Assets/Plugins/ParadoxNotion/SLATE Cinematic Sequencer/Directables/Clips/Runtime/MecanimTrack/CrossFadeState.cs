using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design;
using UnityEngine;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Clips.Runtime.MecanimTrack
{

    [Description("CrossFades to an Animator state within a period of time.")]
    public class CrossFadeState : MecanimBaseClip
    {

        [SerializeField]
        [HideInInspector]
        private float _length = 1f;

        [Required]
        public string stateName;

        public override string info {
            get { return string.Format("CrossFade State\n'{0}'", stateName); }
        }

        public override float length {
            get { return _length; }
            set { _length = value; }
        }

        public override float blendIn {
            get { return length; }
        }

        protected override void OnEnter() {
            actor.CrossFade(stateName, length, -1, float.NegativeInfinity);
        }
    }
}