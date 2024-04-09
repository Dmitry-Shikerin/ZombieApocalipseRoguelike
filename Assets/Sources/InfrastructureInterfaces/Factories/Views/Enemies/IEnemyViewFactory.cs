using Sources.Domain.Enemies;
using Sources.Presentations.Views.Enemies;
using Sources.PresentationsInterfaces.Views.Enemies;

namespace Sources.InfrastructureInterfaces.Factories.Views.Enemies
{
    public interface IEnemyViewFactory
    {
        public IEnemyView Create(Enemy enemy);
        public IEnemyView Create(Enemy enemy, EnemyView enemyView);
    }
}