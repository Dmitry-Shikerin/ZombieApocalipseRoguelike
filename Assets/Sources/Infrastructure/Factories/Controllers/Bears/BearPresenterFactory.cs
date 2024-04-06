using System;
using Sources.Controllers.Bears;
using Sources.Controllers.Bears.Movements;
using Sources.Controllers.Bears.Movements.States;
using Sources.Domain.Bears;
using Sources.Infrastructure.Services.Overlaps;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.Presentations.Views.Bears;
using Sources.PresentationsInterfaces.Views.Bears;

namespace Sources.Infrastructure.Factories.Controllers.Bears
{
    public class BearPresenterFactory
    {
        private readonly IUpdateRegister _updateRegister;
        private readonly OverlapService _overlapService;

        public BearPresenterFactory(
            IUpdateRegister updateRegister,
            OverlapService overlapService)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
            _overlapService = overlapService ?? throw new ArgumentNullException(nameof(overlapService));
        }

        public BearPresenter Create(Bear bear, IBearView bearView, IBearAnimationView bearAnimationView)
        {
            BearIdleState idleState = new BearIdleState(bearView, bearAnimationView, _overlapService);
            
            return new BearPresenter(idleState, _updateRegister);
        }
    }
}