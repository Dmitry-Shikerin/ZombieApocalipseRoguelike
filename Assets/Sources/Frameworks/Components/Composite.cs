using System;
using System.Collections.Generic;
using System.Linq;
using Sources.DomainInterfaces.Components;

namespace Sources.Domain.Components
{
    public class Composite : IComposite
    {
        private readonly List<IComponent> _components = new List<IComponent>();
        
        public event Action BeforeComponentsChanged;
        public event Action AfterComponentsChanged;
        
        public bool TryGetComponent(Type type, out IComponent component)
        {
            component = _components.FirstOrDefault(currentComponent => currentComponent.GetType() == type);

            return component != null;
        }

        public bool TryGetComponent<T>(out T component) where T : IComponent
        {
            foreach (IComponent currentComponent in _components)
            {
                if (currentComponent.GetType() == typeof(T))
                {
                    component = (T)currentComponent;

                    return true;
                }
            }
            
            foreach (IComponent currentComponent in _components)
            {
                if (currentComponent is T typedComponent)
                {
                    component = typedComponent;

                    return true;
                }
            }

            component = default;

            return false;
        }

        public bool TryGetComponents<T>(out T[] components) where T : IComponent
        {
            components = _components.OfType<T>().ToArray();

            return components.Length != 0;
        }

        public void AddComponent(IComponent component)
        {
            BeforeComponentsChanged?.Invoke();
            
            if(_components.Contains(component))
                return;
            
            _components.Add(component);
            AfterComponentsChanged?.Invoke();
        }

        public void RemoveComponent(IComponent component)
        {
            BeforeComponentsChanged?.Invoke();
            _components.Remove(component);
            AfterComponentsChanged?.Invoke();
        }
    }
}