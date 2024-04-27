using System;
using Sources.Domain.Components.Visibilities;
using Sources.Domain.Models.Forms.MainMenu;
using Sources.InfrastructureInterfaces.Services.Forms;

namespace Sources.Infrastructure.Factories.Domain.Forms.MainMenu
{
    public class LeaderboardFormFactory
    {
        public LeaderboardForm Create()
        {
            LeaderboardForm form = new LeaderboardForm();
            form.AddComponent(new VisibilityComponent(true));

            return form;
        }
    }
}