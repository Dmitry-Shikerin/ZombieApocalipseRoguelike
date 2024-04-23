using Sources.Domain.Components.Visibilities;
using Sources.Domain.Models.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Domain.Forms.Gameplay
{
    public class UpgradeFormFactory
    {
        public UpgradeForm Create()
        {
            UpgradeForm form = new UpgradeForm();
            form.AddComponent(new VisibilityComponent(true));
            
            return form;
        }
    }
}