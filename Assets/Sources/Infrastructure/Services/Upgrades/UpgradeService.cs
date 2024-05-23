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
        public int GetUpgradesCount(int availableUpgradesCount, IReadOnlyList<Upgrader> upgraders)
        {
            if (availableUpgradesCount >= 3)
                return 3;
            
            //if (availableUpgradesCount is < 3 and > 0)
                //return availableUpgradesCount;

            var count = upgraders.Count(upgrader => upgrader.CurrentLevel == 3);

            if (count >= 4 && availableUpgradesCount > 0)
                return availableUpgradesCount;

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