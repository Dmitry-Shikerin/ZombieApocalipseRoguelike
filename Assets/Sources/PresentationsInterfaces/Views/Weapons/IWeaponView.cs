using Sources.PresentationsInterfaces.Views.Bullets;
using Sources.PresentationsInterfaces.Views.Enemies;

namespace Sources.PresentationsInterfaces.Views.Weapons
{
    public interface IWeaponView
    {
        IBulletSpawnPoint BulletSpawnPoint { get; }
        
        void DealDamage(IEnemyHealthView enemyHealthView);
    }
}