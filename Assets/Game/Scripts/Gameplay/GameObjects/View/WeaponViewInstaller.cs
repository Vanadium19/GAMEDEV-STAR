using Zenject;
using UnityEngine;
using Game.View;

namespace Game.View
{
    public class WeaponViewInstaller : MonoInstaller
    {
        [SerializeField] private WeaponView _weaponView;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WeaponPresenter>()
                .AsSingle()
                .NonLazy();

            Container.Bind<WeaponView>()
                .FromInstance(_weaponView)
                .AsSingle();
        }
    }
}