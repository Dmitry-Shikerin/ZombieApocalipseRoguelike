using System.Collections.Generic;
using Sources.Domain.Models.Upgrades;

namespace Sources.Infrastructure.Services.Upgrades
{
    public interface IUpgradeCollectionService
    {
        void AddUpgrader(Upgrader upgrader);
        IReadOnlyList<Upgrader> Get();
    }
}