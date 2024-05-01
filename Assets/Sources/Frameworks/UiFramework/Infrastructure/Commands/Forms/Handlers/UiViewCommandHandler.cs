using System.Collections.Generic;
using Sources.Frameworks.UiFramework.Domain.Commands;
using Sources.Frameworks.UiFramework.InfrastructureInterfaces.Commands;

namespace Sources.Frameworks.UiFramework.Infrastructure.Commands.Forms.Handlers
{
    public class UiViewCommandHandler
    {
        private readonly Dictionary<FormCommandId, IViewCommand> _commands = 
            new Dictionary<FormCommandId, IViewCommand>();
        
        public UiViewCommandHandler(
            PauseCommand pauseCommand,
            UnPauseCommand unPauseCommand,
            SaveVolumeCommand saveVolumeCommand,
            ClearSavesCommand clearSavesCommand)
        {
            _commands[pauseCommand.Id] = pauseCommand;
            _commands[unPauseCommand.Id] = unPauseCommand;
            _commands[saveVolumeCommand.Id] = saveVolumeCommand;
            _commands[clearSavesCommand.Id] = clearSavesCommand;
        }

        public void Handle(FormCommandId formCommandId)
        {
            if(_commands.ContainsKey(formCommandId) == false)
                throw new KeyNotFoundException(nameof(formCommandId));
            
            _commands[formCommandId].Handle();
        }
    }
}