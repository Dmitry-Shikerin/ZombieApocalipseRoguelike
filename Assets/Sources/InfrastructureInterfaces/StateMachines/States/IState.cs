using Sources.ControllersInterfaces.ControllerLifetimes;
using Sources.InfrastructureInterfaces.Services.Updates;

namespace Sources.InfrastructureInterfaces.StateMachines.States
{
    public interface IState : IEnterable, IExitable, IUpdatable, ILateUpdatable, IFixedUpdatable
    {
    }
}