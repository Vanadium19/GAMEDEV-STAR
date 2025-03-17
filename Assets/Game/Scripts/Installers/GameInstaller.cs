using Game.Core.Inventories;
using Game.Menu.Core;
using Game.Menu.UI;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace Game.Installers
{
    [CreateAssetMenu(fileName = "GameInstaller",
        menuName = "Zenject/New GameInstaller")]
    public class GameInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private WeaponCatalog _catalog;
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private Texture2D _cursorTexture;

        public override void InstallBindings()
        {
            Container.Bind<WeaponCatalog>()
                .FromInstance(_catalog)
                .AsSingle();

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

            Container.BindInterfacesTo<CursorChanger>()
                .AsSingle()
                .WithArguments(_cursorTexture);

            Container.BindInterfacesAndSelfTo<MenuFacade>()
                .AsSingle()
                .NonLazy();
        }
    }
}