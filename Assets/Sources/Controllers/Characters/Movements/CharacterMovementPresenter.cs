using Sources.ControllersInterfaces;
using Sources.Infrastructure.StateMachines.ContextStateMachines;
using Sources.InfrastructureInterfaces.StateMachines.ContextStateMachines.States;

namespace Sources.Controllers.Characters.Movements
{
    public class CharacterMovementPresenter : ContextStateMachine, IPresenter
    {
        public CharacterMovementPresenter(
            IContextState firstState) 
            : base(firstState)
        {
        }

        public void Enable()
        {
        }

        public void Disable()
        {
        }
    }
}