using System;
using Sources.Controllers.Abilities;
using Sources.Domain.Models.Abilities;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.PresentationsInterfaces.Views.Abilities;

namespace Sources.Infrastructure.Factories.Controllers.Abilities
{
    public class SawLauncherAbilityPresenterFactory
    {
        private readonly IUpdateRegister _updateRegister;

        public SawLauncherAbilityPresenterFactory(IUpdateRegister updateRegister)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
        }

        public SawLauncherAbilityPresenter Create(
            SawLauncherAbility sawLauncherAbility,
            ISawLauncherAbilityView sawLauncherAbilityView)
        {
            return new SawLauncherAbilityPresenter(
                sawLauncherAbility, 
                sawLauncherAbilityView,
                _updateRegister);
        }
    }
}