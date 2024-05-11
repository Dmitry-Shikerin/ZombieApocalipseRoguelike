using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using Sources.Frameworks.UiFramework.Domain.Dictionaries;
using Sources.Frameworks.UiFramework.Domain.Localizations.Phrases;
using UnityEditor;
using UnityEngine;

namespace Sources.Frameworks.UiFramework.Domain.Localizations.Configs
{
    [CreateAssetMenu(
        fileName = "LocalizationConfigSecond", 
        menuName = "Configs/LocalizationConfigSecond", 
        order = 51)]
    public class LocalizationConfig : ScriptableObject
    {
        [SerializeField] private List<string> _localizationIds;
        [SerializeField] private List<LocalizationPhrase> _localizationPhrases;
        [ValueDropdown("GetDropdownValues")]
        [SerializeField] private StringPhraseSerializedDictionary _localizationPhrase;
        
        public List<string> LocalizationIds => _localizationIds;
        public List<LocalizationPhrase> LocalizationPhrases => _localizationPhrases;
        
        [Button]
        private void AddAllPhrases()
        {
            _localizationPhrases.Clear();
            
            AssetDatabase
                .FindAssets("t:LocalizationPhrase")
                .Select(path => AssetDatabase.GUIDToAssetPath(path))
                .Select(path => AssetDatabase.LoadAssetAtPath<LocalizationPhrase>(path))
                .ToList()
                .ForEach(phrase => _localizationPhrases.Add(phrase));
        }

        [Button]
        private void FillAllPhrases()
        {
            var phrases = AssetDatabase
                .FindAssets("t:LocalizationPhrase")
                .Select(path => AssetDatabase.GUIDToAssetPath(path))
                .Select(path => AssetDatabase.LoadAssetAtPath<LocalizationPhrase>(path))
                .ToList();

            var localizationConfig = AssetDatabase
                .FindAssets("t:LocalizationConfig")
                .Select(path => AssetDatabase.GUIDToAssetPath(path))
                .Select(path => AssetDatabase.LoadAssetAtPath<LocalizationConfig>(path))
                .ToList()
                .FirstOrDefault();
            
            if(localizationConfig == null)
                Debug.Log($"Config not found");

            foreach (var phrase in _localizationPhrase)
            {
                phrase.Value.SetLocalizationId(phrase.Key);
            }
        }
        
        [UsedImplicitly]
        private List<string> GetDropdownValues()
        {
            return AssetDatabase
                .FindAssets("t:LocalizationConfigSecond")
                .Select(path => AssetDatabase.GUIDToAssetPath(path))
                .Select(path => AssetDatabase.LoadAssetAtPath<LocalizationConfig>(path))
                .ToList()
                .FirstOrDefault()
                .LocalizationIds;
        }
    }
}