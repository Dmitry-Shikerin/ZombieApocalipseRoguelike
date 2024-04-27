using Sources.MVVMFrameworks.DomainInterfaces.Services;
using Sources.MVVMFrameworks.DomainInterfaces.Services.Factories;

namespace Sources.MVVMFrameworks.DomainInterfaces.Properties
{
    public interface IBindableViewProperty
    {
        object OnBind(IBindablePropertyFactory factory);
    }
}