using System;
using Sources.ControllersInterfaces;
using Sources.Infrastructure.StateMachines.ContextStateMachines;
using Sources.InfrastructureInterfaces.Services.Cameras;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.InfrastructureInterfaces.StateMachines.ContextStateMachines.States;

namespace Sources.Controllers.Presenters.Cameras
{
    public class CameraPresenter : ContextStateMachine, IPresenter
    {
        private readonly IContextState _firstState;
        private readonly IUpdateRegister _updateRegister;
        private readonly ICameraService _cameraService;

        public CameraPresenter(
            IContextState firstState, 
            IUpdateRegister updateRegister, 
            ICameraService cameraService) 
            : base(firstState)
        {
            _firstState = firstState ?? throw new ArgumentNullException(nameof(firstState));
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
            _cameraService = cameraService ?? throw new ArgumentNullException(nameof(cameraService));
        }

        public void Enable()
        {
            Run();
            _updateRegister.UpdateChanged += Update;
            _cameraService.FollowableChanged += OnFollowableChanged;
        }

        public void Disable()
        {
            _updateRegister.UpdateChanged -= Update;
            _cameraService.FollowableChanged -= OnFollowableChanged;
            Stop();
        }

        private void OnFollowableChanged() =>
            Apply(_cameraService.CurrentFollower);
    }
}