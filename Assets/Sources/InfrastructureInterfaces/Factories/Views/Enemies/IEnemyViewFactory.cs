using Sources.Domain.Enemies;
using Sources.Domain.Enemies.Base;
using Sources.Domain.Gameplay;
using Sources.Presentations.Views.Enemies;
using Sources.PresentationsInterfaces.Views.Enemies;
using Sources.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.InfrastructureInterfaces.Factories.Views.Enemies
{
    public interface IEnemyViewFactory
    {
        public IEnemyView Create(Enemy enemy, KillEnemyCounter killEnemyCounter);
        public IEnemyView Create(Enemy enemy, KillEnemyCounter killEnemyCounter, EnemyView enemyView);
    }
}