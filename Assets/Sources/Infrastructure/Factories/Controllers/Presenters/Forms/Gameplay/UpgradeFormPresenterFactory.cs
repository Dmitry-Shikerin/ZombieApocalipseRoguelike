using System;
using JetBrains.Annotations;
using Sources.Controllers.Forms.Gameplay;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Controllers.Forms.Gameplay
{
    public class UpgradeFormPresenterFactory
    {
        private readonly IFormService _formService;

        public UpgradeFormPresenterFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public UpgradeFormPresenter Create(IUpgradeFormView upgradeFormView)
        {
            if (upgradeFormView == null)
                throw new ArgumentNullException(nameof(upgradeFormView));

            return new UpgradeFormPresenter(_formService, upgradeFormView);
        }
    }
}