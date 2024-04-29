using System;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.ButtonServices.Controllers
{
    public class LeaderBoardButtonClickService : ICustomButtonClickService
    {
        private readonly IFormService _formService;

        public LeaderBoardButtonClickService(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public void Enable(UiButton button)
        {
        }

        public void Disable(UiButton button)
        {
        }

        public void OnClick(UiButton button)
        {
            //TODO добавить логику авторизации
            _formService.Show(FormId.Leaderboard);
        }
    }
}