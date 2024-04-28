using Sirenix.OdinInspector;
using Sources.Controllers.Enemies.Base;
using Sources.Presentations.Views.Common;
using Sources.PresentationsInterfaces.Views.Character;
using Sources.PresentationsInterfaces.Views.Enemies.Base;
using Sources.PresentationsInterfaces.Views.ObjectPools;
using UnityEngine;
using UnityEngine.AI;

namespace Sources.Presentations.Views.Enemies.Base
{
    public class EnemyView : PresentableView<EnemyPresenter>, IEnemyView
    {
        [Required] [SerializeField] private NavMeshAgent _navMeshAgent;
        [Required] [SerializeField] private EnemyHealthView _healthView;
        [Required] [SerializeField] private HealthUi _healthUi;
        [Required] [SerializeField] private EnemyAnimation _enemyAnimation;
        [Required] [SerializeField] private HealthUiText _healthUiText;

        public EnemyHealthView EnemyHealthView => _healthView;
        public HealthUi HealthUi => _healthUi;
        public EnemyAnimation EnemyAnimation => _enemyAnimation;
        public HealthUiText HealthUiText => _healthUiText;
        public float StoppingDistance => _navMeshAgent.stoppingDistance;
        public Vector3 Position => transform.position;
        public ICharacterMovementView CharacterMovementView { get; private set; }
        public ICharacterHealthView CharacterHealthView { get; private set; }

        public override void Destroy()
        {
            if (TryGetComponent(out PoolableObject poolableObject) == false)
            {
                Destroy(gameObject);

                return;
            }

            poolableObject.ReturnToPool();
            DestroyPresenter();
            Hide();
        }

        public void Move(Vector3 direction) =>
            _navMeshAgent.SetDestination(direction);

        public void SetTargetFollow(ICharacterMovementView target) =>
            CharacterMovementView = target;

        public void SetCharacterHealth(ICharacterHealthView characterHealthView) =>
            CharacterHealthView = characterHealthView;

        public void EnableNavmeshAgent() =>
            _navMeshAgent.enabled = true;

        public void DisableNavmeshAgent() =>
            _navMeshAgent.enabled = false;
    }
}