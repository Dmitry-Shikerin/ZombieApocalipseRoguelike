using Sources.ControllersInterfaces.ControllerLifetimes;
using Sources.DomainInterfaces.Models.Characters;

namespace Sources.InfrastructureInterfaces.Services.GameOvers
{
    public interface IGameOverService : IEnterable, IExitable
    {
        void Register(ICharacterHealth characterHealth);
    }
}