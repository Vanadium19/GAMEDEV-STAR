using Game.Content.Weapons;
using UnityEngine;
using Zenject;

public class RifleInstaller : MonoInstaller
{
    [SerializeField] private WeaponParams _params;

    public override void InstallBindings()
    {
        Container.BindInterfacesTo<Rifle>()
            .AsSingle()
            .WithArguments(_params);
    }
}