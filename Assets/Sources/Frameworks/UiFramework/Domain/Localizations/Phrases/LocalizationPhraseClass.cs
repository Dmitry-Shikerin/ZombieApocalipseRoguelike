using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using Sources.Frameworks.UiFramework.Domain.Localizations.Configs;
using Sources.Frameworks.UiFramework.Presentation.CommonTypes;
using UnityEditor;
using UnityEngine;

namespace Sources.Frameworks.UiFramework.Domain.Localizations.Phrases
{
    [Serializable]
    public class LocalizationPhraseClass
    {
                [ValueDropdown("GetDropdownValues")]
        [SerializeField] private string _localizationId;
        [SerializeField] private string _textId;
        
        [FoldoutGroup("Russian")] [EnumToggleButtons]
        [SerializeField] private Enable _editRussian;
        [FoldoutGroup("Russian")][TextArea(1, 20)] 
        [EnableIf("_editRussian", Enable.Enable)]
        [SerializeField] private string _russian;
        
        [FoldoutGroup("English")] [EnumToggleButtons]
        [SerializeField] private Enable _editEnglish;
        [EnableIf("_editEnglish", Enable.Enable)]
        [FoldoutGroup("English")][TextArea(1, 20)]
        [SerializeField] private string _english;
        
        [FoldoutGroup("Turkish")] [EnumToggleButtons]
        [SerializeField] private Enable _editTurkish;
        [EnableIf("_editTurkish", Enable.Enable)]
        [FoldoutGroup("Turkish")][TextArea(1, 20)]
        [SerializeField] private string _turkish;

        public string LocalizationId => _localizationId;
        
        public void SetRussian(string russian) => _russian = russian;
        public void SetEnglish(string english) => _english = english;
        public void SetTurkish(string turkish) => _turkish = turkish;
        public void SetLocalizationId(string localizationId) => _localizationId = localizationId;
        
        // [Button(ButtonSizes.Large)]
        // private void ChangeName()
        // {
        //     if(string.IsNullOrWhiteSpace(_localizationId))
        //         return;
        //     
        //     string path = AssetDatabase.GetAssetPath(this);
        //     AssetDatabase.RenameAsset(path, _localizationId);
        // }
        
        [Button(ButtonSizes.Large)]
        private void AddTextId()
        {
            var localizationIds = AssetDatabase
                .FindAssets("t:LocalizationConfigSecond")
                .Select(path => AssetDatabase.GUIDToAssetPath(path))
                .Select(path => AssetDatabase.LoadAssetAtPath<LocalizationConfig>(path))
                .ToList()
                .FirstOrDefault()
                .LocalizationIds;

            if(localizationIds.Contains(_textId))
                return;
            
            localizationIds.Add(_textId);
            
            _textId = "";
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