using Sources.Controllers.Enemies;
using Sources.Controllers.Presenters.Enemies;
using Sources.Domain.Models.Enemies;
using Sources.PresentationsInterfaces.Views.Enemies;

namespace Sources.Infrastructure.Factories.Controllers.Enemies
{
    public class EnemyHealthPresenterFactory
    {
        public EnemyHealthPresenter Create(EnemyHealth enemyHealth, IEnemyHealthView enemyHealthView)
        {
            return new EnemyHealthPresenter(enemyHealth, enemyHealthView);
        }
    }
}