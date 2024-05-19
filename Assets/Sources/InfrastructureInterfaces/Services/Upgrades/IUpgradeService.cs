using System.Collections.Generic;
using Sources.Domain.Models.Upgrades;
using Sources.DomainInterfaces.Players;
using Sources.Utils.CustomCollections;

namespace Sources.InfrastructureInterfaces.Services.Upgrades
{
    public interface IUpgradeService
    {
        int GetUpgradesCount(IReadOnlyList<Upgrader> availableUpgrades);

        IReadOnlyList<Upgrader> GetAvailableUpgrades(
            IPlayerWallet playerWallet,
            ICustomCollection<Upgrader> upgradeCollection);
    }
}