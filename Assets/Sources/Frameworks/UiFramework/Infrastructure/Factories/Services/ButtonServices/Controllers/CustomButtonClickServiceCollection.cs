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
            CompleteTutorialButtonClickService completeTutorialButtonClickService)
        {
            _buttonServices = new Dictionary<ButtonId, ICustomButtonClickService>()
            {
                [ButtonId.FromPauseToMainMenuScene] = loadMainMenuButtonClickService,
                [ButtonId.CompleteTutorial] = completeTutorialButtonClickService,
            };
        }

        public ICustomButtonClickService Get(UiFormButton button)
        {
            if(_buttonServices.ContainsKey(button.ButtonId) == false)
                throw new KeyNotFoundException(button.FormId.ToString());
            
            return _buttonServices[button.ButtonId];
        }
    }
}