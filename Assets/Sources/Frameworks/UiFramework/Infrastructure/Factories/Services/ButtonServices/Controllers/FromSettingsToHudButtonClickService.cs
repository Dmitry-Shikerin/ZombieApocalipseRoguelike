using System;
using Sources.Domain.Models.Data.Ids;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.InfrastructureInterfaces.Services.LoadServices;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.ButtonServices.Controllers
{
    public class FromSettingsToHudButtonClickService : ICustomButtonClickService
    {
        private readonly IFormService _formService;
        private readonly ILoadService _loadService;

        public FromSettingsToHudButtonClickService(
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
            _loadService.Save(ModelId.Volume);
            _formService.Show(FormId.Hud);
        }
    }
}