using System.Collections.Generic;
using Sources.Domain.Localizations;
using Sources.PresentationsInterfaces.UI.Texts;
using Sources.PresentationsInterfaces.Views.Localizations;
using UnityEngine;

namespace Sources.Presentations.Views.Localizations
{
    public class LocalizationView : View, ILocalizationView
    {
        [SerializeField] private Localization _localization;
        
        public Localization Localization => _localization;
        public IReadOnlyList<ITextView> Texts { get; private set; }
        
        private void Awake() =>
            Texts = GetComponentsInChildren<ITextView>(true);
    }
}