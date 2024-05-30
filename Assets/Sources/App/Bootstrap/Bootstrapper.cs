using Sources.App.Core;
using Sources.Infrastructure.Factories.App;
using UnityEngine;

namespace Sources.App.Bootstrap
{
    public class Bootstrapper : MonoBehaviour
    {
        private void Awake()
        {
            AppCore appCore = FindObjectOfType<AppCore>();

            if (appCore == null)
                new AppCoreFactory().Create();
        }
    }
}
