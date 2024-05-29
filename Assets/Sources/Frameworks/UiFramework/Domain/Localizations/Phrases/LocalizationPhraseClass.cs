using System;
using Sirenix.OdinInspector;
using Sources.Frameworks.UiFramework.Presentation.CommonTypes;
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
    }
}