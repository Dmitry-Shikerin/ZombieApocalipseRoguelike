using Sources.Infrastructure.Factories.Controllers.Presenters.Musics;
using Sources.Infrastructure.Factories.Controllers.Presenters.Settings;
using Sources.Infrastructure.Factories.Views.Musics;
using Sources.Infrastructure.Factories.Views.Settings;
using Zenject;

namespace Sources.Infrastructure.DIContainers.Common
{
    public class MusicInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BackgroundMusicPresenterFactory>().AsSingle();
            Container.Bind<BackgroundMusicViewFactory>().AsSingle();
            
            Container.Bind<VolumePresenterFactory>().AsSingle();
            Container.Bind<VolumeViewFactory>().AsSingle();
        }
    }
}