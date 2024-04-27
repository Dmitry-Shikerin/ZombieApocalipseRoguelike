using Sources.MVVMFrameworks.DomainInterfaces.Services.Factories;

namespace Sources.MVVMFrameworks.DomainInterfaces.Properties.Generic
{
    public interface IBindableViewProperty<T> : IBindableViewProperty
    {
        IBindableProperty<T> GetBinding(IBindablePropertyFactory factory);

        object IBindableViewProperty.OnBind(IBindablePropertyFactory factory) => 
            GetBinding(factory);
    }
}