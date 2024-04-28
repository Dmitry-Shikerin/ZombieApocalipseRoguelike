using System;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.Tutorials;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.ButtonServices.Controllers
{
    public class CompleteTutorialButtonClickService : ICustomButtonClickService
    {
        private readonly ITutorialService _tutorialService;
        private readonly IFormService _formService;

        public CompleteTutorialButtonClickService(
            ITutorialService tutorialService,
            IFormService formService)
        {
            _tutorialService = tutorialService ?? throw new ArgumentNullException(nameof(tutorialService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public void Enable()
        {
        }

        public void Disable()
        {
        }

        public void OnClick(UiFormButton button)
        {
            _tutorialService.Complete();
            _formService.Show(FormId.Pause);
        }
    }
}