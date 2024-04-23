using System;
using Sources.InfrastructureInterfaces.Services.Forms;

namespace Sources.Infrastructure.Factories.Services.FormServices
{
    public class GamePlayTutorialFormServiceFactory
    {
        private readonly ITutorialViewFormService _tutorialViewFormService;

        public GamePlayTutorialFormServiceFactory(
            ITutorialViewFormService tutorialViewFormService)
        {
            _tutorialViewFormService = tutorialViewFormService ?? 
                                   throw new ArgumentNullException(nameof(tutorialViewFormService));
        }

        public ITutorialViewFormService Create()
        {
            return _tutorialViewFormService;
        }
    }
}