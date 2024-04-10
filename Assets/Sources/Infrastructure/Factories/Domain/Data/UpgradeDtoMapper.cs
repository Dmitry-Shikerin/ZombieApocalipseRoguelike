using System;
using Sources.Domain.Data;
using Sources.Domain.Data.Common;
using Sources.Domain.Upgrades;
using Sources.DomainInterfaces.Data;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;

namespace Sources.Infrastructure.Factories.Domain.Data
{
    public class UpgradeDtoMapper : IDtoMapper<UpgradeDto, Upgrader>
    {
        public UpgradeDto MapTo(Upgrader upgrader)
        {
            return new UpgradeDto()
            {
                    MaxLevel = upgrader.MaxLevel,
                    CurrentLevel = upgrader.CurrentLevel,
                    AddedAmount = upgrader.AddedAmount,
                    Id = upgrader.Id,
            };
        }
    }
}