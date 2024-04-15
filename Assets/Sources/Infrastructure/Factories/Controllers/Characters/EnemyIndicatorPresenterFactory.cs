using System;
using Sources.Controllers.Characters;
using Sources.Infrastructure.Services.EnemyCollectors;
using Sources.InfrastructureInterfaces.Services.EnemyCollectors;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.Presentations.Views.Characters;
using Sources.Presentations.Views.Characters.EnemyIndicators;
using Sources.PresentationsInterfaces.Views.Character.EnemyIndicators;

namespace Sources.Infrastructure.Factories.Controllers.Characters
{
    public class EnemyIndicatorPresenterFactory
    {
        private readonly IEnemyCollectorService _enemyCollectorService;
        private readonly IUpdateRegister _updateRegister;

        public EnemyIndicatorPresenterFactory(
            IEnemyCollectorService enemyCollectorService,
            IUpdateRegister updateRegister)
        {
            _enemyCollectorService = enemyCollectorService ?? 
                                     throw new ArgumentNullException(nameof(enemyCollectorService));
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
        }

        public EnemyIndicatorPresenter Create(IEnemyIndicatorView enemyIndicatorView)
        {
            return new EnemyIndicatorPresenter(
                enemyIndicatorView, _enemyCollectorService, _updateRegister);
        }
    }
}