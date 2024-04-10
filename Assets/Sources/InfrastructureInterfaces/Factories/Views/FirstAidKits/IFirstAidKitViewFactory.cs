using Sources.PresentationsInterfaces.Views.FirstAidKits;
using UnityEngine;

namespace Sources.InfrastructureInterfaces.Factories.Views.FirstAidKits
{
    public interface IFirstAidKitViewFactory
    {
        public IFirstAidKitView Create(Vector3 position);
    }
}