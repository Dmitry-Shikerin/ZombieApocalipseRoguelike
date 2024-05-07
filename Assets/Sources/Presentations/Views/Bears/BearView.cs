using Sirenix.OdinInspector;
using Sources.Controllers.Bears;
using Sources.Controllers.Presenters.Bears.Movements;
using Sources.PresentationsInterfaces.Views.Bears;
using Sources.PresentationsInterfaces.Views.Character;
using Sources.PresentationsInterfaces.Views.Enemies;
using UnityEngine;
using UnityEngine.AI;

namespace Sources.Presentations.Views.Bears
{
    public class BearView : PresentableView<BearPresenter>, IBearView
    {
        [Required] [SerializeField] private NavMeshAgent _navMeshAgent;
        [Required] [SerializeField] private BearAnimationView _bearAnimationView;

        public BearAnimationView BearAnimationView => _bearAnimationView;
        public Vector3 Position => transform.position;
        public Vector3 Forward => transform.forward;
        public float StoppingDistance => _navMeshAgent.stoppingDistance;
        public IEnemyHealthView TargetEnemyHealth { get; private set; }
        public ICharacterMovementView CharacterMovementView { get; private set; }

        public void Move(Vector3 position) =>
            _navMeshAgent.SetDestination(position);

        public void SetTarget(IEnemyHealthView enemyHealthView) =>
            TargetEnemyHealth = enemyHealthView;

        public void SetTargetFollow(ICharacterMovementView characterMovementView) =>
            CharacterMovementView = characterMovementView;

        public void SetStoppingDistance(float stoppingDistance) =>
            _navMeshAgent.stoppingDistance = stoppingDistance;

        public void SetLookRotation(float angle) =>
            transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}