using Sources.DomainInterfaces.Data;
using Sources.DomainInterfaces.Entities;

namespace Sources.InfrastructureInterfaces.Services.LoadServices
{
    public interface ILoadService
    {
        public T Load<T>(string id)
            where T : IDto;
        public void Save(IEntity entity);
        void SaveAll();
    }
}