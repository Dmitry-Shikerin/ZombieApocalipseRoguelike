using System;

namespace Sources.DomainInterfaces.Models.Upgrades
{
    public interface IUpgradeController
    {
        event Action UpgradeFormShowed;
    }
}