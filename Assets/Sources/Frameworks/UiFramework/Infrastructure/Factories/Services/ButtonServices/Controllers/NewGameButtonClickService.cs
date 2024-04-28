using System;
using Sources.Domain.Models.Data.Ids;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.InfrastructureInterfaces.Services.LoadServices;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.ButtonServices.Controllers
{
    public class NewGameButtonClickService : ICustomButtonClickService
    {
        private readonly ILoadService _loadService;
        private readonly IFormService _formService;

        public NewGameButtonClickService(
            ILoadService loadService, 
            IFormService formService)
        {
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public void Enable(UiFormButton button)
        {
        }

        public void Disable(UiFormButton button)
        {
        }

        public void OnClick(UiFormButton button)
        {
            if (_loadService.HasKey(ModelId.PlayerWallet))
            {
                _formService.Show(FormId.WarningNewGame);
                
                return;
            }
            
            _formService.Show(FormId.NewGame);
        }
    }
}