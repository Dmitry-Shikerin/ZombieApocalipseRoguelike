using Sources.Domain.Components.Visibilities;
using Sources.Domain.Models.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Domain.Forms.MainMenu
{
    public class WarningNewGameFormFactory
    {
        public WarningNewGameForm Create()
        {
            WarningNewGameForm form = new WarningNewGameForm();
            form.AddComponent(new VisibilityComponent(true));

            return form;
        }
    }
}