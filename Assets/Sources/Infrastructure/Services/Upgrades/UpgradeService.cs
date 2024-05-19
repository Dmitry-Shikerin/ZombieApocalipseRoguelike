using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Domain.Models.Upgrades;
using Sources.DomainInterfaces.Players;
using Sources.InfrastructureInterfaces.Services.Upgrades;
using Sources.Utils.CustomCollections;

namespace Sources.Infrastructure.Services.Upgrades
{
    public class UpgradeService : IUpgradeService
    {
        public int GetUpgradesCount(IReadOnlyList<Upgrader> availableUpgrades)
        {
            if (availableUpgrades.Count >= 3)
                return 3;
            
            if (availableUpgrades.Count is < 3 and > 0)
                return availableUpgrades.Count;

            throw new IndexOutOfRangeException();
        }
        
        public IReadOnlyList<Upgrader> GetAvailableUpgrades(
            IPlayerWallet playerWallet, 
            ICustomCollection<Upgrader> upgradeCollection)
        {
            List<Upgrader> availableUpgraders = new List<Upgrader>();

            foreach (Upgrader upgrader in upgradeCollection)
            {
                if(upgrader.CurrentLevel == 3)
                    continue;
                
                if(upgrader.MoneyPerUpgrades[upgrader.CurrentLevel] <= playerWallet.Coins)
                    availableUpgraders.Add(upgrader);
            }

            return availableUpgraders.OrderBy(upgrade => upgrade.CurrentLevel).ToList();
        }
    }
}