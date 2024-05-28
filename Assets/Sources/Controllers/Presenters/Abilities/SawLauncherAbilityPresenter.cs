using System;
using Sources.Controllers.Common;
using Sources.Domain.Models.Abilities;
using Sources.Domain.Models.Upgrades.Configs;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.Presentations.Views.Abilities;
using Sources.PresentationsInterfaces.Views.Abilities;
using UnityEngine;

namespace Sources.Controllers.Presenters.Abilities
{
    public class SawLauncherAbilityPresenter : PresenterBase
    {
        private readonly SawLauncherAbility _sawLauncherAbility;
        private readonly ISawLauncherAbilityView _sawLauncherAbilityView;
        private readonly IUpdateRegister _updateRegister;
        private readonly SawLauncherAbilityUpgradeMap _sawLauncherAbilityUpgradeMap;

        public SawLauncherAbilityPresenter(
            SawLauncherAbility sawLauncherAbility,
            ISawLauncherAbilityView sawLauncherAbilityView,
            IUpdateRegister updateRegister,
            SawLauncherAbilityUpgradeMap sawLauncherAbilityUpgradeMap)
        {
            _sawLauncherAbility = sawLauncherAbility ?? throw new ArgumentNullException(nameof(sawLauncherAbility));
            _sawLauncherAbilityView = sawLauncherAbilityView ??
                                      throw new ArgumentNullException(nameof(sawLauncherAbilityView));
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
            _sawLauncherAbilityUpgradeMap = sawLauncherAbilityUpgradeMap 
                ? sawLauncherAbilityUpgradeMap 
                : throw new ArgumentNullException(nameof(sawLauncherAbilityUpgradeMap));
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
            float speed = _sawLauncherAbilityUpgradeMap.RotateSpeed;
            _sawLauncherAbilityView.Rotate(new Vector3(0, speed, 0));
            _sawLauncherAbilityView.Follow();
        }

        private void OnSawLauncherViewsEnable()
        {
            int currentLevel = _sawLauncherAbility.Upgrader.CurrentLevel;
            int sawLauncherCount = _sawLauncherAbilityUpgradeMap.Map[currentLevel];
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