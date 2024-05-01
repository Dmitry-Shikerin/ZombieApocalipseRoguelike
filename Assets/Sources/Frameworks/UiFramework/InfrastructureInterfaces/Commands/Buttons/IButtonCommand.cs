using Sources.Frameworks.UiFramework.Domain.Commands;
using Sources.Frameworks.UiFramework.Presentation.Buttons;

namespace Sources.Frameworks.UiFramework.Infrastructure.Commands.Buttons
{
    public interface IButtonCommand
    {
        ButtonCommandId Id { get; }

        void Handle(UiButton uiButton);
    }
}