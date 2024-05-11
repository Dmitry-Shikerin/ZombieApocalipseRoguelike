using Sirenix.OdinInspector;
using Sources.Frameworks.UiFramework.Presentation.CommonTypes;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Frameworks.UiFramework.Domain.Localizations.Phrases
{
    [CreateAssetMenu(fileName = "LocalizationPhrase", menuName = "Configs/LocalizationPhrase", order = 51)]
    public class LocalizationPhrase : ScriptableObject
    {
        [SerializeField] private string _id;
        
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