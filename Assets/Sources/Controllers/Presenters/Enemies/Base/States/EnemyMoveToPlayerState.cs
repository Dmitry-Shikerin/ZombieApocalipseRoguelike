﻿using System;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.Controllers.Presenters.Enemies.Base.States
{
    public class EnemyMoveToPlayerState : FiniteState
    {
        private readonly IEnemyView _enemyView;
        private readonly IEnemyAnimation _enemyAnimation;

        public EnemyMoveToPlayerState(IEnemyView enemyView, IEnemyAnimation enemyAnimation)
        {
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
            _enemyAnimation = enemyAnimation ?? throw new ArgumentNullException(nameof(enemyAnimation));
        }

        public override void Enter() =>
            _enemyAnimation.PlayWalk();

        public override void Update(float deltaTime) =>
            _enemyView.Move(_enemyView.CharacterMovementView.Position);
    }
}