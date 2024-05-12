using Sources.Presentations.Views;
using UnityEngine;

namespace Sources.InfrastructureInterfaces.Services.ObjectPools
{
    public interface IPoolableObjectDestroyerService
    {
        void Destroy(View view);
    }
}