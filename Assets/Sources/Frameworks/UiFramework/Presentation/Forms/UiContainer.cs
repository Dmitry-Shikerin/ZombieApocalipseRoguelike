﻿using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Presentations.Views;
using Sources.PresentationsInterfaces.Views.Forms.Common;
using UnityEngine;

namespace Sources.Frameworks.UiFramework.Presentation.Forms
{
    public class UiContainer : View, IUiContainer
    {
        [SerializeField] private FormId _formId;
        
        public FormId Id => _formId;
    }
}