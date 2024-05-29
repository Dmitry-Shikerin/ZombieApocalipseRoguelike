using Sirenix.OdinInspector;
using Sources.ControllersInterfaces.Presenters;
using Sources.PresentationsInterfaces.Views.NawMeshAgents;
using UnityEngine;
using UnityEngine.AI;

namespace Sources.Presentations.Views.NavMeshAgents
{
    public abstract class NavMeshAgentBase<T> : PresentableView<T>, INavMeshAgent
        where T : IPresenter
    {
        [Required] [SerializeField] private NavMeshAgent _navMeshAgent;

        public Vector3 Position => transform.position;

        public float StoppingDistance => _navMeshAgent.stoppingDistance;

        protected NavMeshAgent NavMeshAgent => _navMeshAgent;

        public void Move(Vector3 position) =>
            _navMeshAgent.SetDestination(position);

        public void SetStoppingDistance(float stoppingDistance) =>
            _navMeshAgent.stoppingDistance = stoppingDistance;
    }
}