﻿using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using Sources.Frameworks.UiFramework.Domain.Dictionaries;
using Sources.Frameworks.UiFramework.Domain.Localizations.Phrases;
using Unity.VisualScripting;
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
        private void FillIds()
        {
            _localizationIds.Clear();
            _localizationPhrases.ForEach(phrase => _localizationIds.Add(phrase.LocalizationId));
        }

        [Button]
        private void CreateLocalizationPhrase()
        {
            LocalizationPhrase phrase = ScriptableObject.CreateInstance(typeof(LocalizationPhrase)) as LocalizationPhrase;
            
            AssetDatabase.CreateAsset(phrase, 
                "Assets/Resources/Configs/Localizations/LocalizationPhrase.asset");
            AssetDatabase.SaveAssets();
        }
        
        [UsedImplicitly]
        private List<string> GetDropdownValues()
        {
            //TODO как убрать эту ошибку
            return AssetDatabase
                .FindAssets("t:LocalizationConfig")
                .Select(path => AssetDatabase.GUIDToAssetPath(path))
                .Select(path => AssetDatabase.LoadAssetAtPath<LocalizationConfig>(path))
                .ToList()
                .FirstOrDefault()
                .LocalizationIds;
        }
    }
}