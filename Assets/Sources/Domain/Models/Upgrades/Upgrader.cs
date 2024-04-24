﻿using System;
using System.Collections.Generic;
using Sources.Domain.Models.Players;
using Sources.DomainInterfaces.Entities;
using Sources.DomainInterfaces.Upgrades;

namespace Sources.Domain.Models.Upgrades
{
    public class Upgrader : IUpgrader, IEntity
    {
        
        public Upgrader(
            float startAmount,
            int currentLevel,
            float addedAmount,
            List<int> moneyPerUpgrades,
            string id)
        {
            StartAmount = startAmount;
            CurrentLevel = currentLevel;
            AddedAmount = addedAmount;
            MoneyPerUpgrades = moneyPerUpgrades;
            Id = id;
        }

        public event Action LevelChanged;

        public IReadOnlyList<int> MoneyPerUpgrades { get; }
        public string Id { get; }
        public Type Type => GetType();
        public float CurrentAmount => StartAmount + CurrentLevel * AddedAmount;
        public float StartAmount { get; }
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