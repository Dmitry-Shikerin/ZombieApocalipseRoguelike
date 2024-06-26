﻿using Sources.ControllersInterfaces.ViewModels;
using Sources.Frameworks.MVVM.PresentationInterfaces.Views;

namespace Sources.Frameworks.PresentationInterfaces.Binder
{
    public interface IBinder
    {
        void Bind(IBindableView view, IViewModel viewModel);
        void Unbind(IBindableView view, IViewModel viewModel);
    }
}