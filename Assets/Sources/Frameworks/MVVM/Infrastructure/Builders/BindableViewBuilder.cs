using System;
using Sources.ControllersInterfaces.ViewModels;
using Sources.Frameworks.MVVM.InfrastructureInterfaces;
using Sources.Frameworks.MVVM.PresentationInterfaces.Factories;
using Sources.Frameworks.MVVM.PresentationInterfaces.Views;
using Sources.Frameworks.MVVM.Presentations.Views;

namespace Sources.Frameworks.MVVM.Infrastructure.Builders
{
    public class BindableViewBuilder<TViewModel, TModel> : IBindableViewBuilder<TViewModel, TModel> 
        where TViewModel : IViewModel
    {
        private readonly IBindableViewFactory _bindableViewFactory;
        private readonly IViewModelFactory<TViewModel, TModel> _viewModelFactory;

        public BindableViewBuilder(
            IBindableViewFactory bindableViewFactory,
            IViewModelFactory<TViewModel, TModel> viewModelFactory)
        {
            _bindableViewFactory = bindableViewFactory ??
                                   throw new ArgumentNullException(nameof(bindableViewFactory));
            _viewModelFactory = viewModelFactory ??
                                throw new ArgumentNullException(nameof(viewModelFactory));
        }

        public IBindableView Build(TModel model, string viewPath, string prefabName, IBindableView parent = null)
        {
            IViewModel viewModel = _viewModelFactory.Create(model);
            IBindableView view = _bindableViewFactory.Create(viewPath, prefabName);
            
            view.Bind(viewModel);

            return view;
        }
        
        public IBindableView Build(TModel model, BindableView bindableView, IBindableView parent = null)
        {
            IViewModel viewModel = _viewModelFactory.Create(model);
            IBindableView view = _bindableViewFactory.Create(bindableView);
            
            view.Bind(viewModel);

            return view;
        }

    }
}