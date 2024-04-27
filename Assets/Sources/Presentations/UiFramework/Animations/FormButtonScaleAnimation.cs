using System;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Sources.Presentation.Ui.Animations.Types;
using Sources.Presentation.Ui.Buttons;
using Sources.Presentation.Views;
using Sources.Presentations.Views;
using UnityEngine;

namespace Sources.Presentation.Ui.Animations
{
    [RequireComponent(typeof(FormButtonView))]
    public class FormButtonScaleAnimation : View
    {
        [SerializeField] private AnimationType _animationType;
        [SerializeField] private ReactionAnimationType _reactionAnimationType;
        [SerializeField] private ScaleAnimationType _scaleAnimationType;
        [SerializeField] private float _animationDuration = 0.1f;
        [SerializeField] private Vector3 _fromScale;
        [SerializeField] private Vector3 _targetScale;

        private FormButtonView _buttonView;
        private CancellationTokenSource _cancellationTokenSource;

        private void Awake()
        {
            // if (_reactionAnimationType == ReactionAnimationType.ButtonClick)
                _buttonView = GetComponent<FormButtonView>();
            
        }

        private void OnEnable()
        {
            _cancellationTokenSource = new CancellationTokenSource();

            if (_reactionAnimationType == ReactionAnimationType.ButtonClick)
                _buttonView.AddClickListener(PlayAnimation);
            
            if(_reactionAnimationType == ReactionAnimationType.ShowView)
                PlayAnimation();
        }

        private void OnDisable()
        {
            if (_reactionAnimationType == ReactionAnimationType.ButtonClick)
                _buttonView.RemoveClickListener(PlayAnimation);
            
            _cancellationTokenSource = new CancellationTokenSource();
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
                _buttonView.transform.localScale = _fromScale;
            }
        }

        private async Task PlayAnimationAsync(CancellationToken token)
        {
            while (Vector3.Distance(_buttonView.transform.localScale, _targetScale) > 0.01f)
            {
                _buttonView.transform.localScale = Vector3.MoveTowards(
                    _buttonView.transform.localScale, _targetScale, _animationDuration);

                await UniTask.Yield(token);
            }

            while (Vector3.Distance(_buttonView.transform.localScale, _fromScale) > 0.01f)
            {
                _buttonView.transform.localScale = Vector3.MoveTowards(
                    _buttonView.transform.localScale, _fromScale, _animationDuration);

                await UniTask.Yield(token);
            }
        }
    }
}