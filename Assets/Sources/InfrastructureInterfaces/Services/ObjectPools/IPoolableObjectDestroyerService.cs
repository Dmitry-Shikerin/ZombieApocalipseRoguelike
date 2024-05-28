using Sources.Presentations.Views;

namespace Sources.InfrastructureInterfaces.Services.ObjectPools
{
    public interface IPoolableObjectDestroyerService
    {
        void Destroy(View view);
    }
}