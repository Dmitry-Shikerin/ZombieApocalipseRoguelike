using Sources.Domain.Components.Visibilities;
using Sources.DomainInterfaces.Components;

namespace Sources.Infrastructure.Services.UseCases.Commands
{
    public class ShowCommand : ComponentUseCaseBase<VisibilityComponent>
    {
        public void Handle(IComposite composite) =>
            GetComponent(composite).Show();
    }
}