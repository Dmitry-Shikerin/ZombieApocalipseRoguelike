using Sirenix.OdinInspector;
using Sources.Controllers.Abilities;
using Sources.Presentations.Triggers;
using Sources.PresentationsInterfaces.Views.Abilities;
using Sources.PresentationsInterfaces.Views.Enemies;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Presentations.Views.Abilities
{
    public class SawLauncherView : PresentableView<SawLauncherPresenter>, ISawLauncherView
    {
        [Required] [SerializeField] private EnemyHealthTrigger _enemyHealthTrigger;

        protected override void OnAfterEnable()
        {
            _enemyHealthTrigger.Entered += OnEnter;
            _enemyHealthTrigger.Exited += OnExit;
        }

        protected override void OnAfterDisable()
        {
            _enemyHealthTrigger.Entered -= OnEnter;
            _enemyHealthTrigger.Exited -= OnExit;
        }

        private void OnEnter(IEnemyHealthView enemy) =>
            Presenter.DealDamage(enemy);

        private void OnExit(IEnemyHealthView enemy)
        {
        }
    }
}