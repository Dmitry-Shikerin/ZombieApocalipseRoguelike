using Sources.DomainInterfaces.Data;
using Sources.DomainInterfaces.Entities;

namespace Sources.InfrastructureInterfaces.Services.LoadServices
{
    public interface ILoadService
    {
        T Load<T>(IEntity entity) 
            where T : IDto;
        public void Save(IEntity entity);
        void SaveAll();
    }
}