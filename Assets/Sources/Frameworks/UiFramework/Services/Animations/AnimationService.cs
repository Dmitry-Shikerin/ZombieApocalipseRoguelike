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
        private UiAnimator _uiAnimator;
        private UiUiUiUiButton _uiUiUiButton;
        private CancellationTokenSource _cancellationTokenSource;

        public void Awake()
        {
            if (_uiAnimator.ReactionAnimationType == ReactionAnimationType.ButtonClick)
            {
                _uiUiUiButton = _uiAnimator.GetComponent<UiUiUiUiButton>();
                
                if(_uiUiUiButton == null)
                    throw new NullReferenceException(nameof(_uiUiUiButton));
            }
        }

        public void Enable()
        {
            _cancellationTokenSource = new CancellationTokenSource();

            if (_uiAnimator.ReactionAnimationType == ReactionAnimationType.ButtonClick)
                _uiUiUiButton.AddClickListener(PlayAnimation);

            if (_uiAnimator.ReactionAnimationType == ReactionAnimationType.ShowView)
                PlayAnimation();
        }

        public void Disable()
        {
            if (_uiAnimator.ReactionAnimationType == ReactionAnimationType.ButtonClick)
                _uiUiUiButton.RemoveClickListener(PlayAnimation);

            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void Construct(UiAnimator playerWallet)
        {
            _uiAnimator = playerWallet;
        }

        private async void PlayAnimation()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();

            if (_uiAnimator.AnimationType == AnimationType.Scale)
            {
                await PlayScaleAnimationAsync(_cancellationTokenSource.Token);

                return;
            }

            if (_uiAnimator.AnimationType == AnimationType.Rotate)
            {
                await PlayRotateAnimationAsync(_cancellationTokenSource.Token);
            }
        }

        private async UniTask PlayScaleAnimationAsync(CancellationToken token)
        {
            try
            {
                while (Vector3.Distance(_uiUiUiButton.transform.localScale, _uiAnimator.TargetScale) > 0.01f)
                {
                    _uiUiUiButton.transform.localScale = Vector3.MoveTowards(
                        _uiUiUiButton.transform.localScale,
                        _uiAnimator.TargetScale,
                        _uiAnimator.AnimationDuration);

                    await UniTask.Yield(token);
                }

                while (Vector3.Distance(_uiUiUiButton.transform.localScale, _uiAnimator.FromScale) > 0.01f)
                {
                    _uiUiUiButton.transform.localScale = Vector3.MoveTowards(
                        _uiUiUiButton.transform.localScale,
                        _uiAnimator.FromScale,
                        _uiAnimator.AnimationDuration);

                    await UniTask.Yield(token);
                }
            }
            catch (OperationCanceledException)
            {
                _uiUiUiButton.transform.localScale = _uiAnimator.FromScale;
            }
        }

        private async UniTask PlayRotateAnimationAsync(CancellationToken token)
        {
            while (_uiAnimator != null && token.IsCancellationRequested == false && _uiAnimator.enabled)
            {
                if(_uiAnimator == null)
                    return;
                    
                _uiAnimator?.transform.Rotate(_uiAnimator.RotationVector);

                await UniTask.Yield(token);
            }

            try
            {
            }
            catch (OperationCanceledException)
            {
            }
        }

        public void Destroy()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}