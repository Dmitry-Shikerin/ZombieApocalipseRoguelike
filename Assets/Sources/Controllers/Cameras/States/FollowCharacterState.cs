using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Presentations.Views.Cameras;

namespace Sources.Controllers.Cameras.States
{
    public class FollowCharacterState : FiniteState
    {
        public FollowCharacterState(ICinemachineCameraView cinemachineCameraView)
        {
        }
    }
}