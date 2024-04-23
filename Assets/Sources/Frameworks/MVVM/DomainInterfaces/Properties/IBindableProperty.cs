using System;

namespace Sources.MVVMFrameworks.DomainInterfaces.Properties
{
    public interface IBindableProperty<T> : IDisposable
    {
        event Action Changed;
        
        public T Value { get; set; }
    }
}