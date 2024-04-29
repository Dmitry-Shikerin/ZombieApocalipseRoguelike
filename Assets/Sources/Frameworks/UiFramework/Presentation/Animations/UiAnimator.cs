using Sirenix.OdinInspector;
using Sources.Frameworks.UiFramework.Domain.Constants;
using Sources.Frameworks.UiFramework.Presentation.Animations.Types;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.Services.Animations;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Animations;
using Sources.Presentations.Views;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Frameworks.UiFramework.Presentation.Animations
{
    public class UiAnimator : View
    {
        [FormerlySerializedAs("_title")] 
        [DisplayAsString(false)] [HideLabel] 
        [SerializeField] private string _label = UiConstant.UiAnimatorLabel;

        [TabGroup("Types")] 
        [SerializeField] private AnimationType _animationType = AnimationType.Scale;

        [TabGroup("Types")] 
        [SerializeField] private ReactionAnimationType _reactionAnimationType = ReactionAnimationType.ButtonClick;

        [EnableIf("_animationType", AnimationType.Scale)] 
        [TabGroup("ScaleSettings")] 
        [SerializeField] private ScaleAnimationType _scaleAnimationType;

        [EnableIf("_animationType", AnimationType.Scale)] 
        [TabGroup("ScaleSettings")] 
        [SerializeField] private float _animationDuration = 0.1f;

        [EnableIf("_animationType", AnimationType.Scale)] 
        [TabGroup("ScaleSettings")]
        [SerializeField] private Vector3 _fromScale = new Vector3(1, 1, 1);

        [EnableIf("_animationType", AnimationType.Scale)] 
        [TabGroup("ScaleSettings")] 
        [SerializeField] private Vector3 _targetScale = new Vector3(0.7f, 0.7f, 0.7f);

        [EnableIf("_animationType", AnimationType.Rotate)] 
        [TabGroup("RotaSettings")] 
        [SerializeField] private Vector3 _rotationVector = new Vector3(0, 0, -0.5f);

        private readonly IAnimationService _animationService = new AnimationService();

        public AnimationType AnimationType => _animationType;
        public ReactionAnimationType ReactionAnimationType => _reactionAnimationType;
        public ScaleAnimationType ScaleAnimationType => _scaleAnimationType;
        public float AnimationDuration => _animationDuration;
        public Vector3 FromScale => _fromScale;
        public Vector3 TargetScale => _targetScale;
        public Vector3 RotationVector => _rotationVector;

        private void Awake()
        {
            _animationService.Construct(this);
            _animationService.Awake();
        }

        private void OnEnable() =>
            _animationService.Enable();

        private void OnDisable() =>
            _animationService.Disable();

        private void OnDestroy() =>
            _animationService.Destroy();
    }
}