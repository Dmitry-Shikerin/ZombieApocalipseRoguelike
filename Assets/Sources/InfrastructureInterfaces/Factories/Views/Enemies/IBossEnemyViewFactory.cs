using Sources.Domain.Enemies.Bosses;
using Sources.Domain.Gameplay;
using Sources.Presentations.Views.Enemies.Bosses;
using Sources.PresentationsInterfaces.Views.Enemies.Bosses;

namespace Sources.InfrastructureInterfaces.Factories.Views.Enemies
{
    public interface IBossEnemyViewFactory
    {
        IBossEnemyView Create(BossEnemy bossEnemy, KillEnemyCounter killEnemyCounter);
        IBossEnemyView Create(BossEnemy bossEnemy, KillEnemyCounter killEnemyCounter, BossEnemyView bossEnemyView);
        
    }
}