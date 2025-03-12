using UnityEngine;
using Zenject;

namespace Game.UI
{
    public class InventoryViewInstaller : MonoInstaller
    {
        [SerializeField] private InventoryView _view;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<InventoryPresenter>()
                .AsSingle()
                .NonLazy();

            Container.Bind<InventoryView>()
                .FromInstance(_view)
                .AsSingle();
        }
    }
}