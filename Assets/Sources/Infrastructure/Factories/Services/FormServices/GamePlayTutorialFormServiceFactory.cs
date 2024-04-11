using System;
using Sources.InfrastructureInterfaces.Services.Forms;

namespace Sources.Infrastructure.Factories.Services.FormServices
{
    public class GamePlayTutorialFormServiceFactory
    {
        private readonly ITutorialFormService _tutorialFormService;

        public GamePlayTutorialFormServiceFactory(
            ITutorialFormService tutorialFormService)
        {
            _tutorialFormService = tutorialFormService ?? 
                                   throw new ArgumentNullException(nameof(tutorialFormService));
        }

        public ITutorialFormService Create()
        {
            return _tutorialFormService;
        }
    }
}