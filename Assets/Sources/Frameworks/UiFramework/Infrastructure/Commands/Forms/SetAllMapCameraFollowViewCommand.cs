using System;
using Sources.Frameworks.UiFramework.Domain.Commands;
using Sources.Frameworks.UiFramework.InfrastructureInterfaces.Commands;
using Sources.InfrastructureInterfaces.Services.Cameras;
using Sources.Presentations.Views.Cameras.Points;

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
        
        //TODO чепуха при смене точек в туториале
        public void Handle()
        {
            _cameraService.SetFollower<AllMapPoint>();
        }
    }
}