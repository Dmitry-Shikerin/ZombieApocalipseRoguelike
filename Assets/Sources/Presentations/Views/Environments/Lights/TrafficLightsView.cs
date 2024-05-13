using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using Sources.Domain.Models.Constants;
using UnityEngine;

namespace Sources.Presentations.Views.Environments.Lights
{
    public class TrafficLightsView : View
    {
        [Required] [SerializeField] private List<TrafficLight> _trafficLights;
        
        private TimeSpan _blinkDelayTimeSpan = TimeSpan.FromSeconds(TrafficLightConst.BlinkDelay);
        private TimeSpan _hideDelayTimeSpan = TimeSpan.FromSeconds(TrafficLightConst.HideDelay);

        private CancellationTokenSource _cancellationTokenSource;
        
        private void OnEnable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            StartTrafficLights(_cancellationTokenSource.Token);
        }

        private void OnDisable() =>
            _cancellationTokenSource.Cancel();

        private async void StartTrafficLights(CancellationToken cancellationToken)
        {
            try
            {
                while (cancellationToken.IsCancellationRequested == false)
                {
                    await ChangeColor(cancellationToken);
                    await Blink(cancellationToken);
                }
            }
            catch (OperationCanceledException)
            {
            }
        }

        private async UniTask ChangeColor(CancellationToken cancellationToken)
        {
            foreach (TrafficLight trafficLight in _trafficLights)
            {
                _trafficLights
                    .Except(new List<TrafficLight> { trafficLight })
                    .ToList()
                    .ForEach(trafficLight => trafficLight.Hide());

                trafficLight.Show();
                        
                await UniTask.Delay(_hideDelayTimeSpan, cancellationToken: cancellationToken);
            }
        }

        private async UniTask Blink(CancellationToken cancellationToken)
        {
            for (int i = 0; i < 4; i++)
            {
                foreach (TrafficLight trafficLight in _trafficLights)
                    trafficLight.Show();
                    
                await UniTask.Delay(_blinkDelayTimeSpan, cancellationToken: cancellationToken);
                    
                foreach (TrafficLight trafficLight in _trafficLights)
                    trafficLight.Hide();
                    
                await UniTask.Delay(_blinkDelayTimeSpan, cancellationToken: cancellationToken);
            }
        }
    }
}