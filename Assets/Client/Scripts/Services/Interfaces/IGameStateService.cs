using System;
using Assets.Client.Scripts.Services.Enums;

namespace Assets.Client.Scripts.Services.Interfaces
{
    public interface IGameStateService
    {
        event EventHandler<EGameState> StateChanged;

        EGameState CurrentState { get; }
    }
}
