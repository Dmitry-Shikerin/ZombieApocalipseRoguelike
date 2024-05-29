using Sources.Presentations.Views.Bullets;
using Sources.PresentationsInterfaces.Views.Bullets;
using Sources.PresentationsInterfaces.Views.Weapons;

namespace Sources.InfrastructureInterfaces.Factories.Views.Bullets
{
    public interface IBulletViewFactory
    {
        IBulletView Create(IMiniGunView miniGunView);

        IBulletView Create(BulletView bulletView, IMiniGunView miniGunView);
    }
}