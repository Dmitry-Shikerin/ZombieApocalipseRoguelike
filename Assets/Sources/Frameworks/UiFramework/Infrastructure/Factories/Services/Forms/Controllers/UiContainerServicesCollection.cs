using System.Collections.Generic;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Forms.Controllers
{
    public class UiContainerServicesCollection
    {
        private readonly Dictionary<FormId, IUiContainerService> _formServices = 
            new Dictionary<FormId, IUiContainerService>();
        
        public UiContainerServicesCollection(
            UiContainerVoidService uiContainerVoidService,
            UiContainerPauseService uiContainerPauseService)
        {
            _formServices[FormId.Hud] = uiContainerVoidService;
            _formServices[FormId.Pause] = uiContainerPauseService;
            _formServices[FormId.Settings] = uiContainerPauseService;
            _formServices[FormId.Upgrade] = uiContainerPauseService;
            _formServices[FormId.GameOver] = uiContainerPauseService;
            _formServices[FormId.LevelCompleted] = uiContainerPauseService;
            _formServices[FormId.GreetingTutorial] = uiContainerPauseService;
            _formServices[FormId.RewardTutorial] = uiContainerPauseService;
            _formServices[FormId.SaveTutorial] = uiContainerPauseService;
            _formServices[FormId.HealthBarTutorial] = uiContainerPauseService;
            _formServices[FormId.EnemySpawnPointsTutorial] = uiContainerPauseService;
            _formServices[FormId.KillEnemyCounterTutorial] = uiContainerPauseService;
            _formServices[FormId.UpgradeFormBottomAbilitiesTutorial] = uiContainerPauseService;
            _formServices[FormId.UpgradeFormTopAbilitiesTutorial] = uiContainerPauseService;

        }

        public IUiContainerService Get(FormId uiContainerId) =>
            _formServices[uiContainerId];
    }
}