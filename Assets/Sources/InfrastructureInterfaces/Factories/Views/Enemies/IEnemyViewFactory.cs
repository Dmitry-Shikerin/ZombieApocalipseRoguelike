using Sources.Domain.Enemies;
using Sources.Domain.Enemies.Base;
using Sources.Presentations.Views.Enemies;
using Sources.PresentationsInterfaces.Views.Enemies;
using Sources.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.InfrastructureInterfaces.Factories.Views.Enemies
{
    public interface IEnemyViewFactory
    {
        public IEnemyView Create(Enemy enemy);
        public IEnemyView Create(Enemy enemy, EnemyView enemyView);
    }
}