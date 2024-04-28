using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Setting;
using Sources.InfrastructureInterfaces.Services.StatesLifetimes;
using Sources.PresentationsInterfaces.Views.Constructors;

namespace Sources.InfrastructureInterfaces.Services.Tutorials
{
    public interface ITutorialService : IEnable
    {
        void Complete();
        void Construct(Tutorial tutorial, SavedLevel level);
    }
}