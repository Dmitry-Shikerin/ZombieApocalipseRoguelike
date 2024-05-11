using System;
using Sources.Domain.Models.Enemies.Base;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.InfrastructureInterfaces.Services.EnemyCollectors;
using Sources.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Utils.CustomCollections;

namespace Sources.Controllers.Presenters.Enemies.Base.States
{
    public class EnemyInitializeState : FiniteState
    {
        private readonly Enemy _enemy;
        private readonly IEnemyAnimation _enemyAnimation;
        private readonly IEnemyView _enemyView;
        private readonly CustomCollection<IEnemyView> _enemyCollection;

        public EnemyInitializeState(
            Enemy enemy, 
            IEnemyAnimation enemyAnimation,
            IEnemyView enemyView,
            CustomCollection<IEnemyView> enemyCollection)
        {
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
            _enemyAnimation = enemyAnimation;
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
            _enemyCollection = enemyCollection ?? throw new ArgumentNullException(nameof(enemyCollection));
        }

        public override void Enter()
        {
            _enemy.IsInitialized = true;
            _enemyAnimation.PlayIdle();
            _enemyCollection.Add(_enemyView);
        }
    }
}