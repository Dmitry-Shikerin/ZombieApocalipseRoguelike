﻿using Sources.ControllersInterfaces.ViewModels;
using Sources.Frameworks.MVVM.PresentationInterfaces.Views;
using Sources.Frameworks.MVVM.Presentations.Views;

namespace Sources.Frameworks.MVVM.InfrastructureInterfaces
{
    public interface IBindableViewBuilder<TViewModel, TModel> 
        where TViewModel : IViewModel
    {
        IBindableView Build(TModel model, string viewPath, string prefabName,  IBindableView parent = null);
        public IBindableView Build(TModel model, BindableView bindableView, IBindableView parent = null);
    }
}