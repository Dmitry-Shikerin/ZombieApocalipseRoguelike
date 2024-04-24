using System;
using Sources.Domain.Models.Enemies.Base;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.InfrastructureInterfaces.Services.EnemyCollectors;
using Sources.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.Controllers.Enemies.Base.States
{
    public class EnemyInitializeState : FiniteState
    {
        private readonly Enemy _enemy;
        private readonly IEnemyAnimation _enemyAnimation;
        private readonly IEnemyView _enemyView;
        private readonly IEnemyCollectorService _enemyCollectorService;

        public EnemyInitializeState(
            Enemy enemy, 
            IEnemyAnimation enemyAnimation,
            IEnemyView enemyView,
            IEnemyCollectorService enemyCollectorService)
        {
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
            _enemyAnimation = enemyAnimation;
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
            _enemyCollectorService = enemyCollectorService ?? throw new ArgumentNullException(nameof(enemyCollectorService));
        }

        public override void Enter()
        {
            _enemy.IsInitialized = true;
            _enemyAnimation.PlayIdle();
            _enemyCollectorService.Add(_enemyView);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
        }
    }
}