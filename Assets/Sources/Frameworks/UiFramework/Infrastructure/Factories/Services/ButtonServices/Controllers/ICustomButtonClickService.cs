using Sources.Frameworks.UiFramework.Presentation.Buttons;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.ButtonServices.Controllers
{
    public interface ICustomButtonClickService
    {
        void Enable(UiButton button);
        void Disable(UiButton button);
        void OnClick(UiButton button);
    }
}