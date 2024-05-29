using System;
using Sources.Frameworks.UiFramework.Domain.Commands;
using Sources.Frameworks.UiFramework.InfrastructureInterfaces.Commands.Buttons;
using Sources.Frameworks.UiFramework.PresentationsInterfaces.Buttons;
using Sources.InfrastructureInterfaces.Services.Cameras;
using Sources.Presentations.Views.Cameras.Types;

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

        public void Handle(IUiButton uiButton) =>
            _cameraService.SetFollower(FollowableId.AllMap);
    }
}