using System;
using Sources.Presentations.Views;
using UnityEngine;

namespace Sources.Presentations.Triggers
{
    public abstract class TriggerBase<T> : View
    {
        public event Action<T> Entered;
        public event Action<T> Exited;

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out T component))
                Entered?.Invoke(component);
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.TryGetComponent(out T component))
                Exited?.Invoke(component);
        }
    }
}