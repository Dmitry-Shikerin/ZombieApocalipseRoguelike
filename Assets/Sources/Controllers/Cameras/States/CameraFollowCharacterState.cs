﻿using System;
using Sources.Infrastructure.StateMachines.ContextStateMachines.States;
using Sources.InfrastructureInterfaces.Services.Cameras;
using Sources.Presentations.Views.Characters;
using Sources.PresentationsInterfaces.Views.Cameras;
using UnityEngine;

namespace Sources.Controllers.Cameras.States
{
    public class CameraFollowCharacterState : ContextStateBase
    {
        private readonly ICinemachineCameraView _cinemachineCameraView;
        private readonly ICameraService _cameraService;

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
            Transform target = _cameraService.Get<CharacterView>().Transform;
            _cinemachineCameraView.Follow(target);
            
            _cinemachineCameraView.SetRotation(new Vector3(60, 45, 0));
        }

        public override void Exit()
        {
        }

        public override void Update(float deltaTime)
        {
        }
    }
}