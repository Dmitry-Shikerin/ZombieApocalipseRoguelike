using Sirenix.OdinInspector;
using Sources.Controllers.Enemies;
using Sources.Controllers.Enemies.Base;
using Sources.Presentations.Triggers;
using Sources.Presentations.Views.Common;
using Sources.PresentationsInterfaces.Views.Character;
using Sources.PresentationsInterfaces.Views.Enemies.Bosses;
using Sources.PresentationsInterfaces.Views.ObjectPools;
using UnityEngine;
using UnityEngine.AI;

namespace Sources.Presentations.Views.Enemies.Bosses
{
    public class BossEnemyView : PresentableView<EnemyPresenter>, IBossEnemyView
    {
        [Required] [SerializeField] private NavMeshAgent _navMeshAgent;
        [Required] [SerializeField] private EnemyHealthView _healthView;
        [Required] [SerializeField] private HealthUi _healthUi;
        [Required] [SerializeField] private BossEnemyAnimation _enemyAnimation;
        [Required] [SerializeField] private ParticleSystem _massAttackParticle;
        [Required] [SerializeField] private CharacterHealthParticleCollision _characterHealthParticleCollision;
        
        public EnemyHealthView EnemyHealthView => _healthView;
        public HealthUi HealthUi => _healthUi;
        public BossEnemyAnimation EnemyAnimation => _enemyAnimation;
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

        public void PlayMassAttackParticle() =>
            _massAttackParticle.Play();

        public void SetAgentSpeed(float speed) =>
            _navMeshAgent.speed = speed;

        protected override void OnAfterEnable()
        {
            _characterHealthParticleCollision.Entered += OnEntered;
        }

        protected override void OnAfterDisable()
        {
            _characterHealthParticleCollision.Entered += OnEntered;
        }

        private void OnEntered(ICharacterHealthView characterHealthView)
        {
            Debug.Log("particleCollision DealDamege 10");
            characterHealthView.TakeDamage(10);
        }
    }
}