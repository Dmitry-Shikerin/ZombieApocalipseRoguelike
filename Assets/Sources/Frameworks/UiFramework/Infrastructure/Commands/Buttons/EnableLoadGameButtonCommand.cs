using System;
using Sources.Domain.Models.Data.Ids;
using Sources.Frameworks.UiFramework.Domain.Commands;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.InfrastructureInterfaces.Services.LoadServices;

namespace Sources.Frameworks.UiFramework.Infrastructure.Commands.Buttons
{
    public class EnableLoadGameButtonCommand :  IButtonCommand
    {
        private readonly ILoadService _loadService;

        public EnableLoadGameButtonCommand(
            ILoadService loadService)
        {
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }

        public ButtonCommandId Id => ButtonCommandId.EnableLoadGameButton;
        
        public void Handle(UiUiUiUiButton uiUiUiUiButton)
        {
            uiUiUiUiButton.Show();
            
            if (_loadService.HasKey(ModelId.PlayerWallet) == false)
                uiUiUiUiButton.Hide();
        }
    }
}