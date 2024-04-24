using Sources.DomainInterfaces.Entities;

namespace Sources.InfrastructureInterfaces.Services.LoadServices
{
    public interface ILoadService
    {
        T Load<T>(string id) 
            where T : class, IEntity;
        void Save(IEntity entity);
        void LoadAll();
        void SaveAll();
        void ClearAll();
        bool HasKey(string id);
    }
}