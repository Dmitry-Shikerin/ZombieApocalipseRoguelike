using System;
using System.Collections.Generic;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Views.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Buttons.Types;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Forms
{
    public class FormServiceFactoryBase
    {
        private readonly CustomFormButtonViewFactory _customFormButtonViewFactory;
        private readonly FormButtonViewFactory _formButtonViewFactory;

        protected FormServiceFactoryBase(
            CustomFormButtonViewFactory customFormButtonViewFactory,
            FormButtonViewFactory formButtonViewFactory)
        {
            _customFormButtonViewFactory = customFormButtonViewFactory ?? 
                                           throw new ArgumentNullException(nameof(customFormButtonViewFactory));
            _formButtonViewFactory = formButtonViewFactory ?? 
                                     throw new ArgumentNullException(nameof(formButtonViewFactory));
        }

        protected void CreateFormButtons(IEnumerable<UiFormButton> formButtons)
        {
            foreach (UiFormButton formButton in formButtons)
            {
                if (formButton.ButtonType == ButtonType.Default)
                    _formButtonViewFactory.Create(formButton);
                else if (formButton.ButtonType == ButtonType.Custom)
                    _customFormButtonViewFactory.Create(formButton);
            }
        }
    }
}