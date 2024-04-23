using Sources.Frameworks.MVVM.PresentationInterfaces.Binds.AttachableView;
using Sources.Frameworks.PresentationInterfaces.Binds.AttachableView;
using Sources.Frameworks.PresentationInterfaces.Views;
using Sources.MVVMFrameworks.Domain.Properties;
using UnityEngine;

namespace Sources.Frameworks.Presentations.Binds.AttachableViews
{
    public class AttachableViewPropertyBind : BindableViewProperty<IAttachableView>, IAttachableView,
        IAttachableViewPropertyBind
    {
        public override IAttachableView BindableProperty
        {
            get => this;
            set { return; }
        }

        public void Attach(IBindableView bindableView) =>
            ((MonoBehaviour)bindableView).transform.SetParent(transform, false);
    }
}