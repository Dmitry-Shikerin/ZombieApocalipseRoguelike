using Sirenix.OdinInspector;
using Sources.Controllers.Enemies;
using Sources.PresentationsInterfaces.Views.Enemies;
using UnityEngine;
using UnityEngine.AI;

namespace Sources.Presentations.Views.Enemies
{
    public class EnemyView : PresentableView<EnemyPresenter>, IEnemyView
    {
        [Required] [SerializeField] private NavMeshAgent _navMeshAgent;
        [Required] [SerializeField] private EnemyHealthView _healthView;
        
        public EnemyHealthView EnemyHealthView => _healthView;
        
        public void Move(Vector3 direction) =>
            _navMeshAgent.SetDestination(direction);
    }
}