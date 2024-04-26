using System;
using Sources.ControllersInterfaces.ViewModels;

namespace Sources.Controllers.ModelViews
{
    public abstract class ViewModelBase : IViewModel
    {
        private readonly IViewModelComponent[] _components;

        private bool _isEnabled;

        protected ViewModelBase(IViewModelComponent[] components)
        {
            _components = components ?? throw new ArgumentNullException(nameof(components));
        }

        //TODO где инвокаается это событие?
        public event Action Destroyed;

        public void Enable()
        {
            if(_isEnabled)
                return;
            
            EnableParts();

            OnBeforeEnable();
            _isEnabled = true;
            OnEnable();
            OnAfterEnable();
        }

        public void Disable()
        {
            if(_isEnabled == false)
                return;
            
            OnBeforeDisable();
            _isEnabled = false;
            OnDisable();
            OnAfterDisable();

            DisableParts();
        }

        protected abstract void OnEnable();

        protected abstract void OnDisable();

        protected virtual void OnBeforeEnable()
        {
        }

        protected virtual void OnBeforeDisable()
        {
        }

        protected virtual void OnAfterEnable()
        {
        }

        protected virtual void OnAfterDisable()
        {
        }

        private void EnableParts()
        {
            foreach (IViewModelComponent viewModelComponent in _components)
                viewModelComponent.Enable();
        }

        private void DisableParts()
        {
            foreach (IViewModelComponent viewModelComponent in _components)
                viewModelComponent.Disable();
        }
    }
}