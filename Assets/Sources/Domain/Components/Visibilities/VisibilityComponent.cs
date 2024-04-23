
using Sources.DomainInterfaces.Components;
using Sources.Frameworks.LiveDatas;

namespace Sources.Domain.Components.Visibilities
{
    public class VisibilityComponent : IComponent
    {
        private MutableLiveData<bool> _isVisible;

        public VisibilityComponent(bool isVisible)
        {
            _isVisible = new MutableLiveData<bool>(isVisible);
        }

        public LiveData<bool> IsVisible => _isVisible;

        public void Show() => 
            _isVisible.Value = true;

        public void Hide() => 
            _isVisible.Value = false;
    }
}