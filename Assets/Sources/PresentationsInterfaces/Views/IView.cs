using UnityEngine;

namespace Assets.Sources.PresentationsInterfaces.Views
{
    public interface IView
    {
        void Show();
        void Hide();
        void SetParent(Transform parent);
    }
}