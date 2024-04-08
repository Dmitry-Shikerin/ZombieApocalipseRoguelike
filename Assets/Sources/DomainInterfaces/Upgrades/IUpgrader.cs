using System;
using Sources.DomainInterfaces.Data;

namespace Sources.DomainInterfaces.Upgrades
{
    public interface IUpgrader : IDataModel
    {
        event Action LevelChanged;

        int CurrentLevel { get; }
        float CurrentAmount { get; }
    }
}