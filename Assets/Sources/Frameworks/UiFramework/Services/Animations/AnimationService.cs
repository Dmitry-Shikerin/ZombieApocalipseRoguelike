using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Frameworks.UiFramework.Presentation.Animations;
using Sources.Frameworks.UiFramework.Presentation.Animations.Types;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Animations;
using UnityEngine;

namespace Sources.Frameworks.UiFramework.Services.Animations
{
    public class AnimationService : IAnimationService
    {
        private FormButtonScaleAnimation _formButtonScaleAnimation;
        private UiFormButton _button;
        private CancellationTokenSource _cancellationTokenSource;

        public void Awake()
        {
            _button = _formButtonScaleAnimation.GetComponent<UiFormButton>();
        }

        public void Enable()
        {
            _cancellationTokenSource = new CancellationTokenSource();

            if (_formButtonScaleAnimation.ReactionAnimationType == ReactionAnimationType.ButtonClick)
                _button.AddClickListener(PlayAnimation);

            if (_formButtonScaleAnimation.ReactionAnimationType == ReactionAnimationType.ShowView)
                PlayAnimation();
        }

        public void Disable()
        {
            if (_formButtonScaleAnimation.ReactionAnimationType == ReactionAnimationType.ButtonClick)
                _button.RemoveClickListener(PlayAnimation);

            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void Construct(FormButtonScaleAnimation formButtonScaleAnimation)
        {
            _formButtonScaleAnimation = formButtonScaleAnimation;
        }
        
        private async void PlayAnimation()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                await PlayAnimationAsync(_cancellationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
                _button.transform.localScale = _formButtonScaleAnimation.FromScale;
            }
        }

        private async UniTask PlayAnimationAsync(CancellationToken token)
        {
            while (Vector3.Distance(_button.transform.localScale, _formButtonScaleAnimation.TargetScale) > 0.01f)
            {
                _button.transform.localScale = Vector3.MoveTowards(
                    _button.transform.localScale, 
                    _formButtonScaleAnimation.TargetScale, 
                    _formButtonScaleAnimation.AnimationDuration);

                await UniTask.Yield(token);
            }

            while (Vector3.Distance(_button.transform.localScale, _formButtonScaleAnimation.FromScale) > 0.01f)
            {
                _button.transform.localScale = Vector3.MoveTowards(
                    _button.transform.localScale, 
                    _formButtonScaleAnimation.FromScale,
                    _formButtonScaleAnimation.AnimationDuration);

                await UniTask.Yield(token);
            }
        }
    }
}