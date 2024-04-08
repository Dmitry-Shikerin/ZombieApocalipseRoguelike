﻿using System;
using Sources.Controllers.Abilities;
using Sources.Domain.Abilities;
using Sources.Infrastructure.Factories.Controllers.Abilities;
using Sources.Presentations.Views.Abilities;
using Sources.PresentationsInterfaces.Views.Abilities;

namespace Sources.Infrastructure.Factories.Views.Abilities
{
    public class SawLauncherAbilityViewFactory
    {
        private readonly SawLauncherAbilityPresenterFactory _sawLauncherAbilityPresenterFactory;

        public SawLauncherAbilityViewFactory(SawLauncherAbilityPresenterFactory sawLauncherAbilityPresenterFactory)
        {
            _sawLauncherAbilityPresenterFactory = 
                sawLauncherAbilityPresenterFactory ??
                throw new ArgumentNullException(nameof(sawLauncherAbilityPresenterFactory));
        }

        public ISawLauncherAbilityView Create(
            SawLauncherAbility sawLauncherAbility,
            SawLauncherAbilityView sawLauncherAbilityView)
        {
            SawLauncherAbilityPresenter sawLauncherAbilityPresenter =
                _sawLauncherAbilityPresenterFactory.Create(sawLauncherAbility, sawLauncherAbilityView);
            
            sawLauncherAbilityView.Construct(sawLauncherAbilityPresenter);
            
            return sawLauncherAbilityView;
        }
    }
}