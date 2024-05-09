using System;
using Sources.Frameworks.UiFramework.Domain.Commands;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.InfrastructureInterfaces.Services.Tutorials;

namespace Sources.Frameworks.UiFramework.Infrastructure.Commands.Buttons
{
    public class CompleteTutorialCommand : IButtonCommand
    {
        private readonly ITutorialService _tutorialService;

        public CompleteTutorialCommand(ITutorialService tutorialService)
        {
            _tutorialService = tutorialService ?? throw new ArgumentNullException(nameof(tutorialService));
        }

        public ButtonCommandId Id => ButtonCommandId.CompleteTutorial;
        
        public void Handle(UiButton uiButton)
        {
            _tutorialService.Complete();
        }
    }
}