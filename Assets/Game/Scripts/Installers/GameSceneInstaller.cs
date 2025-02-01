using Game.Content.Environment;
using Game.UI;
using Game.View;
using UnityEngine;
using Zenject;

namespace Game.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private DoorView _door;
        [SerializeField] private Key[] _keys;

        public override void InstallBindings()
        {
            Container.Bind<Key[]>()
                .FromInstance(_keys)
                .AsSingle();

            Container.BindInterfacesTo<Door>()
                .AsSingle();

            Container.BindInterfacesTo<DoorPresenter>()
                .AsSingle()
                .NonLazy();

            Container.Bind<DoorView>()
                .FromInstance(_door)
                .AsSingle();
        }
    }
}