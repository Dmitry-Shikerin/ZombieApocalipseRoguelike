using System;
using System.Collections.Generic;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Views.Buttons;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Views.Forms;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Forms;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Forms
{
    public class FormServiceFactoryBase
    {
        private readonly FormButtonViewFactory _formButtonViewFactory;
        private readonly UiContainerFactory _uiContainerFactory;

        protected FormServiceFactoryBase(
            FormButtonViewFactory formButtonViewFactory,
            UiContainerFactory uiContainerFactory)
        {
            _formButtonViewFactory = formButtonViewFactory ??
                                     throw new ArgumentNullException(nameof(formButtonViewFactory));
            _uiContainerFactory = uiContainerFactory ?? throw new ArgumentNullException(nameof(uiContainerFactory));
        }

        protected void CreateFormButtons(IEnumerable<UiButton> formButtons)
        {
            foreach (UiButton formButton in formButtons)
            {
                _formButtonViewFactory.Create(formButton);
            }
        }

        protected void CreateUiContainers(IEnumerable<UiView> containers)
        {
            foreach (UiView container in containers)
            {
                _uiContainerFactory.Create(container);
            }
        }
    }
}