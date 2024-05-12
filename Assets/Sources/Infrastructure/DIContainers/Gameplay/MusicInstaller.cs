using Sources.Domain.Models.AudioSources;
using Sources.Infrastructure.Factories.Controllers.Presenters.Musics;
using Sources.Infrastructure.Factories.Controllers.Settings;
using Sources.Infrastructure.Factories.Views.Musics;
using Sources.Infrastructure.Factories.Views.Settings;
using Zenject;

namespace Sources.Infrastructure.DIContainers.Gameplay
{
    public class MusicInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<AudioClipCollection>()
                .FromResource("Configs/GameplayAudioClipContainer")
                .AsSingle();
            
            Container.Bind<BackgroundMusicPresenterFactory>().AsSingle();
            Container.Bind<BackgroundMusicViewFactory>().AsSingle();
            
            Container.Bind<VolumePresenterFactory>().AsSingle();
            Container.Bind<VolumeViewFactory>().AsSingle();
        }
    }
}