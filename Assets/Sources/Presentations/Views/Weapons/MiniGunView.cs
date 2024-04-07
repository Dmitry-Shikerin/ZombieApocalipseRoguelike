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
        
        public IBulletSpawnPoint BulletSpawnPoint => _miniGunBulletSpawnPoint;

        public void DealDamage(IEnemyHealthView enemyHealthView)
        {
            Presenter.DealDamage(enemyHealthView);
        }
    }
}