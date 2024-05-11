using System;
using Sources.Frameworks.UiFramework.Domain.Commands;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.InfrastructureInterfaces.Services.Cameras;
using Sources.Presentations.Views.Characters;

namespace Sources.Frameworks.UiFramework.Infrastructure.Commands.Buttons
{
    public class SetCharacterCameraFollowCommand : IButtonCommand
    {
        private readonly ICameraService _cameraService;

        public SetCharacterCameraFollowCommand(ICameraService cameraService)
        {
            _cameraService = cameraService ?? throw new ArgumentNullException(nameof(cameraService));
        }

        public ButtonCommandId Id => ButtonCommandId.SetCharacterCameraFollow;
        
        public void Handle(UiButton uiButton)
        {
            _cameraService.SetFollower<CharacterView>();
        }
    }
}