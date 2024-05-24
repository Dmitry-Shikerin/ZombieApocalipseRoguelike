using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Cameras;
using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design;
using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Utility;
using UnityEngine;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Clips.Runtime.ActionTrack.DirectorActions.Rendering
{

    [Category("Rendering")]
    [Description("Show text on screen")]
    public class OverlayText : DirectorActionClip
    {

        [SerializeField]
        [HideInInspector]
        private float _length = 2;
        [SerializeField]
        [HideInInspector]
        private float _blendIn = 0.25f;
        [SerializeField]
        [HideInInspector]
        private float _blendOut = 0.25f;

        [Multiline(5)]
        public string text = "In a galaxy far far away...";
        public TextAnchor anchor = TextAnchor.MiddleCenter;
        public EaseType interpolation = EaseType.QuadraticInOut;

        [AnimatableParameter]
        public Color color = Color.white;
        [AnimatableParameter]
        public float size = 40f;
        [AnimatableParameter]
        public Vector2 position;

        public override string info {
            get { return string.Format("'{0}'", text); }
        }

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

        protected override void OnUpdate(float time) {
            var lerpColor = color;
            lerpColor.a = Easing.Ease(interpolation, 0, color.a, GetClipWeight(time));
            DirectorGUI.UpdateOverlayText(text, lerpColor, size, anchor, position);
        }
    }
}
