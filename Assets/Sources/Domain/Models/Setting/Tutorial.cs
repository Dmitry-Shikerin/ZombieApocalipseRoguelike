using System;
using Sources.Domain.Data;
using Sources.Domain.Models.Data.Ids;
using Sources.DomainInterfaces.Entities;

namespace Sources.Domain.Setting
{
    public class Tutorial : IEntity
    {
        public Tutorial(TutorialDto tutorialDto)
            : this(tutorialDto.Id, tutorialDto.HasCompleted)
        {
        }

        public Tutorial()
            : this(ModelId.Tutorial, false)
        {
        }

        private Tutorial(string id, bool hasCompleted)
        {
            Id = id;
            HasCompleted = hasCompleted;
        }

        public bool HasCompleted { get; set; }
        public string Id { get; }
        public Type Type => GetType();
    }
}