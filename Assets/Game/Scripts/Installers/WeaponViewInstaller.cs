using Zenject;
using UnityEngine;
using Game.View;

namespace Game.Installers
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
                .FromInstance( _weaponView )
                .AsSingle();
        }
    }
}