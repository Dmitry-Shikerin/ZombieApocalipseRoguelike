using Sources.DomainInterfaces.Upgrades;
using Sources.Presentations.Views.Upgrades;
using Sources.PresentationsInterfaces.Views.Upgrades;

namespace Sources.InfrastructureInterfaces.Factories.Views.Upgrades
{
    public interface IUpgradeUiFactory
    {
        IUpgradeUi Create(IUpgrader upgrader, UpgradeUi upgradeUi);
    }
}