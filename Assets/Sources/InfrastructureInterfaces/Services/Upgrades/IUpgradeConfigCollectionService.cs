using Sources.Domain.Models.Upgrades.Configs;

namespace Sources.InfrastructureInterfaces.Services.Upgrades
{
    public interface IUpgradeConfigCollectionService
    {
        UpgradeConfig GetConfig(string id);
    }
}