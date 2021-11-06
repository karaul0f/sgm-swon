using System;
using Assets.Client.Scripts.Services.Enums;
using Assets.Client.Scripts.Services.Interfaces;

namespace Assets.Client.Scripts.Services.Implementations.GameState
{
    public class FakeGameState : IGameStateService
    {
        public event EventHandler<EGameState> StateChanged;
        public EGameState CurrentState { get; } = EGameState.Play;
    }
}
