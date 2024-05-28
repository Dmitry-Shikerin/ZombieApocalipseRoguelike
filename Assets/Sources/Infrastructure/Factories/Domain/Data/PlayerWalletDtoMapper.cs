using Sources.Domain.Models.Data;
using Sources.Domain.Models.Players;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;

namespace Sources.Infrastructure.Factories.Domain.Data
{
    public class PlayerWalletDtoMapper : IPlayerWalletDtoMapper
    {
        public PlayerWalletDto MapModelToDto(PlayerWallet playerWallet)
        {
            return new PlayerWalletDto()
            {
                Coins = playerWallet.Coins,
                Id = playerWallet.Id,
            };
        }

        public PlayerWallet MapDtoToModel(PlayerWalletDto playerWalletDto) =>
            new(playerWalletDto);
    }
}