using Sources.Domain.Components.Visibilities;
using Sources.Domain.Models.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Domain.Forms.Gameplay
{
    public class LevelCompletedFormFactory
    {
        public LevelCompletedForm Create()
        {
            LevelCompletedForm form = new LevelCompletedForm();
            form.AddComponent(new VisibilityComponent(true));
            
            return form;
        }
    }
}