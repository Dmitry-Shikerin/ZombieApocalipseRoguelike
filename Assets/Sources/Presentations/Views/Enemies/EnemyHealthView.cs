using Sources.Controllers.Enemies;
using Sources.PresentationsInterfaces.Views.Enemies;
using UnityEngine;

namespace Sources.Presentations.Views.Enemies
{
    public class EnemyHealthView : PresentableView<EnemyHealthPresenter>, IEnemyHealthView
    {
        public Vector3 Position => transform.position;
        public float CurrentHealth => Presenter.CurrentHealth;

        public void TakeDamage(float damage) =>
            Presenter.TakeDamage(damage);
    }
}