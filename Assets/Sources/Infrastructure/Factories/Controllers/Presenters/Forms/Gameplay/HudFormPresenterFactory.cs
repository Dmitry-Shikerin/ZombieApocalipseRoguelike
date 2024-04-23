using System;
using Sources.Controllers.Forms.Gameplay;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Controllers.Forms.Gameplay
{
    public class HudFormPresenterFactory
    {
        private readonly IFormService _formService;

        public HudFormPresenterFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public HudFormPresenter Create(IHudFormView hudFormView)
        {
            if (hudFormView == null) 
                throw new ArgumentNullException(nameof(hudFormView));

            return new HudFormPresenter(_formService, hudFormView);
        }
    }
}