using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Characters.Healths;
using Sources.Presentations.Triggers;
using Sources.PresentationsInterfaces.Views.Character;
using Sources.PresentationsInterfaces.Views.FirstAidKits;
using UnityEngine;

namespace Sources.Presentations.Views.Characters
{
    public class CharacterHealthView : PresentableView<CharacterHealthPresenter>, ICharacterHealthView
    {
        [Required] [SerializeField] private ParticleSystem _healParticleSystem;
        [Required] [SerializeField] private FirstAidKitTrigger _firstAidKitTrigger;
        
        
        public void TakeDamage(int damage) =>
            Presenter.TakeDamage(damage);

        public void PlayHealParticle() =>
            _healParticleSystem.Play();

        protected override void OnAfterEnable() =>
            _firstAidKitTrigger.Entered += OnEnter;

        protected override void OnAfterDisable() =>
            _firstAidKitTrigger.Entered -= OnEnter;

        private void OnEnter(IFirstAidKitView firstAidKitView) =>
            Presenter.TakeHeal(firstAidKitView);
    }
}