using System;
using Sources.Controllers.ModelViews.Forms.Gameplay;
using Sources.ControllersInterfaces.ViewModels;
using Sources.Domain.Models.Forms.Gameplay;
using Sources.Frameworks.MVVM.InfrastructureInterfaces;
using Sources.Infrastructure.Factories.Controllers.ViewModels.Components;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Forms.Gameplay
{
    public class GameOverFormViewModelFactory : IViewModelFactory<GameOverFormViewModel, GameOverForm>
    {
        private readonly VisibilityViewModelComponentFactory _visibilityViewModelComponentFactory;
        private readonly LoadMainMenuViewModelComponentFactory _loadMainMenuViewModelComponentFactory;

        public GameOverFormViewModelFactory(
            VisibilityViewModelComponentFactory visibilityViewModelComponentFactory,
            LoadMainMenuViewModelComponentFactory loadMainMenuViewModelComponentFactory)
        {
            _visibilityViewModelComponentFactory = 
                visibilityViewModelComponentFactory ?? 
                throw new ArgumentNullException(nameof(visibilityViewModelComponentFactory));
            _loadMainMenuViewModelComponentFactory =
                loadMainMenuViewModelComponentFactory ??
                throw new ArgumentNullException(nameof(loadMainMenuViewModelComponentFactory));
        }

        public IViewModel Create(GameOverForm model)
        {
            return new GameOverFormViewModel(
                new IViewModelComponent[]
                {
                    _visibilityViewModelComponentFactory.Create(model),
                    _loadMainMenuViewModelComponentFactory.Create(),
                });
        }
    }
}