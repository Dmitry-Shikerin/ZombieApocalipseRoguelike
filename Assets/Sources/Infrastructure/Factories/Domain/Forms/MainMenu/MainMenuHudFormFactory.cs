using Sources.Domain.Components.Visibilities;
using Sources.Domain.Models.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Domain.Forms.MainMenu
{
    public class MainMenuHudFormFactory
    {
        public MainMenuHudForm Create()
        {
            MainMenuHudForm form = new MainMenuHudForm();
            form.AddComponent(new VisibilityComponent(true));

            return form;
        }
    }
}