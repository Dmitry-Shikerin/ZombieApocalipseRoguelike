using Sources.Controllers.Characters.Healths;
using Sources.PresentationsInterfaces.Views.Character;

namespace Sources.Presentations.Views.Characters
{
    public class CharacterHealthView : PresentableView<CharacterHealthPresenter>, ICharacterHealthView
    {
        public void TakeDamage(int damage)
        {
            Presenter.TakeDamage(damage);
        }
    }
}