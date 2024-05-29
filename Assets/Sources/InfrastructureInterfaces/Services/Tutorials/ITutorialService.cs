using Sources.ControllersInterfaces.ControllerLifetimes;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Setting;

namespace Sources.InfrastructureInterfaces.Services.Tutorials
{
    public interface ITutorialService : IEnable
    {
        void Complete();

        void Construct(Tutorial tutorial, SavedLevel level);
    }
}