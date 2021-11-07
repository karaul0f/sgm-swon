using Assets.Client.Scripts.Services.Implementations.ClientGenerator;
using Assets.Client.Scripts.Services.Implementations.GameState;
using Assets.Client.Scripts.Services.Implementations.Loader;
using Assets.Client.Scripts.Services.Implementations.TourProvider;
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
            Container.Bind<ILoader<Person>>().To<ClientLoader>().AsSingle();
            Container.Bind<ILoader<Country>>().To<CountryLoader>().AsSingle();
            Container.Bind<ITourProvider>().To<SimpleTourProvider>().AsSingle();
            Container.Bind<IClientGenerator>().To<OrderedClientGenerator>().AsSingle();
        }
    }
}