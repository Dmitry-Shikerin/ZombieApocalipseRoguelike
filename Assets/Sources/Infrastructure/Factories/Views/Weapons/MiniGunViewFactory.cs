using System;
using Sources.Controllers.Presenters.Weapons;
using Sources.Domain.Models.Weapons;
using Sources.Infrastructure.Factories.Controllers.Presenters.Weapons;
using Sources.Presentations.Views.Weapons;
using Sources.PresentationsInterfaces.Views.Weapons;

namespace Sources.Infrastructure.Factories.Views.Weapons
{
    public class MiniGunViewFactory
    {
        private readonly MiniGunPresenterFactory _miniGunPresenterFactory;

        public MiniGunViewFactory(MiniGunPresenterFactory miniGunPresenterFactory)
        {
            _miniGunPresenterFactory = miniGunPresenterFactory ?? 
                                       throw new ArgumentNullException(nameof(miniGunPresenterFactory));
        }

        public IMiniGunView Create(MiniGun miniGun, MiniGunView miniGunView)
        {
            MiniGunPresenter miniGunPresenter = _miniGunPresenterFactory.Create(miniGun, miniGunView);
            
            miniGunView.Construct(miniGunPresenter); 
            
            return miniGunView;
        }
    }
}