using Sources.Domain.Components.Visibilities;
using Sources.Domain.Models.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Domain.Forms.MainMenu
{
    public class MainMenuSettingsFormFactory
    {
        public MainMenuSettingsForm Create()
        {
            MainMenuSettingsForm form = new MainMenuSettingsForm();
            form.AddComponent(new VisibilityComponent(true));

            return form;
        }
    }
}