using Sources.ControllersInterfaces.ViewModels;
using Sources.DomainInterfaces.Components;
using Sources.Frameworks.LiveDatas;
using Sources.Frameworks.MVVM.Domain.Attributes;
using Sources.Infrastructure.Services.UseCases.Queries;
using Sources.MVVMFrameworks.DomainInterfaces.Properties;
using Sources.PresentationsInterfaces.Binds.Visibilities;

namespace Sources.Controllers.ModelViews.Components
{
    public class VisibilityViewModelComponent : IViewModelComponent
    {
        private readonly LiveData<bool> _isVisible;

        [PropertyBinding(typeof(IBindableViewEnabledPropertyBind))]
        private IBindableProperty<bool> _isEnabled;
        
        public VisibilityViewModelComponent(IComposite composite, GetVisibilityQuery getVisibilityQuery)
        {
            _isVisible = getVisibilityQuery.Handle(composite);
        }

        public void Enable() => 
            _isVisible.Observe(OnVisibilityChanged);

        public void Disable() => 
            _isVisible.UnObserve(OnVisibilityChanged);

        private void OnVisibilityChanged(bool value) => 
            _isEnabled.Value = value;
    }
}