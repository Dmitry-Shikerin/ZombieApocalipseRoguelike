using Sources.PresentationsInterfaces.UI.AudioSources;

namespace Sources.PresentationsInterfaces.Views.Weapons
{
    public interface IMiniGunView : IWeaponView
    {
        IAudioSourceView ShootAudioSource { get; }
        IAudioSourceView EndShootAudioSource { get; }
        
        void PlayFireParticles();
        void StopFireParticles();
    }
}