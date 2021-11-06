using Assets.Client.Scripts.Services.Implementations;
using Assets.Client.Scripts.Services.Interfaces;
using Zenject;

namespace Assets.Client.Scripts.Installers
{
    public class GameInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ITravelService>().To<PrimitiveTravelService>().AsSingle();
        }
    }
}