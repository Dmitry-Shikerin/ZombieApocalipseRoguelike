using Sources.Domain.Models.Enemies.Base;
using Sources.Domain.Models.Gameplay;
using Sources.Presentations.Views.Enemies;
using Sources.Presentations.Views.Enemies.Base;
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