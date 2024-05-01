using System;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.PauseServices;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Forms.Controllers
{
    public class UiContainerGameOverService : IUiContainerService
    {
        private readonly ILoadService _loadService;
        private readonly IPauseService _pauseService;

        public UiContainerGameOverService(
            ILoadService loadService,
            IPauseService pauseService)
        {
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _pauseService = pauseService ?? throw new ArgumentNullException(nameof(pauseService));
        }

        public void Enable()
        {
            //TODO добавить логику проигрыша
            //TODO логику сброса сохранений перетащить в кнопку?
            _pauseService.Pause();
        }

        public void Disable()
        {
            _pauseService.Continue();
        }
    }
}