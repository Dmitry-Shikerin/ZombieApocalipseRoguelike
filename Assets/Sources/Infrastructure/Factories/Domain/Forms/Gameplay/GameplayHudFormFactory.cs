using Sources.Domain.Components.Visibilities;
using Sources.Domain.Models.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Domain.Forms.Gameplay
{
    public class GameplayHudFormFactory
    {
        public GameplayHudForm Create()
        {
            GameplayHudForm form = new GameplayHudForm();
            form.AddComponent(new VisibilityComponent(true));

            return form;
        }
    }
}