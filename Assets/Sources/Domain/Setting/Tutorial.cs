using Sources.Domain.Data;

namespace Sources.Domain.Setting
{
    public class Tutorial
    {
        public Tutorial(TutorialDto tutorialData)
            : this(tutorialData.HasCompleted)
        {
        }

        public Tutorial()
            : this(false)
        {
        }

        private Tutorial(bool hasCompleted)
        {
            HasCompleted = hasCompleted;
        }

        public bool HasCompleted { get; set; }
    }
}