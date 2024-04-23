using Sources.Domain.Components.Visibilities;
using Sources.Domain.Models.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Domain.Forms.Gameplay
{
    public class PauseFormFactory
    {
        public PauseForm Create()
        {
            PauseForm form = new PauseForm();
            form.AddComponent(new VisibilityComponent(true));
            
            return form;
        }
    }
}