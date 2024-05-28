using System;
using Sources.DomainInterfaces.Components;

namespace Sources.Infrastructure.Services.UseCases
{
    public class ComponentUseCaseBase<T> where T : IComponent
    {
        protected T GetComponent(IComposite composite)
        {
            if (composite.TryGetComponent(out T component) == false)
                throw new NullReferenceException(nameof(component));

            return component;
        }
    }
}