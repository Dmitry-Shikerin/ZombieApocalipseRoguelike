using Sources.Domain.Data;
using Sources.Domain.Setting;

namespace Sources.InfrastructureInterfaces.Factories.Domain.Data
{
    public interface ITutorialDtoMapper
    {
        TutorialDto MapModelToDto(Tutorial tutorial);
        Tutorial MapDtoToModel(TutorialDto tutorialDto);
    }
}