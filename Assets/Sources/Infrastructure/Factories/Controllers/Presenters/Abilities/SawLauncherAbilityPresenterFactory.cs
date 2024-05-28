using System;
using Sources.Controllers.Presenters.Abilities;
using Sources.Domain.Models.Abilities;
using Sources.Domain.Models.Upgrades.Configs;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.PresentationsInterfaces.Views.Abilities;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Abilities
{
    public class SawLauncherAbilityPresenterFactory
    {
        private readonly IUpdateRegister _updateRegister;
        private readonly SawLauncherAbilityUpgradeMap _sawLauncherAbilityUpgradeMap;

        public SawLauncherAbilityPresenterFactory(
            IUpdateRegister updateRegister,
            SawLauncherAbilityUpgradeMap sawLauncherAbilityUpgradeMap)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
            _sawLauncherAbilityUpgradeMap = sawLauncherAbilityUpgradeMap 
                ? sawLauncherAbilityUpgradeMap 
                : throw new ArgumentNullException(nameof(sawLauncherAbilityUpgradeMap));
        }

        public SawLauncherAbilityPresenter Create(
            SawLauncherAbility sawLauncherAbility,
            ISawLauncherAbilityView sawLauncherAbilityView)
        {
            return new SawLauncherAbilityPresenter(
                sawLauncherAbility, 
                sawLauncherAbilityView,
                _updateRegister,
                _sawLauncherAbilityUpgradeMap);
        }
    }
}