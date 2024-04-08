using Sources.PresentationsInterfaces.UI.Texts;

namespace Sources.InfrastructureInterfaces.Services.Localizations.Translates.Common
{
    public interface ITranslateService
    {
        void Translate(ITextView textView);
    }
}