using Settings;
using Systems;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private AnimalSettings animalSettings;

        public override void InstallBindings()
        {
            BindSettings();
            BindServices();
        }

        private void BindSettings()
        {
            Container.BindInstance(animalSettings).AsSingle();
        }

        private void BindServices()
        {
            Container.Bind<ITastyLabelFactory>().To<TastyLabelFactory>().AsSingle();
            Container.Bind<IEatScoreService>().To<EatScoreService>().AsSingle();
            Container.Bind<IBoundaryController>().To<BoundaryController>().AsSingle();
            Container.Bind<IInteractionResolver>().To<InteractionResolver>().AsSingle();
            Container.Bind<IBounceService>().To<BounceService>().AsSingle();
        }
    }
}