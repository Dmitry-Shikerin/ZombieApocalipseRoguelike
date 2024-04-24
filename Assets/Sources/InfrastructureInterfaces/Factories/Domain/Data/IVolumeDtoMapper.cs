using Sources.Domain.Data;
using Sources.Domain.Models.Data;
using Sources.Domain.Models.Setting;

namespace Sources.InfrastructureInterfaces.Factories.Domain.Data
{
    public interface IVolumeDtoMapper
    {
        VolumeDto MapModelToDto(Volume volume);
        Volume MapDtoToModel(VolumeDto volumeDto);
    }
}