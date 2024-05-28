using Sources.App.Core;
using Sources.Infrastructure.Factories.App;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    private AppCore _appCore;

    private void Awake() =>
        _appCore = FindObjectOfType<AppCore>() ?? new AppCoreFactory().Create();
}
