using System;
using Sources.Domain.Data;
using Sources.Domain.Upgrades;
using Sources.DomainInterfaces.Data;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;

namespace Sources.Infrastructure.Factories.Domain.Data
{
    public class SawLauncherUpgradeDtoFactory : IDtoFactory<SawLauncherUpgradeDto>
    {
        public SawLauncherUpgradeDto Create(IDataModel dataModel)
        {
            if(dataModel is not Upgrader upgrader)
                throw new ArgumentException("dataModel is not Upgrader");

            return new SawLauncherUpgradeDto()
            {
                MaxLevel = upgrader.MaxLevel,
                CurrentLevel = upgrader.CurrentLevel,
                AddedAmount = upgrader.AddedAmount
            };
        }
    }
}