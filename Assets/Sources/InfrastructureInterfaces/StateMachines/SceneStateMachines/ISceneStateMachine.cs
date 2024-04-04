using Sources.ControllersInterfaces.ControllerLifetimes;
using Sources.InfrastructureInterfaces.Services.Updates;
using Sources.InfrastructureInterfaces.StateMachines.States;

namespace Sources.InfrastructureInterfaces.StateMachines.SceneStateMachines
{
    public interface ISceneStateMachine : IUpdatable, ILateUpdatable, IFixedUpdatable, IExitable
    {
        void ChangeState(IState state, object payload = null);
    }
}