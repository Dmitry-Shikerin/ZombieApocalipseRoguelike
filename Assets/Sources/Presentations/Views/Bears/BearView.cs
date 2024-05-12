using Sirenix.OdinInspector;
using Sources.Controllers.Bears;
using Sources.Controllers.Presenters.Bears.Movements;
using Sources.Presentations.Views.NavMeshAgents;
using Sources.PresentationsInterfaces.Views.Bears;
using Sources.PresentationsInterfaces.Views.Character;
using Sources.PresentationsInterfaces.Views.Enemies;
using UnityEngine;
using UnityEngine.AI;

namespace Sources.Presentations.Views.Bears
{
    public class BearView : NavMeshAgentBase<BearPresenter>, IBearView
    {
        [Required] [SerializeField] private BearAnimationView _bearAnimationView;

        public BearAnimationView BearAnimationView => _bearAnimationView;
        public IEnemyHealthView TargetEnemyHealth { get; private set; }
        public ICharacterMovementView CharacterMovementView { get; private set; }
        
        public void SetTarget(IEnemyHealthView enemyHealthView) =>
            TargetEnemyHealth = enemyHealthView;

        public void SetTargetFollow(ICharacterMovementView characterMovementView) =>
            CharacterMovementView = characterMovementView;
        
        public void SetLookRotation(float angle)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, Quaternion.Euler(0, angle, 0), 4f);
        }
    }
}