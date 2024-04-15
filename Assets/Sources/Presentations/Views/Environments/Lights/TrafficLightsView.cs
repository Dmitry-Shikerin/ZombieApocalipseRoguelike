using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Sources.Presentations.Views.Environments.Lights
{
    public class TrafficLightsView : View
    {
        [Required] [SerializeField] private List<TrafficLight> _trafficLights;
        
        private TimeSpan _blinkDaley = TimeSpan.FromSeconds(0.5f);

        private CancellationTokenSource _cancellationTokenSource;

        private float _currentTime = 0f;

        private void OnEnable()
        {
            _cancellationTokenSource = new CancellationTokenSource();

            StartTrafficLights(_cancellationTokenSource.Token);
        }

        private void OnDisable()
        {
            _cancellationTokenSource.Cancel();
        }

        private async void StartTrafficLights(CancellationToken cancellationToken)
        {
            try
            {
                while (cancellationToken.IsCancellationRequested == false)
                {
                    foreach (TrafficLight trafficLight in _trafficLights)
                    {
                        _trafficLights
                            .Except(new List<TrafficLight> { trafficLight })
                            .ToList()
                            .ForEach(trafficLight => trafficLight.Hide());

                        trafficLight.Show();
                        
                        await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: cancellationToken);
                    }

                    foreach (TrafficLight trafficLight in _trafficLights)
                        trafficLight.Show();
                    
                    await UniTask.Delay(_blinkDaley, cancellationToken: cancellationToken);
                    
                    foreach (TrafficLight trafficLight in _trafficLights)
                        trafficLight.Hide();
                    
                    await UniTask.Delay(_blinkDaley, cancellationToken: cancellationToken);
                    
                    foreach (TrafficLight trafficLight in _trafficLights)
                        trafficLight.Show();
                    
                    await UniTask.Delay(_blinkDaley, cancellationToken: cancellationToken);
                    
                    foreach (TrafficLight trafficLight in _trafficLights)
                        trafficLight.Hide();
                    
                    await UniTask.Delay(_blinkDaley, cancellationToken: cancellationToken);
                    
                    foreach (TrafficLight trafficLight in _trafficLights)
                        trafficLight.Show();
                    
                    await UniTask.Delay(_blinkDaley, cancellationToken: cancellationToken);
                    
                    foreach (TrafficLight trafficLight in _trafficLights)
                        trafficLight.Hide();
                    
                    await UniTask.Delay(_blinkDaley, cancellationToken: cancellationToken);
                }
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}