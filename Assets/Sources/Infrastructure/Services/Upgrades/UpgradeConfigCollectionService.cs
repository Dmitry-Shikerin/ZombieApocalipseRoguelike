using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Domain.Models.Upgrades.Configs;
using Sources.Domain.Models.Upgrades.Configs.Containers;
using Sources.InfrastructureInterfaces.Services.Upgrades;

namespace Sources.Infrastructure.Services.Upgrades
{
    public class UpgradeConfigCollectionService : IUpgradeConfigCollectionService
    {
        private readonly Dictionary<string, UpgradeConfig> _upgradeConfigs;
        
        public UpgradeConfigCollectionService(UpgradeConfigContainer upgradeConfigCollection)
        {
            if(upgradeConfigCollection == null)
                throw new ArgumentNullException(nameof(upgradeConfigCollection));

            _upgradeConfigs = upgradeConfigCollection.UpgradeConfigs.ToDictionary(key => key.Id);
        }

        public UpgradeConfig GetConfig(string id)
        {
            if (_upgradeConfigs.ContainsKey(id) == false)
                throw new NullReferenceException(nameof(id));
            
            return _upgradeConfigs[id];
        }
    }
}