using Game.Menu.Core;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace Game.Installers
{
    [CreateAssetMenu(fileName = "GameInstaller",
        menuName = "Zenject/New GameInstaller")]
    public class GameInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private AudioMixer _audioMixer;

        public override void InstallBindings()
        {
            Container.Bind<AudioMixer>()
                .FromInstance(_audioMixer)
                .AsSingle();

            Container.Bind<VolumeSettings>()
                .AsSingle()
                .NonLazy();

            Container.Bind<LevelLoader>()
                .AsSingle()
                .NonLazy();

            Container.Bind<GameSettings>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesAndSelfTo<MenuFacade>()
                .AsSingle()
                .NonLazy();
        }
    }
}