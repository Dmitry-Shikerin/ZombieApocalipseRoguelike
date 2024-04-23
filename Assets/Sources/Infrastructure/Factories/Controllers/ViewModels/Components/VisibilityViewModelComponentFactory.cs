using System;
using Sources.Controllers.ModelViews.Components;
using Sources.ControllersInterfaces.ViewModels;
using Sources.DomainInterfaces.Components;
using Sources.Infrastructure.Services.UseCases.Queries;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class VisibilityViewModelComponentFactory
    {
        private readonly GetVisibilityQuery _getVisibilityQuery;

        public VisibilityViewModelComponentFactory(GetVisibilityQuery getVisibilityQuery)
        {
            _getVisibilityQuery = getVisibilityQuery ?? throw new ArgumentNullException(nameof(getVisibilityQuery));
        }

        public IViewModelComponent Create(IComposite composite)
        {
            return new VisibilityViewModelComponent(composite, _getVisibilityQuery);
        }
    }
}