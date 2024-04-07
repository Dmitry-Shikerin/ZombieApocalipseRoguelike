using Sources.Presentations.Views.Weapons;
using Sources.PresentationsInterfaces.Views.Enemies;

namespace Sources.PresentationsInterfaces.Views.Weapons
{
    public interface IMiniGunView
    {
        MiniGunBulletSpawnPoint MiniGunBulletSpawnPoint { get; }
        
        void DealDamage(IEnemyHealthView enemyHealthView);
    }
}