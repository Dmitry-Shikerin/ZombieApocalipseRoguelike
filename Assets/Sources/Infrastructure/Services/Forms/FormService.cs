using Assets.Sources.InfastructureInterfaces.Services.Forms;
using Assets.Sources.PresentationsInterfaces.Views.Forms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Presentations.Views;

namespace Assets.Sources.Infrastructure.Services.Forms
{
    public class FormService : IFormService
    {
        private readonly ContainerView _containerView;
        private readonly Dictionary<string, IForm> _forms = new ();

        public FormService(ContainerView containerView)
        {
            _containerView = containerView
                ? containerView
                : throw new ArgumentNullException(nameof(containerView));
        }

        public void Hide<T>() where T : IFormView
        {
            string name = typeof(T).Name;

            if (_forms.ContainsKey(name) == false)
                throw new NullReferenceException(nameof(name));

            IForm activeForm = _forms[name];

            if(activeForm == null)
                throw new NullReferenceException(nameof(activeForm));

            activeForm.Hide();
        }

        public void Show<T>()
            where T : IFormView =>
            Show(typeof(T).Name);


        public void Show(string formName)
        {
            if (_forms.ContainsKey(formName) == false)
                throw new NullReferenceException(nameof(formName));

            IForm activeForm = _forms[formName];

            _forms.Values
                .Except(new List<IForm> { activeForm, })
                .ToList()
                .ForEach(form => form.Hide());

            activeForm.Show();
        }

        public void Add(IForm form, string name = null, bool isSetParent = false)
        {
            if (isSetParent)
                _containerView.AppendChild(form);

            _forms.Add(name ?? form.Name, form);
            form.Hide();
        }
    }
}