using System.Collections.Generic;
using Sources.PresentationsInterfaces.UI.Texts;

namespace Sources.PresentationsInterfaces.Views.Localizations
{
    public interface ILocalizationView
    {
        IReadOnlyList<ITextView> Texts { get; }
    }
}