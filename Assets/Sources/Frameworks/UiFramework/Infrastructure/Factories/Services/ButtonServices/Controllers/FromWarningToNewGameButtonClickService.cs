using System;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.InfrastructureInterfaces.Services.LoadServices;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.ButtonServices.Controllers
{
    public class FromWarningToNewGameButtonClickService : ICustomButtonClickService
    {
        private readonly IFormService _formService;
        private readonly ILoadService _loadService;

        public FromWarningToNewGameButtonClickService(
            IFormService formService,
            ILoadService loadService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }

        public void Enable(UiFormButton button)
        {
        }

        public void Disable(UiFormButton button)
        {
        }

        public void OnClick(UiFormButton button)
        {
            _loadService.ClearAll();
            _formService.Show(FormId.NewGame);
        }
    }
}