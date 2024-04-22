﻿using Sources.Domain.Data;
using Sources.Domain.Setting;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;

namespace Sources.Infrastructure.Factories.Domain.Data
{
    public class TutorialDtoMapper : ITutorialDtoMapper
    {
        public TutorialDto MapModelToDto(Tutorial tutorial)
        {
            return new TutorialDto()
            {
                Id = tutorial.Id,
                HasCompleted = tutorial.HasCompleted,
            };
        }

        public Tutorial MapDtoToModel(TutorialDto tutorialDto)
        {
            return new Tutorial(tutorialDto);
        }
    }
}