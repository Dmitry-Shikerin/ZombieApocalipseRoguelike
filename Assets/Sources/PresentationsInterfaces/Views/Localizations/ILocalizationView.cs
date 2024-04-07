using System.Collections.Generic;
using Sources.Domain.Localizations;
using Sources.PresentationsInterfaces.UI.Texts;

namespace Sources.PresentationsInterfaces.Views.Localizations
{
    public interface ILocalizationView
    {
        Localization Localization { get; }
        IReadOnlyList<ITextView> Texts { get; }
    }
}