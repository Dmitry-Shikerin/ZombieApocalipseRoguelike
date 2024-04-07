using System;
using Sirenix.OdinInspector;
using Sources.Presentations.Triggers;
using Sources.PresentationsInterfaces.Views.Bullets;
using Sources.PresentationsInterfaces.Views.Enemies;
using Sources.PresentationsInterfaces.Views.Weapons;
using UnityEngine;

namespace Sources.Presentations.Views.Bullets
{
    public class BulletView : View, IBulletView
    {
        [Required] [SerializeField] private EnemyHealthParticleCollision _enemyHealthParticleCollision;
        
        private IMiniGunView _miniGunView;

        private void OnEnable() =>
            _enemyHealthParticleCollision.Entered += OnEntered;

        private void OnDisable() =>
            _enemyHealthParticleCollision.Entered -= OnEntered;

        private void OnParticleSystemStopped()
        {
            Debug.Log($"Particle system stopped");
        }

        public void Construct(IMiniGunView miniGunView) =>
            _miniGunView = miniGunView ?? throw new ArgumentNullException(nameof(miniGunView));

        private void OnEntered(IEnemyHealthView enemyHealthView) =>
            _miniGunView.DealDamage(enemyHealthView);
    }
}