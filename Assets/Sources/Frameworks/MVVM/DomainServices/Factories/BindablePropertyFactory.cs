using System.Reflection;
using Sources.MVVMFrameworks.Domain.Properties;
using Sources.MVVMFrameworks.DomainInterfaces.Properties;
using Sources.MVVMFrameworks.DomainInterfaces.Services.Factories;

namespace Sources.MVVMFrameworks.DomainServices.Factories
{
    public class BindablePropertyFactory : IBindablePropertyFactory
    {
        private static readonly BindingFlags s_bindingFlags =
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
        
        public IBindableProperty<T> Create<T>(object target, string propertyName) =>
            new BindableProperty<T>(target, target.GetType().GetProperty(propertyName, s_bindingFlags));
    }
}