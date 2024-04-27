using System;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.InfrastructureInterfaces.Services.PauseServices;
using UnityEngine;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.ButtonServices.Controllers
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
            _pauseService.Pause();
        }

        public void Disable()
        {
            _pauseService.Continue();
        }
        
        public void OnClick(UiFormButton button)
        {
        }
    }
}