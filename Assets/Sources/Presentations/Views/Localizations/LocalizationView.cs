using System.Collections.Generic;
using Sources.PresentationsInterfaces.UI.Texts;
using Sources.PresentationsInterfaces.Views.Localizations;

namespace Sources.Presentations.Views.Localizations
{
    public class LocalizationView : View, ILocalizationView
    {
        public IReadOnlyList<ITextView> Texts { get; private set; }
        
        private void Awake() =>
            Texts = GetComponentsInChildren<ITextView>(true);
    }
}