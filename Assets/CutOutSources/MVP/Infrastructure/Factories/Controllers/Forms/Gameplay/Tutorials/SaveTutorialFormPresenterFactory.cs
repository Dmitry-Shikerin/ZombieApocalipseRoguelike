using Sources.Controllers.Presenters.Forms.Gameplay.Tutorials;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Forms.Gameplay.Tutorials
{
    public class SaveTutorialFormPresenterFactory
    {
        public SaveTutorialFormPresenter Create()
        {
            return new SaveTutorialFormPresenter();
        }
    }
}