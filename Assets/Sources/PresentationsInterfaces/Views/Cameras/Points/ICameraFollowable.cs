using Sources.InfrastructureInterfaces.StateMachines.ContextStateMachines.Contexts;
using Sources.Presentations.Views.Cameras.Types;
using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.Cameras.Points
{
    public interface ICameraFollowable : IContext
    {
        FollowableId Id { get; }

        Transform Transform { get; }
    }
}