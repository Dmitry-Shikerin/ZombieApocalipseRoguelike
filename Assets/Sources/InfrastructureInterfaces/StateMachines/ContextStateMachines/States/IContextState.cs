using Sources.ControllersInterfaces.ControllerLifetimes;
using Sources.InfrastructureInterfaces.Services.Updates;
using Sources.InfrastructureInterfaces.StateMachines.ContextStateMachines.Contexts;

namespace Sources.InfrastructureInterfaces.StateMachines.ContextStateMachines.States
{
    public interface IContextState : IEnterable, IExitable, IUpdatable
    {
    void Apply(IContext context, IContextStateChanger contextStateChanger);
    }
}