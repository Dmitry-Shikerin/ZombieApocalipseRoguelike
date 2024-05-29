using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.NawMeshAgents
{
    public interface INavMeshAgent : IView
    {
        public Vector3 Position { get; }

        public float StoppingDistance { get; }

        void Move(Vector3 position);

        void SetStoppingDistance(float stoppingDistance);
    }
}