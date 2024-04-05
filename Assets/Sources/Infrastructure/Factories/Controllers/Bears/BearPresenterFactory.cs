using System;
using Sources.Controllers.Bears;
using Sources.Controllers.Bears.States;
using Sources.Domain.Bears;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.Presentations.Views.Bears;

namespace Sources.Infrastructure.Factories.Controllers.Bears
{
    public class BearPresenterFactory
    {
        private readonly IUpdateRegister _updateRegister;

        public BearPresenterFactory(IUpdateRegister updateRegister)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
        }

        public BearPresenter Create(Bear bear, IBearView bearView)
        {
            BearIdleState idleState = new BearIdleState();
            
            return new BearPresenter(idleState, _updateRegister);
        }
    }
}