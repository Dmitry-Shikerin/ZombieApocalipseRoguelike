using System;
using System.Collections.Generic;
using Sources.Domain.Data.Common;
using Sources.Domain.Players;
using Sources.Domain.Upgrades.Configs;
using Sources.DomainInterfaces.Data;
using Sources.DomainInterfaces.Entities;
using Sources.DomainInterfaces.Upgrades;

namespace Sources.Domain.Upgrades
{
    public class Upgrader : IUpgrader, IEntity
    {
        private float _startAmount;

        public Upgrader(
            UpgradeConfig upgradeConfig,
            UpgradeDto upgradeDto)
            : this(
            upgradeConfig.StartAmount,
            upgradeDto.CurrentLevel,
            upgradeConfig.AddedAmount,
            upgradeConfig.MoneyPerUpgrades,
            upgradeConfig.Id)
        {
        }
        
        public Upgrader(UpgradeConfig upgradeConfig) 
            : this(
            upgradeConfig.StartAmount,
            0,
            upgradeConfig.AddedAmount,
            upgradeConfig.MoneyPerUpgrades,
            upgradeConfig.Id)
        {
        }
        
        private Upgrader(
            float startAmount,
            int currentLevel,
            float addedAmount,
            List<int> moneyPerUpgrades,
            string id)
        {
            _startAmount = startAmount;
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
        public int MaxLevel => MoneyPerUpgrades.Count;
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