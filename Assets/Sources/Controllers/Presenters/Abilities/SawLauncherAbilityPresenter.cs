using System;
using Sources.Controllers.Common;
using Sources.Domain.Models.Abilities;
using Sources.Domain.Models.Constants;
using Sources.Domain.Models.Upgrades.Configs;
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
            _sawLauncherAbilityView.Rotate(Vector3.up);
            _sawLauncherAbilityView.Follow();
        }

        private void OnSawLauncherViewsEnable()
        {
            //TODO в дополнительный конфиг
            // int sawLauncherCount = _sawLauncherAbility.Upgrader.CurrentLevel switch
            // {
            //     SLAConstant.ZeroLevel => SLAConstant.ZeroLevelCount,
            //     SLAConstant.FirstLevel => SLAConstant.FirstLevelCount,
            //     SLAConstant.SecondLevel => SLAConstant.SecondLevelCount,
            //     SLAConstant.ThirdLevel => SLAConstant.ThirdLevelCount,
            //     _ => throw new ArgumentOutOfRangeException(nameof(_sawLauncherAbility.Upgrader.CurrentLevel))
            // };
            //
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