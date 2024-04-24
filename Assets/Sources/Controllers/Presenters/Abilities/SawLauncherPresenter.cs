using System;
using Sources.Controllers.Common;
using Sources.Domain.Models.Abilities;
using Sources.Presentations.Views.Abilities;
using Sources.PresentationsInterfaces.Views.Abilities;
using Sources.PresentationsInterfaces.Views.Enemies;

namespace Sources.Controllers.Abilities
{
    public class SawLauncherPresenter : PresenterBase
    {
        private readonly SawLauncher _sawLauncher;
        private readonly ISawLauncherView _sawLauncherView;

        public SawLauncherPresenter(
            SawLauncher sawLauncher,
            ISawLauncherView sawLauncherView)
        {
            _sawLauncher = sawLauncher ?? throw new ArgumentNullException(nameof(sawLauncher));
            _sawLauncherView = sawLauncherView ?? throw new ArgumentNullException(nameof(sawLauncherView));
        }

        public void DealDamage(IEnemyHealthView enemy) =>
            enemy.TakeDamage(_sawLauncher.Damage);
    }
}