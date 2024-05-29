using Sources.Controllers.Presenters.Enemies;
using Sources.PresentationsInterfaces.Views.Enemies;
using UnityEngine;

namespace Sources.Presentations.Views.Enemies
{
    public class EnemyHealthView : PresentableView<EnemyHealthPresenter>, IEnemyHealthView
    {
        [SerializeField] private ParticleSystem _bloodParticle;

        public Vector3 Position => transform.position;

        public float CurrentHealth => Presenter.CurrentHealth;

        public void TakeDamage(float damage) =>
            Presenter.TakeDamage(damage);

        public void PlayBloodParticle() =>
            _bloodParticle.Play();
    }
}