using Sources.Domain.Components.Visibilities;
using Sources.Domain.Models.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Domain.Forms.MainMenu
{
    public class NewGameFormFactory
    {
        public NewGameForm Create()
        {
            NewGameForm form = new NewGameForm();
            form.AddComponent(new VisibilityComponent(true));

            return form;
        }
    }
}