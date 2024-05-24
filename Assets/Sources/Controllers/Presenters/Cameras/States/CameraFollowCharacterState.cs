using System;
using Sources.Infrastructure.StateMachines.ContextStateMachines.States;
using Sources.InfrastructureInterfaces.Services.Cameras;
using Sources.Presentations.Views.Cameras.Types;
using Sources.Presentations.Views.Characters;
using Sources.PresentationsInterfaces.Views.Cameras;
using UnityEngine;

namespace Sources.Controllers.Presenters.Cameras.States
{
    public class CameraFollowCharacterState : ContextStateBase
    {
        private readonly ICinemachineCameraView _cinemachineCameraView;
        private readonly ICameraService _cameraService;
        private readonly Vector3 _cameraPosition = new Vector3(60, 45, 0);

        public CameraFollowCharacterState(
            ICinemachineCameraView cinemachineCameraView,
            ICameraService cameraService)
        {
            _cinemachineCameraView = cinemachineCameraView ?? 
                                     throw new ArgumentNullException(nameof(cinemachineCameraView));
            _cameraService = cameraService ?? throw new ArgumentNullException(nameof(cameraService));
        }

        public override void Enter(object payload = null)
        {
            Transform target = _cameraService.Get(FollowableId.Character).Transform;
            _cinemachineCameraView.Follow(target);
            _cinemachineCameraView.SetRotation(_cameraPosition);
        }
    }
}