using System;
using Sources.Infrastructure.Services.ObjectPools;
using Sources.InfrastructureInterfaces.Services.ObjectPools;
using Sources.PresentationsInterfaces.Views.FirstAidKits;

namespace Sources.Presentations.Views.FirstAidKits
{
    public class FirstAidKitView : View, IFirstAidKitView
    {
        private readonly IPoolableObjectDestroyerService _poolableObjectDestroyerService =
            new PoolableObjectDestroyerService();

        public int HealAmount { get; private set; }

        public override void Destroy() =>
            _poolableObjectDestroyerService.Destroy(this);

        public void SetHealAmount(int healAmount)
        {
            if (healAmount < 0)
                throw new ArgumentOutOfRangeException(nameof(healAmount));

            HealAmount = healAmount;
        }
    }
}