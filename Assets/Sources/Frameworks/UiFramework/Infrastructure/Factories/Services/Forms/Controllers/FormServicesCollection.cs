using System.Collections.Generic;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Forms.Controllers
{
    public class FormServicesCollection
    {
        private readonly Dictionary<FormId, IUiContainerService> _formServices = new Dictionary<FormId, IUiContainerService>();
        
        public FormServicesCollection(
            UiContainerVoidService uiContainerVoidService,
            UiContainerPauseService uiContainerPauseService)
        {
            _formServices[FormId.Hud] = uiContainerVoidService;
            _formServices[FormId.Pause] = uiContainerPauseService;
            _formServices[FormId.Settings] = uiContainerVoidService;
            _formServices[FormId.Upgrade] = uiContainerVoidService;
            _formServices[FormId.GameOver] = uiContainerVoidService;
            _formServices[FormId.LevelCompleted] = uiContainerVoidService;
            _formServices[FormId.GreetingTutorial] = uiContainerVoidService;
            _formServices[FormId.RewardTutorial] = uiContainerVoidService;
            _formServices[FormId.SaveTutorial] = uiContainerVoidService;
            _formServices[FormId.HealthBarTutorial] = uiContainerVoidService;
            _formServices[FormId.EnemySpawnPointsTutorial] = uiContainerVoidService;
            _formServices[FormId.KillEnemyCounterTutorial] = uiContainerVoidService;
            _formServices[FormId.UpgradeFormBottomAbilitiesTutorial] = uiContainerVoidService;
            _formServices[FormId.UpgradeFormTopAbilitiesTutorial] = uiContainerVoidService;

        }

        public IUiContainerService Get(FormId uiContainerId)
        {
            return _formServices[uiContainerId];
        }
    }
}