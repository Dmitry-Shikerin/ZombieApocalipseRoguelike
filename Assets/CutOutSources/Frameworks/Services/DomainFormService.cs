using System;
using System.Collections.Generic;
using System.Linq;
using Sources.DomainInterfaces.Models.Forms;
using Sources.Infrastructure.Services.UseCases.Commands;
using Sources.InfrastructureInterfaces.Services.Forms;

namespace Sources.Infrastructure.Services.Forms
{
    public class DomainFormService : IDomainFormService
    {
        private Dictionary<Type, IFormModel> _forms = new Dictionary<Type, IFormModel>();
        
        private readonly HideCommand _hideCommand;
        private readonly ShowCommand _showCommand;

        public DomainFormService(
            HideCommand hideCommand,
            ShowCommand showCommand)
        {
            _hideCommand = hideCommand ?? throw new ArgumentNullException(nameof(hideCommand));
            _showCommand = showCommand ?? throw new ArgumentNullException(nameof(showCommand));
        }

        public void Show<T>() where T : IFormModel
        {
            if (_forms.ContainsKey(typeof(T)) == false)
                throw new NullReferenceException(nameof(T));

            IFormModel activeForm = _forms[typeof(T)];

            _forms.Values
                .Except(new List<IFormModel>() { activeForm })
                .ToList()
                .ForEach(model => _hideCommand.Handle(model));
            
            _showCommand.Handle(activeForm);
        }

        public void Hide<T>() where T : IFormModel
        {
            if (_forms.ContainsKey(typeof(T)) == false)
                throw new NullReferenceException(nameof(T));

            IFormModel activeFormId = _forms[typeof(T)];
            
            if (activeFormId == default)
                throw new NullReferenceException(nameof(activeFormId));
            
            _hideCommand.Handle(activeFormId);
        }

        public void Register<T>(IFormModel form)
        {
            if (_forms.ContainsKey(typeof(T)))
                throw new InvalidOperationException(nameof(T));

            _forms[typeof(T)] = form;
        }

        public IFormModel Get<T>() where T : IFormModel
        {
            if (_forms.ContainsKey(typeof(T)) == false)
                throw new NullReferenceException(nameof(T));

            return _forms[typeof(T)];
        }
    }
}