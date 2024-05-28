using System;
using Sources.Domain.Models.Abilities;
using Sources.PresentationsInterfaces.Views.Enemies;

namespace Sources.Controllers.Presenters.Abilities
{
    public class SawLauncherPresenter : PresenterBase
    {
        private readonly SawLauncher _sawLauncher;

        public SawLauncherPresenter(SawLauncher sawLauncher)
        {
            _sawLauncher = sawLauncher ?? throw new ArgumentNullException(nameof(sawLauncher));
        }

        public void DealDamage(IEnemyHealthView enemy) =>
            enemy.TakeDamage(_sawLauncher.Damage);
    }
}