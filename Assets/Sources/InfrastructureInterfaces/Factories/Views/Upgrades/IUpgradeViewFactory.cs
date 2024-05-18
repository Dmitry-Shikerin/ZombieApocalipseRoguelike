using Sources.Domain.Models.Players;
using Sources.Domain.Models.Upgrades;
using Sources.Presentations.Views.Upgrades;
using Sources.PresentationsInterfaces.Views.Upgrades;

namespace Sources.InfrastructureInterfaces.Factories.Views.Upgrades
{
    public interface IUpgradeViewFactory
    {
        IUpgradeView Create(Upgrader upgrader, PlayerWallet playerWallet, UpgradeView upgradeView);
    }
}