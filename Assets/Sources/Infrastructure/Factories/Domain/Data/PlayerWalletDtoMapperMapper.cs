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
        public PlayerWalletDto MapModelToDto(PlayerWallet playerWallet)
        {
            return new PlayerWalletDto()
            {
                Coins = playerWallet.Coins
            };
        }

        public PlayerWallet MapDtoToModel(PlayerWalletDto playerWalletDto)
        {
            return new PlayerWallet(playerWalletDto);
        }
    }
}