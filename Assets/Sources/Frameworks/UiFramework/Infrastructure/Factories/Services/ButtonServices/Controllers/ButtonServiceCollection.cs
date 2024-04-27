using System.Collections.Generic;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.ButtonServices.Controllers
{
    public class ButtonServiceCollection
    {
        private readonly Dictionary<FormId, IButtonService> _buttonServices = new Dictionary<FormId, IButtonService>();

        public ButtonServiceCollection(
            PauseButtonService pauseButtonService,
            VoidButtonService voidButtonService)
        {
            _buttonServices[FormId.Default] = voidButtonService;
            _buttonServices[FormId.Hud] = voidButtonService;
            _buttonServices[FormId.Pause] = pauseButtonService;
            _buttonServices[FormId.Settings] = pauseButtonService;
            _buttonServices[FormId.Upgrade] = pauseButtonService;
            _buttonServices[FormId.GameOver] = pauseButtonService;
            _buttonServices[FormId.LevelCompleted] = pauseButtonService;
            _buttonServices[FormId.GreetingTutorial] = voidButtonService;
            _buttonServices[FormId.RewardTutorial] = voidButtonService;
            _buttonServices[FormId.SaveTutorial] = voidButtonService;
            _buttonServices[FormId.HealthBarTutorial] = voidButtonService;
            _buttonServices[FormId.EnemySpawnPointsTutorial] = voidButtonService;
            _buttonServices[FormId.KillEnemyCounterTutorial] = voidButtonService;
            _buttonServices[FormId.UpgradeFormBottomAbilitiesTutorial] = voidButtonService;
            _buttonServices[FormId.UpgradeFormTopAbilitiesTutorial] = voidButtonService;
        }

        public IButtonService GetButtonService(FormId formId)
        {
            if (_buttonServices.ContainsKey(formId) == false)
                throw new KeyNotFoundException(formId.ToString());
            
            return _buttonServices[formId];
        }
    }
}