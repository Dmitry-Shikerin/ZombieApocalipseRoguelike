using System;
using System.Linq;
using System.Reflection;
using Sources.MVVMFrameworks.Domain.Methods;
using Sources.MVVMFrameworks.DomainInterfaces.Services.Factories;

namespace Sources.MVVMFrameworks.DomainServices.Factories
{
    public class BindableMethodFactory : IBindableMethodFactory
    {
        public object Create(object viewModel, MethodInfo methodInfo)
        {
            Type actionGenericType = typeof(BindableMethod<>);

            Type[] parameterTypes = methodInfo
                .GetParameters()
                .Select(info => info.ParameterType)
                .ToArray();

            Type actionType = actionGenericType.MakeGenericType(parameterTypes);

            return Activator.CreateInstance(actionType, new object[] { viewModel, methodInfo });
        }
    }
}