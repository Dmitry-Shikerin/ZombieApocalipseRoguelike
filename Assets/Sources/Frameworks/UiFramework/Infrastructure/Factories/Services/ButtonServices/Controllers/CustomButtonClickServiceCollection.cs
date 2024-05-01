using System.Collections.Generic;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Buttons.Types;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.ButtonServices.Controllers
{
    //TODO наверное это команды а не сервисы
    public class CustomButtonClickServiceCollection
    {
        private readonly Dictionary<ButtonId, ICustomButtonClickService> _buttonServices;
        
        public CustomButtonClickServiceCollection(
            LoadMainMenuButtonClickService loadMainMenuButtonClickService,
            CompleteTutorialButtonClickService completeTutorialButtonClickService,
            NewGameButtonClickService newGameButtonClickService,
            FromWarningToNewGameButtonClickService fromWarningToNewGameButtonClickService,
            LeaderBoardButtonClickService leaderBoardButtonClickService,
            FromSettingsToHudButtonClickService fromSettingsToHudButtonClickService,
            LoadGameButtonClickService loadGameButtonClickService,
            FromSettingsToPauseButtonClickService fromSettingsToPauseButtonClickService,
            FromLevelCompletedToMeinMenuSceneButtonClickService fromLevelCompletedToMeinMenuSceneButtonClickService)
        {
            _buttonServices = new Dictionary<ButtonId, ICustomButtonClickService>()
            {
                [ButtonId.FromSettingsToHud] = fromSettingsToHudButtonClickService,
                [ButtonId.FromPauseToMainMenuScene] = loadMainMenuButtonClickService,
                [ButtonId.CompleteTutorial] = completeTutorialButtonClickService,
                [ButtonId.NewGame] = newGameButtonClickService,
                [ButtonId.FromWarningNewGameToNewGame] = fromWarningToNewGameButtonClickService,
                [ButtonId.LeaderBoard] = leaderBoardButtonClickService,
                [ButtonId.LoadGame] = loadGameButtonClickService,
                [ButtonId.FromSettingsToPause] = fromSettingsToPauseButtonClickService,
                [ButtonId.FromLevelCompletedToMainMenuScene] = fromLevelCompletedToMeinMenuSceneButtonClickService,
                [ButtonId.FromGameOverToMainMenuScene] = loadMainMenuButtonClickService,
            };
        }

        public ICustomButtonClickService Get(UiButton button)
        {
            if(_buttonServices.ContainsKey(button.ButtonId) == false)
                throw new KeyNotFoundException(button.FormId.ToString());
            
            return _buttonServices[button.ButtonId];
        }
    }
}