using Sirenix.OdinInspector;
using Sources.Frameworks.Presentations.Views;
using Sources.MVVMFrameworks.Domain.Properties;
using Sources.PresentationsInterfaces.Binds.Visibilities;
using UnityEngine;

namespace Sources.Presentations.Binds.Visibilities
{
    public class BindableViewEnabledPropertyBind : BindableViewProperty<bool>, IBindableViewEnabledPropertyBind
    {
        [Required] [SerializeField] private BindableView _view;

        public override bool BindableProperty
        {
            get => _view.gameObject.activeSelf;
            set => _view.gameObject.SetActive(value);
        }

    }
}