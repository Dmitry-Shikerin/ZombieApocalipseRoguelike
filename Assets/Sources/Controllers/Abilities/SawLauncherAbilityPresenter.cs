using System;
using Sources.Controllers.Common;
using Sources.Domain.Abilities;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.Presentations.Views.Abilities;
using Sources.PresentationsInterfaces.Views.Abilities;
using UnityEngine;

namespace Sources.Controllers.Abilities
{
    public class SawLauncherAbilityPresenter : PresenterBase
    {
        private readonly SawLauncherAbility _sawLauncherAbility;
        private readonly ISawLauncherAbilityView _sawLauncherAbilityView;
        private readonly IUpdateRegister _updateRegister;

        public SawLauncherAbilityPresenter(
            SawLauncherAbility sawLauncherAbility,
            ISawLauncherAbilityView sawLauncherAbilityView,
            IUpdateRegister updateRegister)
        {
            _sawLauncherAbility = sawLauncherAbility ?? throw new ArgumentNullException(nameof(sawLauncherAbility));
            _sawLauncherAbilityView = sawLauncherAbilityView ??
                                      throw new ArgumentNullException(nameof(sawLauncherAbilityView));
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
        }

        public override void Enable()
        {
            HideSawLauncherViews();
            
            _updateRegister.Register(OnUpdate);
        }

        public override void Disable()
        {
            _updateRegister.UnRegister(OnUpdate);
        }

        
        
        //TODO возможно инстанциировать и фолловить за персонажем
        private void OnUpdate(float deltaTime)
        {
            _sawLauncherAbilityView.Rotate(new Vector3(0, 1, 0));
        }

        private void HideSawLauncherViews()
        {
            foreach (SawLauncherView sawLauncherView in _sawLauncherAbilityView.SawLauncherViews)
                sawLauncherView.Hide();
        }
    }
}