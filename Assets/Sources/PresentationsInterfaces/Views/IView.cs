using UnityEngine;

namespace Sources.PresentationsInterfaces.Views
{
    public interface IView
    {
        void Show();
        void Hide();
        void SetParent(Transform parent);
        void SetLocalePosition(Vector3 position);
        void SetPosition(Vector3 position);
    }
}