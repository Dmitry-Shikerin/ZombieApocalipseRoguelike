using System;
using Sources.Controllers.Upgrades;
using Sources.DomainInterfaces.Upgrades;
using Sources.Infrastructure.Services.Icons;
using Sources.PresentationsInterfaces.Views.Upgrades;

namespace Sources.Infrastructure.Factories.Controllers.Upgrades
{
    public class UpgradeUiPresenterFactory
    {
        private readonly ISpriteCollectionService _spriteCollectionService;

        public UpgradeUiPresenterFactory(ISpriteCollectionService spriteCollectionService)
        {
            _spriteCollectionService = spriteCollectionService ?? 
                                       throw new ArgumentNullException(nameof(spriteCollectionService));
        }

        public UpgradeUiPresenter Create(IUpgrader upgrader,  IUpgradeUi upgradeUi)
        {
            return new UpgradeUiPresenter(upgrader, upgradeUi, _spriteCollectionService);
        }
    }
}