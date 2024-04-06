﻿using System;
using Sources.ControllersInterfaces;
using Sources.PresentationsInterfaces.Views.Forms.Common;
using UnityEngine;

namespace Sources.Presentations.Views.Forms.Common
{
    public class Form<TFormView, TFormPresenter> : IForm
        where TFormView : FormBase<TFormPresenter>
        where TFormPresenter : IPresenter
    {
        private readonly TFormView _formView;

        public Form(Func<TFormView, TFormPresenter> presenterFactory, TFormView formView)
        {
            _formView = formView ? formView : throw new ArgumentNullException(nameof(formView));

            var formPresenter = presenterFactory.Invoke(_formView);

            _formView.Construct(formPresenter);

            Name = _formView.GetType().Name;
        }

        public string Name { get; }

        public void Show() =>
            _formView.Show();

        public void Hide() =>
            _formView.Hide();

        public void SetParent(Transform parent) =>
            _formView.SetParent(parent);
    }
}