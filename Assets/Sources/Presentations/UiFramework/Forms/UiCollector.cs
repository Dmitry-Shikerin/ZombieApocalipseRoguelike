using System.Collections.Generic;
using Sources.Presentation.Ui.Buttons;
using Sources.Presentations.Views;
using UnityEngine;

namespace Sources.Presentation.Views.Forms
{
    [DefaultExecutionOrder(-1)]
    public class UiCollector : View
    {
        public IReadOnlyList<FormButtonView> Buttons { get; private set; }
        public IReadOnlyList<FormView> Forms { get; private set; }

        private void Awake()
        {
            Buttons = GetComponentsInChildren<FormButtonView>(true);
            Forms = GetComponentsInChildren<FormView>(true);
        }
    }
}