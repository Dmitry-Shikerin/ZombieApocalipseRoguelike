namespace Sources.PresentationsInterfaces.Views.RewardItems
{
    public interface IRewardItemView : IView
    {
        int RewardAmount { get; }

        void SetRewardAmount(int rewardAmount);
    }
}