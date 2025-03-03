using Game.Content.Weapons;
using UnityEngine;
using Zenject;

public class RifleInstaller : MonoInstaller
{
    [SerializeField] private WeaponParams _params;
    [SerializeField] private int _maxAmmoCount = 5;

    public override void InstallBindings()
    {
        Container.BindInterfacesTo<Rifle>()
            .AsSingle()
            .WithArguments(_params, _maxAmmoCount);
    }
}