using System;
using JetBrains.Annotations;
using Sources.ControllersInterfaces.ViewModels;
using Sources.Frameworks.MVVM.PresentationInterfaces.Views;
using Sources.Frameworks.PresentationInterfaces.Binder;
using Sources.Presentations.Views;
using UnityEngine;

namespace Sources.Frameworks.MVVM.Presentations.Views
{
    public class BindableView : View, IBindableView
    {
        private IBinder Binder;

        private IViewModel _viewModel;
        
        private Action AfterUnbindCallback { get; set; }

        private void Awake() => 
            gameObject.SetActive(false);

        private void OnEnable()
        {
            // _viewModel?.Enable();
        }

        private void OnDisable()
        {
            // _viewModel?.Disable();
        }
        
        //TODO почему нельзя сделать как с презентерами?
        public void Bind(IViewModel viewModel)
        {
            // Hide();
            _viewModel = viewModel;
            Binder.Bind(this, viewModel);
            viewModel.Enable();
            // Show();
        }

        public void Unbind()
        {
            if(_viewModel != null)
                Binder.Unbind(this, _viewModel);
            
            gameObject.SetActive(false);
            
            AfterUnbindCallback?.Invoke();
        }

        [UsedImplicitly]
        private void Construct(IBinder binder) => 
            Binder = binder ?? throw new ArgumentNullException(nameof(binder));

        public void SetParent(IBindableView parent)
        {
            if(parent is null)
                return;

            if (parent is not MonoBehaviour monoBehaviour)
                throw new InvalidOperationException();
            
            monoBehaviour.transform.SetParent(transform, false);
        }
    }
}