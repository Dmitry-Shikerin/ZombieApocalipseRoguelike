namespace Sources.Domain.Players
{
    public class PlayerWallet
    {
        public PlayerWallet(int coins)
        {
            Coins = coins;
        }

        public int Coins { get; private set; }
        
        public void AddCoins(int amount) =>
            Coins += amount;

        public bool TryRemoveCoins(int amount)
        {
            if (Coins < amount)
                return false;
            
            Coins -= amount;
            return true;
        }
    }
}