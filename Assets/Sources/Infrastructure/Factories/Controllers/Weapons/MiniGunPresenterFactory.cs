using Sources.Controllers.Weapons;
using Sources.Domain.Weapons;
using Sources.PresentationsInterfaces.Views.Weapons;

namespace Sources.Infrastructure.Factories.Controllers.Weapons
{
    public class MiniGunPresenterFactory
    {
        public MiniGunPresenter Create(MiniGun miniGun, IMiniGunView miniGunView)
        {
            return new MiniGunPresenter(miniGun, miniGunView);
        }
    }
}