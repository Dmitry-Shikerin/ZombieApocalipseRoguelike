using Sources.ControllersInterfaces.ControllerLifetimes;
using Sources.InfrastructureInterfaces.Services.StatesLifetimes;
using Sources.Presentations.UiFramework.Animations;
using Sources.PresentationsInterfaces.Views.Constructors;

namespace Sources.InfrastructureInterfaces.Services.UiFrameworks
{
    public interface IViewService : IAwake, IEnable, IDisable, IConstruct<FormButtonScaleAnimation>
    {
    }
}