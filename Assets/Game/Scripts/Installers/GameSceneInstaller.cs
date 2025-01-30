using Game.Obstacles.Environment;
using Game.Presenters;
using Game.UI.Obstacles;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        private const string KeyViewName = "KeyView";
        
        [SerializeField] private DoorView _door;

        [SerializeField] private Key[] _keys;
        [SerializeField] private KeyView _keyViewPrefab;
        [SerializeField] private KeysView _keysView;

        public override void InstallBindings()
        {
            Container.Bind<Key[]>()
                .FromInstance(_keys)
                .AsSingle();

            Container.BindMemoryPool<KeyView, KeyViewPool>()
                .ExpandByOneAtATime()
                .FromComponentInNewPrefab(_keyViewPrefab)
                .WithGameObjectName(KeyViewName)
                .UnderTransform(_keysView.transform)
                .AsSingle();

            Container.BindInterfacesTo<Door>()
                .AsSingle();

            Container.BindInterfacesTo<DoorPresenter>()
                .AsSingle()
                .NonLazy();

            Container.Bind<DoorView>()
                .FromInstance(_door)
                .AsSingle();

            Container.BindInterfacesTo<KeysPresenter>()
                .AsSingle()
                .NonLazy();

            Container.Bind<KeysView>()
                .FromInstance(_keysView)
                .AsSingle();
        }
    }
}