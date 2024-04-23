using System.Reflection;

namespace Sources.MVVMFrameworks.DomainInterfaces.Services.Factories
{
    public interface IBindableMethodFactory
    {
        object Create(object viewModel, MethodInfo methodInfo);
    }
}