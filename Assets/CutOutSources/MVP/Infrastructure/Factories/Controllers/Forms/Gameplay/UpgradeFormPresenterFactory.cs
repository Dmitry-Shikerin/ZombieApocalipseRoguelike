using System;
using Sources.Controllers.Common.Forms;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Forms.Gameplay
{
    public class UpgradeFormPresenterFactory
    {
        private readonly IMVPFormService _imvpFormService;

        public UpgradeFormPresenterFactory(IMVPFormService imvpFormService)
        {
            _imvpFormService = imvpFormService ?? throw new ArgumentNullException(nameof(imvpFormService));
        }

        public UpgradeFormPresenter Create(IUpgradeFormView view)
        {
            return new UpgradeFormPresenter(view, _imvpFormService);
        }
    }
}