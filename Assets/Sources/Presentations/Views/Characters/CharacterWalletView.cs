using Sources.Controllers.Presenters.Characters;
using Sources.Presentations.Triggers;
using Sources.PresentationsInterfaces.Views.Character;
using Sources.PresentationsInterfaces.Views.RewardItems;
using UnityEngine;

namespace Sources.Presentations.Views.Characters
{
    public class CharacterWalletView : PresentableView<CharacterWalletPresenter>, ICharacterWalletView
    {
        [SerializeField] private RewardItemTrigger _rewardItemTrigger;
        
        public Vector3 Position => transform.position;

        protected override void OnAfterEnable() =>
            _rewardItemTrigger.Entered += OnEnter;

        protected override void OnAfterDisable() =>
            _rewardItemTrigger.Entered -= OnEnter;

        private void OnEnter(IRewardItemView rewardItemView) =>
            Presenter.AddRewardItem(rewardItemView);
    }
}