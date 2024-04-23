using System;
using Sources.Controllers.ModelViews.Forms.Gameplay;
using Sources.ControllersInterfaces.ViewModels;
using Sources.Domain.Models.Forms.Gameplay;
using Sources.Frameworks.MVVM.InfrastructureInterfaces;
using Sources.Infrastructure.Factories.Controllers.ViewModels.Components;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Forms.Gameplay
{
    public class GameplaySettingsFormViewModelFactory : IViewModelFactory<GameplaySettingsFormViewModel, GameplaySettingsForm>
    {
        private readonly VisibilityViewModelComponentFactory _visibilityViewModelComponentFactory;
        private readonly ShowPauseFormViewModelComponentFactory _showPauseFormViewModelComponentFactory;

        public GameplaySettingsFormViewModelFactory(
            VisibilityViewModelComponentFactory visibilityViewModelComponentFactory,
            ShowPauseFormViewModelComponentFactory showPauseFormViewModelComponentFactory)
        {
            _visibilityViewModelComponentFactory =
                visibilityViewModelComponentFactory ??
                throw new ArgumentNullException(nameof(visibilityViewModelComponentFactory));
            _showPauseFormViewModelComponentFactory =
                showPauseFormViewModelComponentFactory ??
                throw new ArgumentNullException(nameof(showPauseFormViewModelComponentFactory));
        }
        public IViewModel Create(GameplaySettingsForm model)
        {
            return new GameplaySettingsFormViewModel(
                new IViewModelComponent[]
                {
                    _visibilityViewModelComponentFactory.Create(model),
                    _showPauseFormViewModelComponentFactory.Create(),
                });
        }
    }
}