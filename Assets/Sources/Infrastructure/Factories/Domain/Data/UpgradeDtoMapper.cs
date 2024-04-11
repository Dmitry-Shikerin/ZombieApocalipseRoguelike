using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Domain.Data.Common;
using Sources.Domain.Upgrades;
using Sources.Domain.Upgrades.Configs;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;
using Sources.InfrastructureInterfaces.Services.Upgrades;

namespace Sources.Infrastructure.Factories.Domain.Data
{
    public class UpgradeDtoMapper : IUpgradeDtoMapper
    {
        private readonly IUpgradeConfigCollectionService _upgradeConfigCollectionService;

        public UpgradeDtoMapper(IUpgradeConfigCollectionService upgradeConfigCollectionService)
        {
            _upgradeConfigCollectionService = 
                upgradeConfigCollectionService ?? 
                throw new ArgumentNullException(nameof(upgradeConfigCollectionService));
        }

        public UpgradeDto MapModelToDto(Upgrader upgrader)
        {
            return new UpgradeDto()
            {
                MaxLevel = upgrader.MaxLevel,
                CurrentLevel = upgrader.CurrentLevel,
                AddedAmount = upgrader.AddedAmount,
                Id = upgrader.Id,
            };
        }

        public UpgradeDto MapIdToDto(string id)
        {
            UpgradeConfig upgradeConfig = _upgradeConfigCollectionService.GetConfig(id);
            
            MoneyPerUpgradeDto[] moneyPerUpgrades =
                upgradeConfig.MoneyPerUpgrades
                    .Select(money => new MoneyPerUpgradeDto() { MoneyPerUpgrade = money, })
                    .ToArray();

            return new UpgradeDto()
            {
                MaxLevel = upgradeConfig.MaxLevel,
                CurrentLevel = upgradeConfig.CurrentLevel,
                StartAmount = upgradeConfig.StartAmount,
                AddedAmount = upgradeConfig.AddedAmount,
                MoneyPerUpgrades = moneyPerUpgrades,
                Id = upgradeConfig.Id,
            };
        }

        public Upgrader MapDtoToModel(UpgradeDto upgradeDto)
        {
            List<int> moneyPerUpgrades = upgradeDto.MoneyPerUpgrades
                .Select(money => money.MoneyPerUpgrade)
                .ToList();

            return new Upgrader(
                upgradeDto.StartAmount,
                upgradeDto.CurrentLevel,
                upgradeDto.AddedAmount,
                moneyPerUpgrades,
                upgradeDto.Id);
        }
    }
}