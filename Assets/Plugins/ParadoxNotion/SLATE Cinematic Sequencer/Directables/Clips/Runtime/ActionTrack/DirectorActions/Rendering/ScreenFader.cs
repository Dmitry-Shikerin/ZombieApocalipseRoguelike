using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Cameras;
using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design;
using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Utility;
using UnityEngine;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Clips.Runtime.ActionTrack.DirectorActions.Rendering
{

    [Category("Rendering")]
    [Description("An alternative way to fade the screen. Fade out/in can also be done through the Camera Shot clip in the Camera Track, but with this clip, more effects can be achieved.")]
    public class ScreenFader : DirectorActionClip
    {

        [SerializeField]
        [HideInInspector]
        private float _length = 4f;
        [SerializeField]
        [HideInInspector]
        private float _blendIn = 1f;
        [SerializeField]
        [HideInInspector]
        private float _blendOut = 1f;

        [AnimatableParameter(0, 1)]
        public float fade = 1;
        [AnimatableParameter("Color")]
        public Color outColor = Color.black;
        public EaseType interpolation = EaseType.QuadraticInOut;

        private Color lastColor;

        public override float length {
            get { return _length; }
            set { _length = value; }
        }

        public override float blendIn {
            get { return _blendIn; }
            set { _blendIn = value; }
        }

        public override float blendOut {
            get { return _blendOut; }
            set { _blendOut = value; }
        }

        protected override void OnEnter() {
            lastColor = DirectorGUI.lastFadeColor;
        }

        protected override void OnUpdate(float deltaTime) {
            var color = outColor;
            color.a = Easing.Ease(interpolation, 0, 1, GetClipWeight(deltaTime) * fade);
            DirectorGUI.UpdateFade(color);
        }

        protected override void OnReverse() {
            DirectorGUI.UpdateFade(lastColor);
        }
    }
}