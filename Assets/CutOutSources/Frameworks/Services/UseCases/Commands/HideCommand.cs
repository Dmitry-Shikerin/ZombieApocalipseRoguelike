using Sources.Domain.Components;
using Sources.Domain.Components.Visibilities;
using Sources.DomainInterfaces.Components;

namespace Sources.Infrastructure.Services.UseCases.Commands
{
    public class HideCommand : ComponentUseCaseBase<VisibilityComponent>
    {
        public void Handle(IComposite composite) =>
            GetComponent(composite).Hide();
    }
}