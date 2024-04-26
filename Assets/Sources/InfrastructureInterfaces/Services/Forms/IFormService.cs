﻿using Sources.PresentationsInterfaces.Views.Forms.Common;

namespace Sources.InfrastructureInterfaces.Services.Forms
{
    public interface IFormService
    {
        void Show<T>()
            where T : IFormView;

        void Show(string formName);

        void Hide<T>()
            where T : IFormView;
    }
}