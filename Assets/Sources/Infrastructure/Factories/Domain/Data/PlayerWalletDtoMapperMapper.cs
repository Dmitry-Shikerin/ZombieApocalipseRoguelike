using System;
using Sources.Domain.Data;
using Sources.Domain.Players;
using Sources.DomainInterfaces.Data;
using Sources.DomainInterfaces.Players;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;

namespace Sources.Infrastructure.Factories.Domain.Data
{
    public class PlayerWalletDtoMapperMapper : IPlayerWalletDtoMapper
    {
        public PlayerWalletDto MapTo(PlayerWallet playerWallet)
        {
            return new PlayerWalletDto()
            {
                Coins = playerWallet.Coins
            };
        }
    }
}