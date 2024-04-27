using System.Collections.Generic;
using Sources.Frameworks.UiFramework.Domain.Dictionaries;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Frameworks.UiFramework.Domain.Configs.Localizations
{
    [CreateAssetMenu(fileName = "LocalizationConfig", menuName = "Configs/LocalizationConfig", order = 51)]
    public class LocalizationConfig : ScriptableObject
    {
        [SerializeField] private StringSerializedDictionary _russian;
        [SerializeField] private StringSerializedDictionary _english;
        [SerializeField] private StringSerializedDictionary _turkish;
        
        public IReadOnlyDictionary<string, string> Russian => _russian;
        public IReadOnlyDictionary<string, string> English => _english;
        public IReadOnlyDictionary<string, string> Turkish => _turkish;
    }
}