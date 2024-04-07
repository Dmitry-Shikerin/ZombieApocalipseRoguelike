using Sirenix.OdinInspector;
using Sources.Controllers.Abilities;
using Sources.Presentations.Triggers;
using Sources.PresentationsInterfaces.Views.Abilities;
using Sources.PresentationsInterfaces.Views.Enemies;
using UnityEngine;

namespace Sources.Presentations.Views.Abilities
{
    public class SawLauncherView : PresentableView<SawLauncherPresenter>, ISawLauncherView
    {
        [Required] [SerializeField] private EnemyTrigger _enemyTrigger;

        protected override void OnAfterEnable()
        {
            _enemyTrigger.Entered += OnEnter;
            _enemyTrigger.Exited += OnExit;
        }

        protected override void OnAfterDisable()
        {
            _enemyTrigger.Entered -= OnEnter;
            _enemyTrigger.Exited -= OnExit;
        }

        private void OnEnter(IEnemyHealthView enemy) =>
            Presenter.DealDamage(enemy);

        private void OnExit(IEnemyHealthView enemy)
        {
        }
    }
}