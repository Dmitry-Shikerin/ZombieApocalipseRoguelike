using System;
using Sirenix.OdinInspector;
using Sources.PresentationsInterfaces.Views.ExplosionBodyBloodies;
using Sources.PresentationsInterfaces.Views.ObjectPools;
using UnityEngine;

namespace Sources.Presentations.Views.ExplosionBodyBloodies
{
    public class ExplosionBodyBloodyView : View, IExplosionBodyBloodyView
    {
        [Required] [SerializeField] private ParticleSystem _particleSystem;
        
        private void OnEnable() =>
            _particleSystem.Play();

        private void OnParticleSystemStopped()
        {
            if (TryGetComponent(out PoolableObject poolableObject) == false)
            {
                Destroy(gameObject);
                
                return;
            }
            
            poolableObject.ReturnToPool();
            Hide();
        }
    }
}