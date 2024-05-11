using System;
using Sources.Controllers.Presenters.Cameras;
using Sources.Controllers.Presenters.Cameras.States;
using Sources.Infrastructure.StateMachines.ContextStateMachines.Transitions;
using Sources.InfrastructureInterfaces.Services.Cameras;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.Presentations.Views.Cameras.Points;
using Sources.Presentations.Views.Characters;
using Sources.PresentationsInterfaces.Views.Cameras;
using Sources.PresentationsInterfaces.Views.Cameras.Points;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Cameras
{
    public class CameraPresenterFactory
    {
        private readonly IUpdateRegister _updateRegister;
        private readonly ICameraService _cameraService;

        public CameraPresenterFactory(
            IUpdateRegister updateRegister,
            ICameraService cameraService)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
            _cameraService = cameraService ?? throw new ArgumentNullException(nameof(cameraService));
        }

        //TODO почему не переключаются стейты
        public CameraPresenter Create(ICinemachineCameraView cinemachineCameraView)
        {
            CameraInitializeState initializeState = new CameraInitializeState(
                cinemachineCameraView, _cameraService);
            CameraFollowCharacterState followCharacterState = new CameraFollowCharacterState(
                cinemachineCameraView, _cameraService);
            CameraFollowAllMap followAllMapState = new CameraFollowAllMap(
                cinemachineCameraView, _cameraService);
            
            FuncContextTransition toFollowCharacterState = new FuncContextTransition(
                followCharacterState, 
                context =>
                {
                    if (context is not ICameraFollowable cameraFollowable)
                        return false;

                    if (cameraFollowable is not CharacterView characterView)
                        return false;

                    return true;
                });
            initializeState.AddTransition(toFollowCharacterState);
            followAllMapState.AddTransition(toFollowCharacterState);
            
            FuncContextTransition toFollowAllMapState = new FuncContextTransition(
                followAllMapState, 
                context =>
                {
                    if (context is not ICameraFollowable cameraFollowable)
                        return false;

                    if (cameraFollowable is not AllMapPoint allMapPoint)
                        return false;

                    return true;
                });
            initializeState.AddTransition(toFollowAllMapState);
            followCharacterState.AddTransition(toFollowAllMapState);
            
            return new CameraPresenter(
                initializeState, 
                _updateRegister,
                _cameraService);
        }
    }
}