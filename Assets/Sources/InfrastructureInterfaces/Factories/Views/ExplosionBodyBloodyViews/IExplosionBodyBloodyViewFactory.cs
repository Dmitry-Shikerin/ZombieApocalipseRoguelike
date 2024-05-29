using Sources.Presentations.Views.ExplosionBodyBloodies;
using Sources.PresentationsInterfaces.Views.ExplosionBodyBloodies;
using UnityEngine;

namespace Sources.InfrastructureInterfaces.Factories.Views.ExplosionBodyBloodyViews
{
    public interface IExplosionBodyBloodyViewFactory
    {
        IExplosionBodyBloodyView Create(ExplosionBodyBloodyView explosionBodyBloodyView, Vector3 position);

        IExplosionBodyBloodyView Create(Vector3 position);
    }
}