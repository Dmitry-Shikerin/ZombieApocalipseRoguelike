using Sirenix.OdinInspector;
using Sources.Frameworks.UiFramework.Presentation.Animations.Types;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.Services.Animations;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Animations;
using Sources.Presentations.Views;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Frameworks.UiFramework.Presentation.Animations
{
    [RequireComponent(typeof(UiFormButton))]
    public class FormButtonScaleAnimation : View
    {
        [DisplayAsString(false)] [HideLabel]
        [SerializeField] private string _title = "<size=24><b><color=#FF5555><i>UiAnimator</i></color></b></size>";
        [TabGroup("Types")]
        [SerializeField] private AnimationType _animationType = AnimationType.Scale;
        [TabGroup("Types")]
        [SerializeField] private ReactionAnimationType _reactionAnimationType = ReactionAnimationType.ButtonClick;
        [TabGroup("Types")]
        [SerializeField] private ScaleAnimationType _scaleAnimationType;
        [TabGroup("Settings")]
        [SerializeField] private float _animationDuration = 0.1f;
        [TabGroup("Settings")]
        [SerializeField] private Vector3 _fromScale = new Vector3(1,1,1);
        [TabGroup("Settings")]
        [SerializeField] private Vector3 _targetScale = new Vector3(0.7f,0.7f,0.7f);

        private readonly IAnimationService _animationService = new AnimationService();

        public AnimationType AnimationType => _animationType;
        public ReactionAnimationType ReactionAnimationType => _reactionAnimationType;
        public ScaleAnimationType ScaleAnimationType => _scaleAnimationType;
        public float AnimationDuration => _animationDuration;
        public Vector3 FromScale => _fromScale;
        public Vector3 TargetScale => _targetScale;
        
        private void Awake()
        {
            _animationService.Construct(this);
            _animationService.Awake();
        }

        private void OnEnable() =>
            _animationService.Enable();

        private void OnDisable() =>
            _animationService.Disable();
    }
}