using Sources.Infrastructure.Services.ObjectPools;
using Sources.InfrastructureInterfaces.Services.ObjectPools;
using Sources.Presentations.Views;

namespace Sources.PresentationsInterfaces.Views.ObjectPools
{
    public class PoolableObject : View
    {
        private IObjectPool _pool;

        public PoolableObject SetPool(IObjectPool pool)
        {
            _pool = pool;

            return this;
        }
        
        public void ReturnToPool() =>
            _pool.Return(this);
    }
}