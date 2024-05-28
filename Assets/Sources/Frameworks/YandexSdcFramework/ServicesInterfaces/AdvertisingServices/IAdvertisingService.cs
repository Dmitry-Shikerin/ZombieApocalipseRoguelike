using Sources.ControllersInterfaces.ControllerLifetimes;
using Sources.Domain.Models.Players;
using Sources.PresentationsInterfaces.Views.Constructors;

namespace Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.AdvertisingServices
{
    public interface IAdvertisingService : IConstruct<PlayerWallet>, IEnable, IDisable
    {
    }
}