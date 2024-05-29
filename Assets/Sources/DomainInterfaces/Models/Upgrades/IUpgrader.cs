using System;
using System.Collections.Generic;
using Sources.DomainInterfaces.Models.Entities;

namespace Sources.DomainInterfaces.Models.Upgrades
{
    public interface IUpgrader : IEntity
    {
        event Action LevelChanged;

        public int MaxLevel { get; }

        int CurrentLevel { get; }

        IReadOnlyList<int> MoneyPerUpgrades { get; }

        float CurrentAmount { get; }
    }
}