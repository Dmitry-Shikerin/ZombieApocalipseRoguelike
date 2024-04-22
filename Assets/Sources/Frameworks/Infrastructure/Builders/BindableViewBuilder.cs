using System;
using Sources.ControllersInterfaces.ViewModels;
using Sources.Frameworks.InfrastructureInterfaces;
using Sources.Frameworks.MVVM.PresentationInterfaces.Factories;
using Sources.Frameworks.PresentationInterfaces.Views;
using Sources.Frameworks.Presentations.Views;

namespace Sources.Frameworks.Infrastructure.Builders
{
    public class BindableViewBuilder<TViewModel> : IBindableViewBuilder<TViewModel> 
        where TViewModel : IViewModel
    {
        private readonly IBindableViewFactory _bindableViewFactory;
        private readonly IViewModelFactory<TViewModel> _viewModelFactory;

        public BindableViewBuilder
        (
            IBindableViewFactory bindableViewFactory,
            IViewModelFactory<TViewModel> viewModelFactory
        )
        {
            _bindableViewFactory = bindableViewFactory ??
                                   throw new ArgumentNullException(nameof(bindableViewFactory));
            _viewModelFactory = viewModelFactory ??
                                throw new ArgumentNullException(nameof(viewModelFactory));
        }

        public IBindableView Build(int entityId, string viewPath, string prefabName, IBindableView parent = null)
        {
            IViewModel viewModel = _viewModelFactory.Create(entityId);
            IBindableView view = _bindableViewFactory.Create(viewPath, prefabName);
            
            view.Bind(viewModel);

            return view;
        }
        
        public IBindableView Build(int entityId, BindableView bindableView, IBindableView parent = null)
        {
            IViewModel viewModel = _viewModelFactory.Create(entityId);
            IBindableView view = _bindableViewFactory.Create(bindableView);
            
            view.Bind(viewModel);

            return view;
        }

    }
}