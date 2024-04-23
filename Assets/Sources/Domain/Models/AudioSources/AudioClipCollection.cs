using System.Collections.Generic;
using UnityEngine;

namespace Sources.Domain.AudioSources
{
    [CreateAssetMenu(menuName = "Configs/AudioClipContainer", fileName = "AudioClipContainer", order = 51)]
    public class AudioClipCollection : ScriptableObject
    {
        [SerializeField] private List<AudioClip> _audioClips;

        public IReadOnlyList<AudioClip> AudioClips => _audioClips;
    }
}