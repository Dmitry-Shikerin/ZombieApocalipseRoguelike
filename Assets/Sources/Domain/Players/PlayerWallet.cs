using System;
using Sources.DomainInterfaces.Data;
using Sources.DomainInterfaces.Entities;
using Sources.DomainInterfaces.Players;

namespace Sources.Domain.Players
{
    public class PlayerWallet : IPlayerWallet, IEntity
    {
        public PlayerWallet(
            int coins,
            string id)
        {
            Coins = coins;
            Id = id;
        }
        
        public event Action CoinsChanged;

        public string Id { get; }
        public Type Type => GetType();
        public int Coins { get; private set; }

        public void AddCoins(int amount)
        {
            Coins += amount;
            CoinsChanged?.Invoke();
        }

        public bool TryRemoveCoins(int amount)
        {
            if (Coins < amount)
                return false;
            
            Coins -= amount;
            CoinsChanged?.Invoke();
            return true;
        }
    }
}