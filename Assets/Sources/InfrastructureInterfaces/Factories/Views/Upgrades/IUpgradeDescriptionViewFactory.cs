using Sources.DomainInterfaces.Upgrades;
using Sources.Presentations.Views.Upgrades;
using Sources.PresentationsInterfaces.Views.Upgrades;

namespace Sources.InfrastructureInterfaces.Factories.Views.Upgrades
{
    public interface IUpgradeDescriptionViewFactory
    {
        IUpgradeDescriptionView Create(IUpgrader upgrader, UpgradeDescriptionView view);
    }
}