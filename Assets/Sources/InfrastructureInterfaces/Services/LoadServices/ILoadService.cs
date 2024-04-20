using Sources.DomainInterfaces.Data;
using Sources.DomainInterfaces.Entities;

namespace Sources.InfrastructureInterfaces.Services.LoadServices
{
    public interface ILoadService
    {
        void LoadAll();
        void SaveAll();
    }
}