using Sources.PresentationsInterfaces.Views.Bullets;
using Sources.PresentationsInterfaces.Views.Weapons;

namespace Sources.InfrastructureInterfaces.Services.Spawners
{
    public interface IBulletSpawnService
    {
        IBulletView Spawn(IMiniGunView miniGunView);
    }
}