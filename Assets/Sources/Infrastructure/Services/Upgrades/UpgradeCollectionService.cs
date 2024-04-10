using System.Collections.Generic;
using Sources.Domain.Upgrades;

namespace Sources.Infrastructure.Services.Upgrades
{
    public class UpgradeCollectionService : IUpgradeCollectionService
    {
        private readonly List<Upgrader> _upgraders = new List<Upgrader>();
        
        public void AddUpgrader(Upgrader upgrader) =>
            _upgraders.Add(upgrader);

        public IReadOnlyList<Upgrader> GetUpgraders() =>
            _upgraders;
    }
}