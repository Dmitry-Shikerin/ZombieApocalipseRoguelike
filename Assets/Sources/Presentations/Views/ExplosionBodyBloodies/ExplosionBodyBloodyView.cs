﻿using Sirenix.OdinInspector;
using Sources.Infrastructure.Services.ObjectPools;
using Sources.InfrastructureInterfaces.Services.ObjectPools;
using Sources.PresentationsInterfaces.Views.ExplosionBodyBloodies;
using UnityEngine;

namespace Sources.Presentations.Views.ExplosionBodyBloodies
{
    public class ExplosionBodyBloodyView : View, IExplosionBodyBloodyView
    {
        [Required] [SerializeField] private ParticleSystem _particleSystem;

        private IPoolableObjectDestroyerService _poolableObjectDestroyerService =
            new PoolableObjectDestroyerService();

        private void OnEnable() =>
            _particleSystem.Play();

        private void OnParticleSystemStopped() =>
            _poolableObjectDestroyerService.Destroy(this);
    }
}