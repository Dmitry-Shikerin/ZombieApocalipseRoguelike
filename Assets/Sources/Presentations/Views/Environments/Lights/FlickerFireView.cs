using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Sources.Presentations.Views.Environments.Lights
{
    public class FlickerFireView : View
    {
        [Required] [SerializeField] private Light _flickerLight;
        [SerializeField] private AnimationCurve _animationCurve;

        private CancellationTokenSource _cancellationTokenSource;
        
        private float _currentTime = 0f;
        
        private void OnEnable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            
            StartFlicker(_cancellationTokenSource.Token);
        }

        private void OnDisable()
        {
            _cancellationTokenSource.Cancel();
        }

        private async void StartFlicker(CancellationToken cancellationToken)
        {
            try
            {
                while (cancellationToken.IsCancellationRequested == false)
                {
                    _currentTime += Time.deltaTime;
                    _flickerLight.intensity = _animationCurve.Evaluate(_currentTime);

                    if (_currentTime >= _animationCurve.keys[_animationCurve.length - 1].time)
                        _currentTime = 0f;

                    await UniTask.Yield(cancellationToken);
                }
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}