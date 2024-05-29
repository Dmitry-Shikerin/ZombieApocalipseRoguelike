using System;
using Sources.DomainInterfaces.Models.Upgrades;

namespace Sources.Domain.Models.Upgrades.Controllers
{
    public class UpgradeController : IUpgradeController
    {
        public event Action UpgradeFormShowed;

        public void ShowUpgradeForm() =>
            UpgradeFormShowed?.Invoke();
    }
}