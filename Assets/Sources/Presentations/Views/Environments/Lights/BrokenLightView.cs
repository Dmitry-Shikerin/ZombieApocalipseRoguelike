using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Sources.Presentations.Views.Environments.Lights
{
    public class BrokenLightView : View
    {
        [Required] [SerializeField] private Light _light;
        
        private CancellationTokenSource _cancellationTokenSource;

        private void OnEnable()
        {
            _cancellationTokenSource = new CancellationTokenSource();

            StartBlinking(_cancellationTokenSource.Token);
        }

        private void OnDisable()
        {
            _cancellationTokenSource.Cancel();
        }
        
        private async void StartBlinking(CancellationToken cancellationToken)
        {
            try
            {
                while (cancellationToken.IsCancellationRequested == false)
                {
                    _light.enabled = false;
                    await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: cancellationToken);

                    _light.enabled = true;
                    await UniTask.Delay(TimeSpan.FromSeconds(3), cancellationToken: cancellationToken);

                    await UniTask.Yield(cancellationToken);
                }
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}