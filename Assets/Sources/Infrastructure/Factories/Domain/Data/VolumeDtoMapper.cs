using Sources.Domain.Data;
using Sources.Domain.Models.Data;
using Sources.Domain.Models.Setting;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;

namespace Sources.Infrastructure.Factories.Domain.Data
{
    public class VolumeDtoMapper : IVolumeDtoMapper
    {
        public VolumeDto MapModelToDto(Volume volume)
        {
            return new VolumeDto()
            {
                VolumeValue = volume.VolumeValue,
                Id = volume.Id,
            };
        }

        public Volume MapDtoToModel(VolumeDto volumeDto)
        {
            return new Volume(volumeDto);
        }
    }
}