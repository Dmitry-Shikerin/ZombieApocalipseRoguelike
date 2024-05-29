using System;
using Sources.Presentations.Views;
using Sources.PresentationsInterfaces.Views.ObjectPools;

namespace Sources.InfrastructureInterfaces.Services.ObjectPools
{
    public interface IObjectPool
    {
        event Action<int> ObjectCountChanged;

        T Get<T>()
            where T : View;

        void Return(PoolableObject poolableObject);
    }
}