using Sources.DomainInterfaces.Data;

namespace Sources.InfrastructureInterfaces.Services.LoadServices.Data
{
    public interface IDataService
    {
        T LoadData<T>(string key) 
            where T : IDto;
        void SaveData<T>(T dataModel, string key) 
            where T : IDto;
    }
}