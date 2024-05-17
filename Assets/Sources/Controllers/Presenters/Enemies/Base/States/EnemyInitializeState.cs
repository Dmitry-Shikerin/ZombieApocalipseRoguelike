using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Domain.Models.Enemies.Base;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.PresentationsInterfaces.Views.Enemies;
using Sources.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Utils.CustomCollections;
using Sources.Utils.Extensions;

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
            ChangeSkin();
            _enemyAnimation.PlayIdle();
            _enemyCollection.Add(_enemyView);
        }

        private void ChangeSkin()
        {
            IEnemySkin skin = _enemyView.Skins.GetRandomItem();
            
            _enemyView.Skins
                .Except(new List<IEnemySkin>() { skin })
                .ToList()
                .ForEach(concreteSkin => concreteSkin.Hide());
            
            skin.Show();
        }
    }
}