﻿using Sources.DomainInterfaces.Models.Upgrades;

namespace Sources.Domain.Models.Abilities
{
    public class SawLauncherAbility
    {
        public SawLauncherAbility(IUpgrader upgrader)
        {
            Upgrader = upgrader;
        }

        public IUpgrader Upgrader { get; }
    }
}