using System;
using System.Collections.Generic;
using Sources.DomainInterfaces.Data;

namespace Sources.DomainInterfaces.Upgrades
{
    public interface IUpgrader : IDataModel
    {
        event Action LevelChanged;

        public int MaxLevel { get; }
        int CurrentLevel { get; }
        IReadOnlyList<int> MoneyPerUpgrades { get; }
        float CurrentAmount { get; }
    }
}