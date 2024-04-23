using System;
using Sources.Controllers.ModelViews.Forms.Gameplay;
using Sources.ControllersInterfaces.ViewModels;
using Sources.Domain.Models.Forms.Gameplay;
using Sources.Frameworks.MVVM.InfrastructureInterfaces;
using Sources.Infrastructure.Factories.Controllers.ViewModels.Components;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Forms.Gameplay
{
    public class UpgradeFormViewModelFactory : IViewModelFactory<UpgradeFormViewModel, UpgradeForm>
    {
        private readonly VisibilityViewModelComponentFactory _visibilityViewModelComponentFactory;
        private readonly ShowHudFormViewModelComponentFactory _showHudFormViewModelComponentFactory;

        public UpgradeFormViewModelFactory(
            VisibilityViewModelComponentFactory visibilityViewModelComponentFactory,
            ShowHudFormViewModelComponentFactory showHudFormViewModelComponentFactory)
        {
            _visibilityViewModelComponentFactory =
                visibilityViewModelComponentFactory ??
                throw new ArgumentNullException(nameof(visibilityViewModelComponentFactory));
            _showHudFormViewModelComponentFactory =
                showHudFormViewModelComponentFactory ??
                throw new ArgumentNullException(nameof(showHudFormViewModelComponentFactory));
        }
        public IViewModel Create(UpgradeForm model)
        {
            return new UpgradeFormViewModel(
                new IViewModelComponent[]
            {
                _visibilityViewModelComponentFactory.Create(model),
                _showHudFormViewModelComponentFactory.Create(),
            });
        }
    }
}