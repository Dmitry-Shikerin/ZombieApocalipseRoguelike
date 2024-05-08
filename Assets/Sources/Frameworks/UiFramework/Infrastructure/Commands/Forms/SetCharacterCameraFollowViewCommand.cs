using System;
using Sources.Frameworks.UiFramework.Domain.Commands;
using Sources.Frameworks.UiFramework.InfrastructureInterfaces.Commands;
using Sources.InfrastructureInterfaces.Services.Cameras;
using Sources.Presentations.Views.Characters;

namespace Sources.Frameworks.UiFramework.Infrastructure.Commands.Forms
{
    public class SetCharacterCameraFollowViewCommand : IViewCommand
    {
        private readonly ICameraService _cameraService;

        public SetCharacterCameraFollowViewCommand(ICameraService cameraService)
        {
            _cameraService = cameraService ?? throw new ArgumentNullException(nameof(cameraService));
        }

        public FormCommandId Id => FormCommandId.SetCharacterCameraFollow;
        public void Handle()
        {
            _cameraService.SetFollower<CharacterView>();
        }
    }
}