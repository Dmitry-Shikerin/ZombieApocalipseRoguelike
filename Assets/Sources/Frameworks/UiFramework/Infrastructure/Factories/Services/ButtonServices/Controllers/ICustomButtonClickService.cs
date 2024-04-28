using Sources.Frameworks.UiFramework.Presentation.Buttons;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.ButtonServices.Controllers
{
    public interface ICustomButtonClickService
    {
        void Enable(UiFormButton button);
        void Disable(UiFormButton button);
        void OnClick(UiFormButton button);
    }
}