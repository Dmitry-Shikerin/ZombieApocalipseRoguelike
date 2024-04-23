using Sources.MVVMFrameworks.DomainInterfaces.Properties;
using Sources.MVVMFrameworks.DomainInterfaces.Properties.Generic;
using Sources.MVVMFrameworks.DomainInterfaces.Services.Factories;
using UnityEngine;

namespace Sources.MVVMFrameworks.Domain.Properties
{
    public abstract class BindableViewProperty<T> : MonoBehaviour, IBindableViewProperty<T>
    {
        private IBindableProperty<T> _property;
        
        public abstract T BindableProperty { get; set; }
        
        public IBindableProperty<T> GetBinding(IBindablePropertyFactory factory) => 
            factory.Create<T>(this, nameof(BindableProperty));
    }
}