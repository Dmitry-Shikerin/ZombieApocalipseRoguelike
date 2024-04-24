using System;
using Sources.Controllers.ModelViews.Forms.MainMenu;
using Sources.ControllersInterfaces.ViewModels;
using Sources.Domain.Models.Forms.MainMenu;
using Sources.Frameworks.MVVM.InfrastructureInterfaces;
using Sources.Infrastructure.Factories.Controllers.ViewModels.Components;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Forms.MainMenu
{
    public class AuthorizationFormViewModelFactory : IViewModelFactory<AuthorizationFormViewModel, AuthorizationForm>
    {
        private readonly VisibilityViewModelComponentFactory _visibilityViewModelComponentFactory;
        private readonly ShowMainMenuHudFormViewModelComponentFactory _showMainMenuHudFormViewModelComponentFactory;

        public AuthorizationFormViewModelFactory(
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
        public IViewModel Create(AuthorizationForm model)
        {
            return new AuthorizationFormViewModel(
                new IViewModelComponent[]
                {
                    _visibilityViewModelComponentFactory.Create(model),
                    _showMainMenuHudFormViewModelComponentFactory.Create(),
                });
        }
    }
}