using Sources.Domain.Data;
using Sources.Domain.Players;

namespace Sources.InfrastructureInterfaces.Factories.Domain.Data
{
    public interface IPlayerWalletDtoMapper
    {
        PlayerWalletDto MapTo(PlayerWallet playerWallet);
    }
}