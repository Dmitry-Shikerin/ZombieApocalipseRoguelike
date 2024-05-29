using Sources.Domain.Models.Data;
using Sources.Domain.Models.Players;

namespace Sources.InfrastructureInterfaces.Factories.Domain.Data
{
    public interface IPlayerWalletDtoMapper
    {
        PlayerWalletDto MapModelToDto(PlayerWallet playerWallet);

        PlayerWallet MapDtoToModel(PlayerWalletDto playerWalletDto);
    }
}