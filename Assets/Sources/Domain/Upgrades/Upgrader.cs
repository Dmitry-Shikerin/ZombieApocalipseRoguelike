using System;
using System.Collections.Generic;
using Sources.Domain.Players;
using Sources.DomainInterfaces.Data;
using Sources.DomainInterfaces.Entities;
using Sources.DomainInterfaces.Upgrades;

namespace Sources.Domain.Upgrades
{
    public class Upgrader : IUpgrader, IEntity
    {
        private float _startAmount;

        public Upgrader(
            float startAmount,
            int maxLevel,
            int currentLevel,
            float addedAmount,
            List<int> moneyPerUpgrades,
            string id)
        {
            _startAmount = startAmount;
            MaxLevel = maxLevel;
            CurrentLevel = currentLevel;
            AddedAmount = addedAmount;
            MoneyPerUpgrades = moneyPerUpgrades;
            Id = id;
        }

        public event Action LevelChanged;

        public IReadOnlyList<int> MoneyPerUpgrades { get; }
        public string Id { get; }
        public Type Type => GetType();
        public float CurrentAmount => _startAmount + CurrentLevel * AddedAmount;
        public int CurrentLevel { get; private set; }
        public int MaxLevel { get; }
        public float AddedAmount { get; }


        public void Upgrade(PlayerWallet wallet)
        {
            if (CurrentLevel >= MaxLevel)
                return;
            
            if(wallet.TryRemoveCoins(MoneyPerUpgrades[CurrentLevel]) == false)
                return;
            
            CurrentLevel++;
            LevelChanged?.Invoke();
        }
    }
}