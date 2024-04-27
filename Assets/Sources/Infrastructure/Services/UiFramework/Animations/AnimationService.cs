using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.InfrastructureInterfaces.Services.UiFrameworks.Animations;
using Sources.Presentation.Ui.Animations.Types;
using Sources.Presentation.Ui.Buttons;
using Sources.Presentations.UiFramework.Animations;
using UnityEngine;

namespace Sources.Infrastructure.Services.UiFramework.Animations
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