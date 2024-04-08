using Sources.DomainInterfaces.Data;

namespace Sources.InfrastructureInterfaces.Services.LoadServices
{
    public interface ILoadService
    {
        T Load<T>(IDataModel dataModel) where T : IDto;
        void Save<T>(T dataModel) where T : IDataModel;
        void Register(IDataModel dataModel);
        void SaveAll();
    }
}