using System;

namespace Sources.DomainInterfaces.Upgrades
{
    public interface IUpgrader
    {
        event Action LevelChanged;

        int CurrentLevel { get; }
        float CurrentAmount { get; }
    }
}