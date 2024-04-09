using System;
using Sources.Controllers.Common;
using Sources.ControllersInterfaces;
using Sources.Domain.Enemies;
using Sources.Infrastructure.StateMachines.FiniteStateMachines;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.PresentationsInterfaces.Views.Enemies;

namespace Sources.Controllers.Enemies
{
    public class EnemyPresenter : FiniteStateMachine, IPresenter
    {
        private readonly FiniteState _firstState;
        private readonly Enemy _enemy;
        private readonly IEnemyView _enemyView;
        private readonly IUpdateRegister _updateRegister;

        public EnemyPresenter(
            FiniteState firstState,
            Enemy enemy,
            IEnemyView enemyView,
            IUpdateRegister updateRegister)
        {
            _firstState = firstState ?? throw new ArgumentNullException(nameof(firstState));
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
        }

        public void Enable()
        {
            Start(_firstState);
            _updateRegister.UpdateChanged += Update;
        }

        public void Disable()
        {
            Stop();
            _updateRegister.UpdateChanged -= Update;
        }
    }
}