using Sources.Domain.Enemies.Bosses;
using Sources.Presentations.Views.Enemies.Bosses;
using Sources.PresentationsInterfaces.Views.Enemies.Bosses;

namespace Sources.InfrastructureInterfaces.Factories.Views.Enemies
{
    public interface IBossEnemyViewFactory
    {
        IBossEnemyView Create(BossEnemy bossEnemy);
        IBossEnemyView Create(BossEnemy bossEnemy, BossEnemyView bossEnemyView);
        
    }
}