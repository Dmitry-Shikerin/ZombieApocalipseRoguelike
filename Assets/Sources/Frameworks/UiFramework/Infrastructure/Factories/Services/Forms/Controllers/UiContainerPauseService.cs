using System;
using Sources.InfrastructureInterfaces.Services.PauseServices;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Forms.Controllers
{
    public class UiContainerPauseService : IUiContainerService
    {
        private readonly IPauseService _pauseService;

        public UiContainerPauseService(IPauseService pauseService)
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
    }
}