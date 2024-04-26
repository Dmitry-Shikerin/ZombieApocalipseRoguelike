using System;
using Sources.Controllers.ModelViews.Components;
using Sources.Controllers.ModelViews.Forms.MainMenu;
using Sources.ControllersInterfaces.ViewModels;
using Sources.Domain.Models.Forms.MainMenu;
using Sources.Frameworks.MVVM.InfrastructureInterfaces;
using Sources.Infrastructure.Factories.Controllers.ViewModels.Components;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Forms.MainMenu
{
    public class LeaderboardFormViewModelFactory : IViewModelFactory<LeaderboardFormViewModel, LeaderboardForm>
    {
        private readonly VisibilityViewModelComponentFactory _visibilityViewModelComponentFactory;
        private readonly ShowMainMenuHudFormViewModelComponentFactory _showMainMenuHudFormViewModelComponentFactory;

        public LeaderboardFormViewModelFactory(
            VisibilityViewModelComponentFactory visibilityViewModelComponentFactory,
            ShowMainMenuHudFormViewModelComponentFactory showMainMenuHudFormViewModelComponentFactory)
        {
            _visibilityViewModelComponentFactory =
                visibilityViewModelComponentFactory ??
                throw new ArgumentNullException(nameof(visibilityViewModelComponentFactory));
            _showMainMenuHudFormViewModelComponentFactory =
                showMainMenuHudFormViewModelComponentFactory ??
                throw new ArgumentNullException(nameof(showMainMenuHudFormViewModelComponentFactory));
        }
        public IViewModel Create(LeaderboardForm model)
        {
            return new LeaderboardFormViewModel(
                new IViewModelComponent[]
                {
                    _visibilityViewModelComponentFactory.Create(model),
                    _showMainMenuHudFormViewModelComponentFactory.Create(),
                });
        }
    }
}