using Sources.InfrastructureInterfaces.Services.ObjectPools;
using Sources.Presentations.Views;
using Sources.PresentationsInterfaces.Views.ObjectPools;

namespace Sources.Infrastructure.Services.ObjectPools
{
    public class PoolableObjectDestroyerService : IPoolableObjectDestroyerService
    {
        public void Destroy(View view)
        {
            if (view.TryGetComponent(out PoolableObject poolableObject) == false)
            {
                view.Destroy();

                return;
            }

            poolableObject.ReturnToPool();
            view.Hide();
        }
    }
}