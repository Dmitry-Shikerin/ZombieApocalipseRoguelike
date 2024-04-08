using Sources.ControllersInterfaces.ControllerLifetimes;
using Sources.InfrastructureInterfaces.Services.StatesLifetimes;

namespace Sources.PresentationsInterfaces.UI.Texts
{
    public interface ITextView : IEnable, IDisable
    {
        string Id { get; }
        
        void SetText(string text);
    }
}