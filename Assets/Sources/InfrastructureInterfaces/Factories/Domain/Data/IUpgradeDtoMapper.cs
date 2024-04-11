using Sources.Domain.Data.Common;
using Sources.Domain.Upgrades;

namespace Sources.InfrastructureInterfaces.Factories.Domain.Data
{
    public interface IUpgradeDtoMapper
    {
        UpgradeDto MapModelToDto(Upgrader upgrader);
        UpgradeDto MapIdToDto(string id);
        Upgrader MapDtoToModel(UpgradeDto upgradeDto);
    }
}