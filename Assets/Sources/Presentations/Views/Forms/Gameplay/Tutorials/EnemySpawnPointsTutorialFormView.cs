using Sources.Controllers.Presenters.Forms.Gameplay.Tutorials;
using Sources.Presentations.Views.Forms.Common;
using Sources.PresentationsInterfaces.UI.Buttons;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay.Tutorials;

namespace Sources.Presentations.Views.Forms.Gameplay.Tutorials
{
    public class EnemySpawnPointsTutorialFormView : FormBase<EnemySpawnPointsTutorialFormPresenter>, 
        IEnemySpawnPointTutorialFormView
    {
        public IButtonView HudFormButton { get; }
    }
}