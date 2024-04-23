using System;
using Sources.Controllers.Forms.Gameplay;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Controllers.Forms.Gameplay
{
    public class HudFormPresenterFactory
    {
        private readonly IViewFormService _viewFormService;

        public HudFormPresenterFactory(IViewFormService viewFormService)
        {
            _viewFormService = viewFormService ?? throw new ArgumentNullException(nameof(viewFormService));
        }

        public HudFormPresenter Create(IHudFormView hudFormView)
        {
            if (hudFormView == null) 
                throw new ArgumentNullException(nameof(hudFormView));

            return new HudFormPresenter(_viewFormService, hudFormView);
        }
    }
}