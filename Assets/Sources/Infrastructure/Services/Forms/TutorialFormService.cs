using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.UI.Huds;

namespace Sources.Infrastructure.Services.Forms
{
    public class TutorialFormService : FormService, ITutorialFormService
    {
        public TutorialFormService(GameplayHud gameplayHud) : base(gameplayHud.TutorialFormServiceContainerView)
        {
        }
    }
}