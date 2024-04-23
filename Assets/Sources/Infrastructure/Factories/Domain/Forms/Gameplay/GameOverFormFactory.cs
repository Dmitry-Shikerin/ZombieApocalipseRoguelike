using Sources.Domain.Components.Visibilities;
using Sources.Domain.Models.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Domain.Forms.Gameplay
{
    public class GameOverFormFactory
    {
        public GameOverForm Create()
        {
            GameOverForm form = new GameOverForm();
            form.AddComponent(new VisibilityComponent(true));
            
            return form;
        }
    }
}