using System;
using System.Collections.Generic;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Views.Buttons;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Views.Forms;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Forms;
using Sources.Presentations.UI.Huds;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Forms
{
    public class UiCollectorFactory
    {
        private readonly FormButtonViewFactory _formButtonViewFactory;
        private readonly UiContainerFactory _uiContainerFactory;
        private readonly IHud _hud;

        protected UiCollectorFactory(
            FormButtonViewFactory formButtonViewFactory,
            UiContainerFactory uiContainerFactory,
            IHud hud)
        {
            _formButtonViewFactory = formButtonViewFactory ??
                                     throw new ArgumentNullException(nameof(formButtonViewFactory));
            _uiContainerFactory = uiContainerFactory ?? throw new ArgumentNullException(nameof(uiContainerFactory));
            _hud = hud ?? throw new ArgumentNullException(nameof(hud));
        }

        public void Create()
        {
            CreateFormButtons(_hud.UiCollector.UiFormButtons);
            CreateUiContainers(_hud.UiCollector.UiContainers);
        }

        private void CreateFormButtons(IEnumerable<UiButton> formButtons)
        {
            foreach (UiButton formButton in formButtons)
            {
                _formButtonViewFactory.Create(formButton);
            }
        }

        private void CreateUiContainers(IEnumerable<UiView> containers)
        {
            foreach (UiView container in containers)
            {
                _uiContainerFactory.Create(container);
            }
        }
    }
}