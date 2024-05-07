using System;
using Sources.Controllers.Common;
using Sources.Domain.Models.Abilities;
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
            OnSawLauncherViewsEnable();

            _sawLauncherAbility.Upgrader.LevelChanged += OnSawLauncherViewsEnable;
            _updateRegister.Register(OnUpdate);
        }

        public override void Disable()
        {
            _sawLauncherAbility.Upgrader.LevelChanged -= OnSawLauncherViewsEnable;
            _updateRegister.UnRegister(OnUpdate);
        }

        private void OnUpdate(float deltaTime)
        {
            _sawLauncherAbilityView.Rotate(Vector3.up);
            _sawLauncherAbilityView.Follow();
        }

        //TODO порефакторить проэкт и вынести логику в сервисы
        //TODO вся эта логика может остаться здесь
        private void OnSawLauncherViewsEnable()
        {
            //TODO в дополнительный конфиг
            int sawLauncherCount = _sawLauncherAbility.Upgrader.CurrentLevel switch
            {
                0 => 0,
                1 => 1,
                2 => 2,
                3 => 4,
                _ => throw new ArgumentOutOfRangeException(nameof(_sawLauncherAbility.Upgrader.CurrentLevel))
            };
            
            ShowSawLauncherViews(sawLauncherCount);
        }

        private void HideSawLauncherViews()
        {
            foreach (SawLauncherView sawLauncherView in _sawLauncherAbilityView.SawLauncherViews)
                sawLauncherView.Hide();
        }

        private void ShowSawLauncherViews(int count)
        {
            for (int i = 0; i < count; i++) 
                _sawLauncherAbilityView.SawLauncherViews[i].Show();
        }
    }
}