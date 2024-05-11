using System;
using Sources.Controllers.Presenters.Characters;
using Sources.Infrastructure.Services.Characters;
using Sources.Infrastructure.Services.EnemyCollectors;
using Sources.InfrastructureInterfaces.Services.EnemyCollectors;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.Presentations.Views.Characters;
using Sources.Presentations.Views.Characters.EnemyIndicators;
using Sources.PresentationsInterfaces.Views.Character.EnemyIndicators;
using Sources.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Utils.CustomCollections;

namespace Sources.Infrastructure.Factories.Controllers.Characters
{
    public class EnemyIndicatorPresenterFactory
    {
        private readonly ICustomCollection<IEnemyView> _enemyCollection;
        private readonly IUpdateRegister _updateRegister;
        private readonly IEnemyIndicatorService _enemyIndicatorService;

        public EnemyIndicatorPresenterFactory(
            ICustomCollection<IEnemyView> enemyCollection,
            IUpdateRegister updateRegister,
            IEnemyIndicatorService enemyIndicatorService)
        {
            _enemyCollection = enemyCollection ?? 
                                     throw new ArgumentNullException(nameof(enemyCollection));
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
            _enemyIndicatorService = enemyIndicatorService ?? 
                                     throw new ArgumentNullException(nameof(enemyIndicatorService));
        }

        public EnemyIndicatorPresenter Create(IEnemyIndicatorView enemyIndicatorView)
        {
            return new EnemyIndicatorPresenter(
                enemyIndicatorView, _enemyCollection, _updateRegister, _enemyIndicatorService);
        }
    }
}