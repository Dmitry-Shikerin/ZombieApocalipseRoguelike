using System;
using Sirenix.OdinInspector;
using Sources.Infrastructure.Services.ObjectPools;
using Sources.InfrastructureInterfaces.Services.ObjectPools;
using Sources.Presentations.Triggers;
using Sources.PresentationsInterfaces.Views.Bullets;
using Sources.PresentationsInterfaces.Views.Enemies;
using Sources.PresentationsInterfaces.Views.ObjectPools;
using Sources.PresentationsInterfaces.Views.Weapons;
using UnityEngine;

namespace Sources.Presentations.Views.Bullets
{
    public class BulletView : View, IBulletView
    {
        [Required] [SerializeField] private EnemyHealthParticleCollision _enemyHealthParticleCollision;

        private IPoolableObjectDestroyerService _poolableObjectDestroyerService = 
            new PoolableObjectDestroyerService();
        
        private IMiniGunView _miniGunView;

        private void OnEnable() =>
            _enemyHealthParticleCollision.Entered += OnEntered;

        private void OnDisable() =>
            _enemyHealthParticleCollision.Entered -= OnEntered;

        private void OnParticleSystemStopped()
        {
            if (TryGetComponent(out PoolableObject poolableObject) == false)
            {
                Destroy(gameObject);
                
                return;
            }
            
            poolableObject.ReturnToPool();
            
            Hide();
            _poolableObjectDestroyerService.Destroy(this);
        }
        
        public void Construct(IMiniGunView playerWallet) =>
            _miniGunView = playerWallet ?? throw new ArgumentNullException(nameof(playerWallet));

        private void OnEntered(IEnemyHealthView enemyHealthView) =>
            _miniGunView.DealDamage(enemyHealthView);
    }
}