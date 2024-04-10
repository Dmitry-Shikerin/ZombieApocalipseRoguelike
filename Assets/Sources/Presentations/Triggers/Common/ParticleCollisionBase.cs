using System;
using Sources.Presentations.Views;
using Sources.PresentationsInterfaces.Triggers;
using UnityEngine;

namespace Sources.Presentations.Triggers.Common
{
    public class ParticleCollisionBase<T> : View, IEnteredTrigger<T>
    {
        public event Action<T> Entered;
        
        //TODO можно ли как то получить точкку с которой я столкнулся?
        private void OnParticleCollision(GameObject other)
        {
            if (other.TryGetComponent(out T component))
                Entered?.Invoke(component);
        }
    }
}