using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Client.Scripts.Services.Enums;

namespace Assets.Client.Scripts.Services.Interfaces
{
    public interface IGameStateService
    {
        event EventHandler<EGameState> StateChanged;

        EGameState CurrentState { get; }
    }
}
