using Sources.MVVMFrameworks.DomainInterfaces.Properties;

namespace Sources.MVVMFrameworks.DomainInterfaces.Services.Factories
{
    public interface IBindablePropertyFactory
    {
        IBindableProperty<T> Create<T>(object target, string propertyName);
    }
}