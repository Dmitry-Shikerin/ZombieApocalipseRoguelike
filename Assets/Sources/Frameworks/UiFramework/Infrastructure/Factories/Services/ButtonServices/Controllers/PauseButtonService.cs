using System;
using Sources.InfrastructureInterfaces.Services.PauseServices;
using UnityEngine;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.ButtonServices
{
    public class PauseButtonService : IButtonService
    {
        private readonly IPauseService _pauseService;

        public PauseButtonService(IPauseService pauseService)
        {
            _pauseService = pauseService ?? throw new ArgumentNullException(nameof(pauseService));
        }

        public void Enable()
        {
            Debug.Log("Pause");
            _pauseService.Pause();
        }

        public void Disable()
        {
            Debug.Log("Continue");
            _pauseService.Continue();
        }

        public void OnClick()
        {
        }
    }
}