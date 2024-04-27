﻿using Sources.ControllersInterfaces;
using Sources.Presentations.UiFramework.Forms.Types;
using Sources.PresentationsInterfaces.Views.Forms.Common;

namespace Sources.Presentations.Views.Forms.Common
{
    public class FormBase<T> : PresentableView<T>, IUiContainer
        where T : IPresenter
    {
        public FormId Id { get; }
    }
}