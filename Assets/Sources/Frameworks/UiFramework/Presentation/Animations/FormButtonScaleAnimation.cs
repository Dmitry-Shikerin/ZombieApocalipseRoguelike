using Sources.Frameworks.UiFramework.Presentation.Animations.Types;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.Services.Animations;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Animations;
using Sources.Presentations.Views;
using UnityEngine;

namespace Sources.Frameworks.UiFramework.Presentation.Animations
{
    [RequireComponent(typeof(UiFormButton))]
    public class FormButtonScaleAnimation : View
    {
        [field: SerializeField] public AnimationType AnimationType { get; private set; }
        [field: SerializeField] public ReactionAnimationType ReactionAnimationType { get; private set; }
        [field: SerializeField] public ScaleAnimationType ScaleAnimationType { get; private set; }
        [field: SerializeField] public float AnimationDuration { get; private set; } = 0.1f;
        [field: SerializeField] public Vector3 FromScale { get; private set; }
        [field: SerializeField] public Vector3 TargetScale { get; private set; }

        IAnimationService _animationService = new AnimationService();
        
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