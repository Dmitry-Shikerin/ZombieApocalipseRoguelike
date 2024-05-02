using System;
using Sources.Domain.Models.Data.Ids;
using Sources.Frameworks.UiFramework.Domain.Commands;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.InfrastructureInterfaces.Services.LoadServices;

namespace Sources.Frameworks.UiFramework.Infrastructure.Commands.Buttons
{
    public class NewGameCommand : IButtonCommand
    {
        private readonly ILoadService _loadService;
        private readonly IFormService _formService;

        public NewGameCommand(ILoadService loadService, IFormService formService)
        {
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public ButtonCommandId Id => ButtonCommandId.NewGame;
        
        public void Handle(UiButton uiButton)
        {
            if (_loadService.HasKey(ModelId.PlayerWallet))
            {
                _formService.ShowOneForm(FormId.WarningNewGame);
                
                return;
            }
            
            _formService.ShowOneForm(FormId.NewGame);
        }
    }
}