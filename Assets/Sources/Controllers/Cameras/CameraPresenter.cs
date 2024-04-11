using System;
using JetBrains.Annotations;
using Sources.ControllersInterfaces;
using Sources.Infrastructure.StateMachines.FiniteStateMachines;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.InfrastructureInterfaces.Services.UpdateServices;

namespace Sources.Controllers.Cameras
{
    public class CameraPresenter : FiniteStateMachine, IPresenter
    {
        private readonly FiniteState _firstState;
        private readonly IUpdateRegister _updateRegister;

        public CameraPresenter(FiniteState firstState, IUpdateRegister updateRegister)
        {
            _firstState = firstState ?? throw new ArgumentNullException(nameof(firstState));
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
        }

        public void Enable()
        {
            Start(_firstState);
            _updateRegister.UpdateChanged += Update;
        }

        public void Disable()
        {
            _updateRegister.UpdateChanged -= Update;
            Stop();
        }
    }
}