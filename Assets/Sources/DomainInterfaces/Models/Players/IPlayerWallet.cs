using System;

namespace Sources.DomainInterfaces.Players
{
    public interface IPlayerWallet
    {
        event Action CoinsChanged;
        
        public int Coins { get; }
    }
}