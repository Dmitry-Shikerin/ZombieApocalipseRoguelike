using System;
using Sources.Frameworks.UiFramework.Domain.Commands;
using Sources.Frameworks.UiFramework.InfrastructureInterfaces.Commands.Views;
using Sources.InfrastructureInterfaces.Services.Cameras;
using Sources.Presentations.Views.Cameras.Types;

namespace Sources.Frameworks.UiFramework.Infrastructure.Commands.Forms
{
    public class SetAllMapCameraFollowViewCommand : IViewCommand
    {
        private readonly ICameraService _cameraService;

        public SetAllMapCameraFollowViewCommand(ICameraService cameraService)
        {
            _cameraService = cameraService ?? throw new ArgumentNullException(nameof(cameraService));
        }

        public FormCommandId Id => FormCommandId.SetAllMapCameraFollow;
        
        public void Handle() =>
            _cameraService.SetFollower(FollowableId.AllMap);
    }
}