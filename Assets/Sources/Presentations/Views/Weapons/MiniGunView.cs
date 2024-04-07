using Sirenix.OdinInspector;
using Sources.Controllers.Weapons;
using Sources.PresentationsInterfaces.Views.Bullets;
using Sources.PresentationsInterfaces.Views.Enemies;
using Sources.PresentationsInterfaces.Views.Weapons;
using UnityEngine;

namespace Sources.Presentations.Views.Weapons
{
    public class MiniGunView : PresentableView<MiniGunPresenter>, IMiniGunView
    {
        [Required] [SerializeField] private MiniGunBulletSpawnPoint _miniGunBulletSpawnPoint;
        [Required] [SerializeField] private ParticleSystem _bulletParticleSystem;
        [Required] [SerializeField] private ParticleSystem _fireParticleSystem;
         
        public IBulletSpawnPoint BulletSpawnPoint => _miniGunBulletSpawnPoint;

        public void DealDamage(IEnemyHealthView enemyHealthView) =>
            Presenter.DealDamage(enemyHealthView);

        public void PlayFireParticles()
        {
            _bulletParticleSystem.Play();
            _fireParticleSystem.Play();
        }
        
        public void StopFireParticles()
        {
            _bulletParticleSystem.Stop();
            _fireParticleSystem.Stop();
        }
    }
}