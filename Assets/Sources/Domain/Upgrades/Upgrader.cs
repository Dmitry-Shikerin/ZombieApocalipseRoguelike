using System;
using System.Collections.Generic;
using Sources.Domain.Players;
using Sources.DomainInterfaces.Data;
using Sources.DomainInterfaces.Upgrades;

namespace Sources.Domain.Upgrades
{
    public class Upgrader : IUpgrader, IDataModel
    {
        private float _startAmount;

        public Upgrader(
            float startAmount,
            int maxLevel,
            int currentLevel,
            float addedAmount,
            string id)
        {
            _startAmount = startAmount;
            MaxLevel = maxLevel;
            CurrentLevel = currentLevel;
            AddedAmount = addedAmount;
            Id = id;
        }

        public event Action LevelChanged;

        public IReadOnlyList<int> MoneyPerUpgrades { get; } = new List<int>();
        public string Id { get; }
        public float CurrentAmount => _startAmount + CurrentLevel * AddedAmount;
        public int CurrentLevel { get; private set; }
        public int MaxLevel { get; }
        public float AddedAmount { get; }


        public void Upgrade(PlayerWallet wallet)
        {
            if (CurrentLevel >= MaxLevel)
                return;
            
            if(wallet.TryRemoveCoins(MoneyPerUpgrades[CurrentLevel + 1]) == false)
                return;
            
            CurrentLevel++;
            LevelChanged?.Invoke();
        }
    }
}