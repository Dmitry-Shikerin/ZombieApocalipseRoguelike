using Assets.Sources.PresentationsInterfaces.Views.Forms.Common;

namespace Assets.Sources.InfastructureInterfaces.Services.Forms
{
    public interface IFormService
    {
        void Show<T>()
             where T : IFormView;

        void Show(string formName);

        void Hide<T>()
            where T : IFormView;
    }
}
