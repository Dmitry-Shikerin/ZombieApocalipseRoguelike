using Sources.Controllers.Presenters.Forms.Gameplay.Tutorials;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay.Tutorials;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Forms.Gameplay.Tutorials
{
    public class EnemySpawnPointsTutorialFormPresenterFactory
    {
        public EnemySpawnPointsTutorialFormPresenter Create(IEnemySpawnPointTutorialFormView view)
        {
            return new EnemySpawnPointsTutorialFormPresenter();
        }
    }
}