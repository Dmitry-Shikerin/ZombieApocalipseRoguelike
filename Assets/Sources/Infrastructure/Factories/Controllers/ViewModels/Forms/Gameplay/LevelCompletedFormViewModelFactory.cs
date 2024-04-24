using System;
using Sources.Controllers.ModelViews.Forms.Gameplay;
using Sources.ControllersInterfaces.ViewModels;
using Sources.Domain.Models.Forms.Gameplay;
using Sources.Frameworks.MVVM.InfrastructureInterfaces;
using Sources.Infrastructure.Factories.Controllers.ViewModels.Components;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Forms.Gameplay
{
    public class LevelCompletedFormViewModelFactory : IViewModelFactory<LevelCompletedFormViewModel, LevelCompletedForm>
    {
        private readonly VisibilityViewModelComponentFactory _visibilityViewModelComponentFactory;

        public LevelCompletedFormViewModelFactory(VisibilityViewModelComponentFactory visibilityViewModelComponentFactory)
        {
            _visibilityViewModelComponentFactory =
                visibilityViewModelComponentFactory ??
                throw new ArgumentNullException(nameof(visibilityViewModelComponentFactory));
        }
        public IViewModel Create(LevelCompletedForm model)
        {
            return new LevelCompletedFormViewModel(
                new IViewModelComponent[]
                {
                    _visibilityViewModelComponentFactory.Create(model),
                });
        }
    }
}