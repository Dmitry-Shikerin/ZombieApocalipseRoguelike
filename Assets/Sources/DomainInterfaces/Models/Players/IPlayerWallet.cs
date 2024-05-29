using System;

namespace Sources.DomainInterfaces.Models.Players
{
    public interface IPlayerWallet
    {
        event Action CoinsChanged;

        public int Coins { get; }
    }
}