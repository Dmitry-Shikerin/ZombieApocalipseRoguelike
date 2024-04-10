using System;
using Sources.Controllers.Enemies.Base;
using Sources.Controllers.Enemies.Bosses.States;
using Sources.Domain.Enemies.Bosses;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.PresentationsInterfaces.Views.Enemies.Bosses;

namespace Sources.Infrastructure.Factories.Controllers.Enemies.Bosses
{
    public class BossEnemyPresenterFactory
    {
        private readonly IUpdateRegister _updateRegister;

        public BossEnemyPresenterFactory(IUpdateRegister updateRegister)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
        }

        public EnemyPresenter Create(
            BossEnemy bossEnemy,
            IBossEnemyView bossEnemyView,
            IBossEnemyAnimation bossEnemyAnimation)
        {
            EnemyIdleState idleState = new EnemyIdleState(bossEnemy, bossEnemyAnimation);
            
            return new EnemyPresenter(idleState, _updateRegister);
        }
    }
}