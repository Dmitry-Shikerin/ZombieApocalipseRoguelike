using System;

namespace Sources.DomainInterfaces.Components
{
    public interface IComposite
    {
        event Action BeforeComponentsChanged;
        event Action AfterComponentsChanged;

        bool TryGetComponent(Type type, out IComponent component);
        bool TryGetComponent<T>(out T component) where T : IComponent;
        bool TryGetComponents<T>(out T[] components) where T : IComponent;
    }
}