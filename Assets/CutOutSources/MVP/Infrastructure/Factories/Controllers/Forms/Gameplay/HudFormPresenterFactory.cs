using System;
using Sources.Controllers.Presenters.Forms.Gameplay;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Forms.Gameplay
{
    public class HudFormPresenterFactory
    {
        private readonly IMVPFormService _imvpFormService;

        public HudFormPresenterFactory(IMVPFormService imvpFormService)
        {
            _imvpFormService = imvpFormService ?? throw new ArgumentNullException(nameof(imvpFormService));
        }

        public HudFormPresenter Create(IHudFormView view)
        {
            return new HudFormPresenter(view, _imvpFormService);
        }
    }
}