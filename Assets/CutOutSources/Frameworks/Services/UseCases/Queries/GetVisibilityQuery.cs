using Sources.Domain.Components;
using Sources.Domain.Components.Visibilities;
using Sources.DomainInterfaces.Components;
using Sources.Frameworks.LiveDatas;

namespace Sources.Infrastructure.Services.UseCases.Queries
{
    public class GetVisibilityQuery : ComponentUseCaseBase<VisibilityComponent>
    {
        public LiveData<bool> Handle(IComposite composite) => 
            GetComponent(composite).IsVisible;
    }
}