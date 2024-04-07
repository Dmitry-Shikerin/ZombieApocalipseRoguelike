using System;
using Sources.DomainInterfaces.Upgrades;

namespace Sources.Domain.Upgrades
{
    public class Upgrader : IUpgrader
    {
        private float _startAmount;

        public Upgrader(
            float startAmount,
            int maxLevel,
            int currentLevel,
            float addedAmount)
        {
            _startAmount = startAmount;
            MaxLevel = maxLevel;
            CurrentLevel = currentLevel;
            AddedAmount = addedAmount;
        }

        public event Action LevelChanged;

        public float CurrentAmount => _startAmount + CurrentLevel * AddedAmount;
        public int CurrentLevel { get; private set; }
        public int MaxLevel { get; }
        public float AddedAmount { get; }

        public void Upgrade()
        {
            if (CurrentLevel >= MaxLevel)
                return;

            CurrentLevel++;
            LevelChanged?.Invoke();
        }
    }
}