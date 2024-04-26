using System;
using Sources.Controllers.ModelViews.Forms.Gameplay;
using Sources.ControllersInterfaces.ViewModels;
using Sources.Domain.Models.Forms.Gameplay;
using Sources.Frameworks.MVVM.InfrastructureInterfaces;
using Sources.Infrastructure.Factories.Controllers.ViewModels.Components;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Forms.Gameplay
{
    public class GameplayHudFormViewModelFactory : IViewModelFactory<GameplayHudFormViewModel, GameplayHudForm>
    {
        private readonly VisibilityViewModelComponentFactory _visibilityViewModelComponentFactory;
        private readonly ShowPauseFormViewModelComponentFactory _showPauseFormViewModelComponentFactory;
        private readonly ShowUpgradeFormViewModelComponentFactory _showUpgradeFormViewModelComponentFactory;

        public GameplayHudFormViewModelFactory(
            VisibilityViewModelComponentFactory visibilityViewModelComponentFactory,
            ShowPauseFormViewModelComponentFactory showPauseFormViewModelComponentFactory,
            ShowUpgradeFormViewModelComponentFactory showUpgradeFormViewModelComponentFactory)
        {
            _visibilityViewModelComponentFactory = 
                visibilityViewModelComponentFactory ?? 
                throw new ArgumentNullException(nameof(visibilityViewModelComponentFactory));
            _showPauseFormViewModelComponentFactory = 
                showPauseFormViewModelComponentFactory ?? 
                throw new ArgumentNullException(nameof(showPauseFormViewModelComponentFactory));
            _showUpgradeFormViewModelComponentFactory =
                showUpgradeFormViewModelComponentFactory ?? 
                throw new ArgumentNullException(nameof(showUpgradeFormViewModelComponentFactory));
        }

        public IViewModel Create(GameplayHudForm model)
        {
            return new GameplayHudFormViewModel(
                new IViewModelComponent[]
                {
                    _visibilityViewModelComponentFactory.Create(model),
                    _showPauseFormViewModelComponentFactory.Create(),
                    _showUpgradeFormViewModelComponentFactory.Create(),
                });
        }
    }
}