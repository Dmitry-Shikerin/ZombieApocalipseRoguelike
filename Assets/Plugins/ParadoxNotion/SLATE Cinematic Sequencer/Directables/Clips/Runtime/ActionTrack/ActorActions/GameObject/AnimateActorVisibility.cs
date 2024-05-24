using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design;
using UnityEngine;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Clips.Runtime.ActionTrack.ActorActions.GameObject
{

    [Category("GameObject")]
    [Description("Set or animate the actor gameobject visibility.")]
    public class AnimateActorVisibility : ActorActionClip
    {

        [SerializeField]
        [HideInInspector]
        private float _length = 1;

        public override float length {
            get { return _length; }
            set { _length = value; }
        }

        [AnimatableParameter]
        public bool visible;

        private bool wasVisible;

        protected override void OnCreate() {
            visible = actor.activeSelf;
        }

        protected override void OnEnter() {
            wasVisible = actor.activeSelf;
        }

        protected override void OnUpdate(float time) {
            actor.SetActive(visible);
        }

        protected override void OnReverse() {
            actor.SetActive(wasVisible);
        }
    }
}