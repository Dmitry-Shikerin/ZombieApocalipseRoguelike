using System;
using Sources.Controllers.Common.Forms;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Forms.Gameplay
{
    public class UpgradeFormPresenterFactory
    {
        private readonly IFormService _formService;

        public UpgradeFormPresenterFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public UpgradeFormPresenter Create(IUpgradeFormView view)
        {
            return new UpgradeFormPresenter(view, _formService);
        }
    }
}