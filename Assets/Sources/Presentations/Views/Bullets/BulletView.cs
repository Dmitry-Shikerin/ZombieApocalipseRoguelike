using System;
using Sirenix.OdinInspector;
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
        }
        
        public void SetRotation(Vector3 rotation) =>
            transform.rotation = Quaternion.Euler(rotation);
        public void SetRotation(Quaternion rotation) =>
            transform.rotation = rotation;

        public void Construct(IMiniGunView miniGunView) =>
            _miniGunView = miniGunView ?? throw new ArgumentNullException(nameof(miniGunView));

        private void OnEntered(IEnemyHealthView enemyHealthView) =>
            _miniGunView.DealDamage(enemyHealthView);
    }
}