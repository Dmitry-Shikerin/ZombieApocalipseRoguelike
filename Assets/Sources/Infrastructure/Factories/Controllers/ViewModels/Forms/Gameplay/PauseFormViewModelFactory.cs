using System;
using Sources.Controllers.ModelViews.Forms.Gameplay;
using Sources.ControllersInterfaces.ViewModels;
using Sources.Domain.Models.Forms.Gameplay;
using Sources.Frameworks.MVVM.InfrastructureInterfaces;
using Sources.Infrastructure.Factories.Controllers.ViewModels.Components;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Forms.Gameplay
{
    public class PauseFormViewModelFactory : IViewModelFactory<PauseFormViewModel, PauseForm>
    {
        private readonly VisibilityViewModelComponentFactory _visibilityViewModelComponentFactory;
        private readonly ShowHudFormViewModelComponentFactory _showHudFormViewModelComponentFactory;
        private readonly ShowGameplaySettingsFormViewModelComponentFactory _showGameplaySettingsFormViewModelComponentFactory;

        public PauseFormViewModelFactory(
            VisibilityViewModelComponentFactory visibilityViewModelComponentFactory,
            ShowHudFormViewModelComponentFactory showHudFormViewModelComponentFactory,
            ShowGameplaySettingsFormViewModelComponentFactory showGameplaySettingsFormViewModelComponentFactory)
        {
            _visibilityViewModelComponentFactory = 
                visibilityViewModelComponentFactory ?? 
                throw new ArgumentNullException(nameof(visibilityViewModelComponentFactory));
            _showHudFormViewModelComponentFactory = 
                showHudFormViewModelComponentFactory ??
                throw new ArgumentNullException(nameof(showHudFormViewModelComponentFactory));
            _showGameplaySettingsFormViewModelComponentFactory =
                showGameplaySettingsFormViewModelComponentFactory ??
                throw new ArgumentNullException(nameof(showGameplaySettingsFormViewModelComponentFactory));
        }

        public IViewModel Create(PauseForm model)
        {
            return new PauseFormViewModel(
                new IViewModelComponent[]
                {
                    _visibilityViewModelComponentFactory.Create(model),
                    _showHudFormViewModelComponentFactory.Create(),
                    _showGameplaySettingsFormViewModelComponentFactory.Create(),
                });
        }
    }
}