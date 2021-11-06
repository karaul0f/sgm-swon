using Assets.Client.Scripts.Services.Implementations.GameState;
using Assets.Client.Scripts.Services.Implementations.Travel;
using Assets.Client.Scripts.Services.Interfaces;
using Zenject;

namespace Assets.Client.Scripts.Installers
{
    public class GameInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ITravelService>().To<PrimitiveTravelService>().AsSingle();
            Container.Bind<IGameStateService>().To<FakeGameState>().AsSingle();
        }
    }
}