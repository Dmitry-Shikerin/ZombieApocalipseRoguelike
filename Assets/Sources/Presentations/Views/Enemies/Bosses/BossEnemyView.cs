using Sirenix.OdinInspector;
using Sources.PresentationsInterfaces.Views.Enemies.Bosses;
using UnityEngine;

namespace Sources.Presentations.Views.Enemies.Bosses
{
    public class BossEnemyView : EnemyViewBase, IBossEnemyView
    {
        [Required] [SerializeField] private BossEnemyAnimation bossEnemyAnimation;
        [Required] [SerializeField] private ParticleSystem _massAttackParticle;
        
        public BossEnemyAnimation BossEnemyAnimation => bossEnemyAnimation;
        
        public void PlayMassAttackParticle() =>
            _massAttackParticle.Play();

        public void SetAgentSpeed(float speed) =>
            NavMeshAgent.speed = speed;
    }
}