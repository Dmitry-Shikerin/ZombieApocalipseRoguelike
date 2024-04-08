using System;
using Sources.Domain.Data;
using Sources.Domain.Players;
using Sources.DomainInterfaces.Data;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;

namespace Sources.Infrastructure.Factories.Domain.Data
{
    public class PlayerWalletDtoFactory : IDtoFactory<PlayerWalletDto>
    {
        public PlayerWalletDto Create(IDataModel dataModel)
        {
            if (dataModel is not PlayerWallet playerWallet)
                throw new InvalidOperationException(nameof(dataModel));
            
            return new PlayerWalletDto()
            {
                Coins = playerWallet.Coins
            };
        }
    }
}