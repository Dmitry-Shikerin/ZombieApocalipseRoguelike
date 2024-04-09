using Sources.ControllersInterfaces.ControllerLifetimes;
using Sources.Domain.TextViewTypes;
using Sources.InfrastructureInterfaces.Services.StatesLifetimes;

namespace Sources.PresentationsInterfaces.UI.Texts
{
    public interface ITextView : IEnable, IDisable
    {
        TextViewType TextViewType { get; }
        string Id { get; }
        
        void SetText(string text);
    }
}