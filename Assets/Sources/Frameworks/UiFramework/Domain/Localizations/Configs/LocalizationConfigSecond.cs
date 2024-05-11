using System.Collections.Generic;
using Sources.Frameworks.UiFramework.Domain.Localizations.Phrases;
using UnityEngine;

namespace Sources.Frameworks.UiFramework.Domain.Localizations.Configs
{
    [CreateAssetMenu(
        fileName = "LocalizationConfigSecond", 
        menuName = "Configs/LocalizationConfigSecond", 
        order = 51)]
    public class LocalizationConfigSecond : ScriptableObject
    {
        [SerializeField] private List<LocalizationPhrase> _localizationPhrases;
    }
}