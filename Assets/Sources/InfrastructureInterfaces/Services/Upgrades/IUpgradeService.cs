using System.Collections.Generic;
using Sources.Domain.Models.Upgrades;
using Sources.DomainInterfaces.Models.Players;
using Sources.Utils.CustomCollections;

namespace Sources.InfrastructureInterfaces.Services.Upgrades
{
    public interface IUpgradeService
    {
        int GetUpgradesCount(int availableUpgradesCount, IReadOnlyList<Upgrader> upgraders);

        IReadOnlyList<Upgrader> GetAvailableUpgrades(
            IPlayerWallet playerWallet,
            ICustomCollection<Upgrader> upgradeCollection);
    }
}