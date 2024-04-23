using System;
using JetBrains.Annotations;
using Sources.Controllers.Forms.Gameplay;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Controllers.Forms.Gameplay
{
    public class UpgradeFormPresenterFactory
    {
        private readonly IViewFormService _viewFormService;

        public UpgradeFormPresenterFactory(IViewFormService viewFormService)
        {
            _viewFormService = viewFormService ?? throw new ArgumentNullException(nameof(viewFormService));
        }

        public UpgradeFormPresenter Create(IUpgradeFormView upgradeFormView)
        {
            if (upgradeFormView == null)
                throw new ArgumentNullException(nameof(upgradeFormView));

            return new UpgradeFormPresenter(_viewFormService, upgradeFormView);
        }
    }
}