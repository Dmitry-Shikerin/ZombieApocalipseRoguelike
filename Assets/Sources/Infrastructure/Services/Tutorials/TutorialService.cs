using System;
using Sources.Domain.Models.Data.Ids;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Setting;
using Sources.Frameworks.UiFramework.Presentation.Views.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.Tutorials;

namespace Sources.Infrastructure.Services.Tutorials
{
    public class TutorialService : ITutorialService
    {
        private readonly IFormService _formService;
        private readonly ILoadService _loadService;
        private Tutorial _tutorial;
        private SavedLevel _savedLevel;

        public TutorialService(
            IFormService formService,
            ILoadService loadService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }

        public void Enable()
        {
            if (_tutorial.HasCompleted)
                return;

            if (_savedLevel.SavedLevelId != ModelId.Gameplay)
                return;

            _formService.Show(FormId.GreetingTutorial);
        }

        public void Construct(Tutorial tutorial, SavedLevel savedLevel)
        {
            _tutorial = tutorial ?? throw new ArgumentNullException(nameof(tutorial));
            _savedLevel = savedLevel ?? throw new ArgumentNullException(nameof(savedLevel));
        }

        public void Complete()
        {
            _tutorial.HasCompleted = true;
            _loadService.Save(_tutorial);
        }
    }
}