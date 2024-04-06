using Sources.Controllers.Enemies;
using Sources.Domain.Enemies;
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