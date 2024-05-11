using System;
using Sources.Frameworks.UiFramework.Domain.Commands;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.InfrastructureInterfaces.Services.Cameras;
using Sources.Presentations.Views.Cameras.Points;

namespace Sources.Frameworks.UiFramework.Infrastructure.Commands.Buttons
{
    public class SetAllMapCameraFollowCommand : IButtonCommand
    {
        private readonly ICameraService _cameraService;

        public SetAllMapCameraFollowCommand(ICameraService cameraService)
        {
            _cameraService = cameraService ?? throw new ArgumentNullException(nameof(cameraService));
        }

        public ButtonCommandId Id => ButtonCommandId.SetAllMapCameraFollow;
        
        public void Handle(UiButton uiButton)
        {
            _cameraService.SetFollower<AllMapPoint>();
        }
    }
}