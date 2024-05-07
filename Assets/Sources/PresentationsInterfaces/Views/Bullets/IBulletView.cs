using Sources.Presentations.Views.Bullets;
using Sources.PresentationsInterfaces.Views.Constructors;
using Sources.PresentationsInterfaces.Views.Weapons;

namespace Sources.PresentationsInterfaces.Views.Bullets
{
    public interface IBulletView : IConstruct<IMiniGunView>, IView
    {
    }
}