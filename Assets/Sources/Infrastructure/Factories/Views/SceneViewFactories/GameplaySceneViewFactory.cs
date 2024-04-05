using System;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Presentations.Views.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Views.SceneViewFactories
{
    public class GameplaySceneViewFactory
    {
        private readonly GameplayFormServiceFactory _gameplayFormServiceFactory;

        public GameplaySceneViewFactory(GameplayFormServiceFactory gameplayFormServiceFactory)
        {
            _gameplayFormServiceFactory = gameplayFormServiceFactory ?? 
                                          throw new ArgumentNullException(nameof(gameplayFormServiceFactory));
        }

        public void Create()
        {
            _gameplayFormServiceFactory.Create().Show<HudFormView>();
        }
    }
}