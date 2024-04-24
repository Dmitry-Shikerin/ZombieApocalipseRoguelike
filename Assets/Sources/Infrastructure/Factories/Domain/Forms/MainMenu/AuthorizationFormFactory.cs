using Sources.Domain.Components.Visibilities;
using Sources.Domain.Models.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Domain.Forms.MainMenu
{
    public class AuthorizationFormFactory
    {
        public AuthorizationForm Create()
        {
            AuthorizationForm form = new AuthorizationForm();
            form.AddComponent(new VisibilityComponent(true));

            return form;
        }
    }
}