using Sources.ControllersInterfaces.ControllerLifetimes;
using Sources.Domain.Characters;

namespace Sources.InfrastructureInterfaces.Services.GameOvers
{
    public interface IGameOverService : IEnterable, IExitable
    {
        void Register(CharacterHealth characterHealth);
    }
}