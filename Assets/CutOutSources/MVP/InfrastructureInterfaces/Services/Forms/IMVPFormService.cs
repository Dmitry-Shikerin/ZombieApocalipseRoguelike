using Sources.PresentationsInterfaces.Views.Forms.Common;

namespace Sources.InfrastructureInterfaces.Services.Forms
{
    public interface IMVPFormService
    {
        void Show<T>()
            where T : IUiContainer;

        void Show(string formName);

        void Hide<T>()
            where T : IUiContainer;
    }
}