using Sources.Domain.Components.Visibilities;
using Sources.Domain.Models.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Domain.Forms.Gameplay
{
    public class TutorialFormFactory
    {
        public TutorialForm Create()
        {
            TutorialForm form = new TutorialForm();
            form.AddComponent(new VisibilityComponent(true));

            return form;
        }
    }
}