using Sources.Domain.Components.Visibilities;
using Sources.Domain.Models.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Domain.Forms.Gameplay
{
    public class GameplaySettingFormFactory
    {
        public GameplaySettingsForm Create()
        {
            GameplaySettingsForm form = new GameplaySettingsForm();
            form.AddComponent(new VisibilityComponent(true));
            
            return form;
        }
    }
}