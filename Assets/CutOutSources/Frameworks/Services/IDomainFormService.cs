using Sources.DomainInterfaces.Models.Forms;

namespace Sources.InfrastructureInterfaces.Services.Forms
{
    public interface IDomainFormService
    {
        public void Show<T>() where T : IFormModel;
        public void Hide<T>() where T : IFormModel;
        public IFormModel Get<T>() where T : IFormModel;
    }
}