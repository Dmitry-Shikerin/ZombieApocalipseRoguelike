using System;
using Sources.Domain.Data;
using Sources.Domain.Players;
using Sources.DomainInterfaces.Data;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;

namespace Sources.Infrastructure.Factories.Domain.Data
{
    public class PlayerWalletDtoMapper : IDtoMapper<PlayerWalletDto, PlayerWallet>
    {
        public PlayerWalletDto MapTo(PlayerWallet playerWallet)
        {
            // if (dataModel is not PlayerWallet playerWallet)
            //     throw new InvalidOperationException(nameof(dataModel));
            //
            return new PlayerWalletDto()
            {
                Coins = playerWallet.Coins
            };
        }
    }
}