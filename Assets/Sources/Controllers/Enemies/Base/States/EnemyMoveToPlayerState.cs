using System;
using Sources.Domain.Enemies;
using Sources.Domain.Enemies.Base;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.PresentationsInterfaces.Views.Enemies;
using Sources.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;

namespace Sources.Controllers.Enemies.Base.States
{
    public class EnemyMoveToPlayerState : FiniteState
    {
        private readonly Enemy _enemy;
        private readonly IEnemyView _enemyView;
        private readonly IEnemyAnimation _enemyAnimation;
        
        public EnemyMoveToPlayerState(Enemy enemy, IEnemyView enemyView, IEnemyAnimation enemyAnimation)
        {
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
            _enemyAnimation = enemyAnimation ?? throw new ArgumentNullException(nameof(enemyAnimation));
        }

        public override void Enter()
        {
            _enemyAnimation.PlayWalk();
            Debug.Log($"Play walk");
        }

        public override void Exit()
        {
        }

        public override void Update(float deltaTime)
        {
            _enemyAnimation.PlayWalk();
            _enemyView.Move(_enemyView.CharacterMovementView.Position);
        }
    }
}