using Sources.Domain.Data;
using Sources.Domain.Models.Data;
using Sources.Domain.Models.Setting;

namespace Sources.InfrastructureInterfaces.Factories.Domain.Data
{
    public interface ITutorialDtoMapper
    {
        TutorialDto MapModelToDto(Tutorial tutorial);
        Tutorial MapDtoToModel(TutorialDto tutorialDto);
    }
}