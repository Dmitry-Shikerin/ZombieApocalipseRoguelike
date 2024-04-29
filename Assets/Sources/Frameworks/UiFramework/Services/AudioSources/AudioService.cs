using System.Collections.Generic;
using System.Linq;
using Sources.Frameworks.UiFramework.Presentation.AudioSources;
using Sources.Frameworks.UiFramework.Presentation.AudioSources.Types;
using Sources.Frameworks.UiFramework.Presentation.Forms;

namespace Sources.Frameworks.UiFramework.Services.AudioSources
{
    public class AudioService : IAudioService
    {
        private readonly Dictionary<AudioSourceId, UiAudioSource> _audioSources;
        
        public AudioService(UiCollector uiCollector)
        {
            _audioSources = uiCollector.UiAudioSources.ToDictionary(
                uiAudioSource => uiAudioSource.AudioSourceId, uiAudioSource => uiAudioSource);
        }

        public void Play(AudioSourceId id)
        {
            if(_audioSources.ContainsKey(id) == false)
                throw new KeyNotFoundException(id.ToString());
            
            _audioSources[id].Play();
        }
    }

    public interface IAudioService
    {
        void Play(AudioSourceId id);
    }
}