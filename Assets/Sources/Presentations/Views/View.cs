using Sources.PresentationsInterfaces.Views;
using UnityEngine;

namespace Sources.Presentations.Views
{
    public abstract class View : MonoBehaviour, IView
    {
        public void Show() =>
            gameObject.SetActive(true);

        public void Hide() =>
            gameObject.SetActive(false);

        public void SetParent(Transform parent) =>
            gameObject.transform.SetParent(parent);
    }
}