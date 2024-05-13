using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using Sources.Domain.Models.Constants;
using UnityEngine;

namespace Sources.Presentations.Views.Environments.Lights
{
    public class BrokenLightView : View
    {
        [Required] [SerializeField] private Light _light;
        
        private readonly TimeSpan _firstDelay = TimeSpan.FromSeconds(BrokenLightConst.FirstDelay);
        private readonly TimeSpan _secondDelay = TimeSpan.FromSeconds(BrokenLightConst.SecondDelay);
        
        private CancellationTokenSource _cancellationTokenSource;

        private void OnEnable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            StartBlinking(_cancellationTokenSource.Token);
        }

        private void OnDisable() =>
            _cancellationTokenSource.Cancel();

        private async void StartBlinking(CancellationToken cancellationToken)
        {
            try
            {
                while (cancellationToken.IsCancellationRequested == false)
                {
                    _light.enabled = false;
                    await UniTask.Delay(_firstDelay, cancellationToken: cancellationToken);

                    _light.enabled = true;
                    await UniTask.Delay(_secondDelay, cancellationToken: cancellationToken);
                }
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}