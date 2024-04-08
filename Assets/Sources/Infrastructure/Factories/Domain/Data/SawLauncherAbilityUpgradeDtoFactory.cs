using System;
using Sources.Domain.Data;
using Sources.Domain.Upgrades;
using Sources.DomainInterfaces.Data;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;

namespace Sources.Infrastructure.Factories.Domain.Data
{
    public class SawLauncherAbilityUpgradeDtoFactory : IDtoFactory<SawLauncherAbilityUpgradeDto>
    {
        public SawLauncherAbilityUpgradeDto Create(IDataModel dataModel)
        {
            if (dataModel is not Upgrader upgrader)
                throw new InvalidOperationException(nameof(dataModel));
            
            return new SawLauncherAbilityUpgradeDto()
            {
                    MaxLevel = upgrader.MaxLevel,
                    CurrentLevel = upgrader.CurrentLevel,
                    AddedAmount = upgrader.AddedAmount
            };
        }
    }
}