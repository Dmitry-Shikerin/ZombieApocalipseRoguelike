using System.Collections.Generic;
using Sources.Domain.Models.Localizations;
using Sources.PresentationsInterfaces.UI.Texts;
using Sources.PresentationsInterfaces.Views.Localizations;
using UnityEngine;

namespace Sources.Presentations.Views.Localizations
{
    public class UiLocalization : View, ILocalizationView
    {
        [SerializeField] private Localization _localization;
        
        public Localization Localization => _localization;
        public IReadOnlyList<IUiText> Texts { get; private set; }
        
        private void Awake() =>
            Texts = GetComponentsInChildren<IUiText>(true);
    }
}