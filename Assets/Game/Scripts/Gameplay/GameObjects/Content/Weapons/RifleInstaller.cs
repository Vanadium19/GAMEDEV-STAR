using Game.Content.Weapons;
using Game.Scripts.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RifleInstaller : MonoInstaller
{
    [SerializeField] private Transform _shootPoint;

    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private int _damage = 2;
    [SerializeField] private int _maxAmmoCount = 5;
    [SerializeField] private TeamType _team;

    public override void InstallBindings()
    {
        Container.BindInterfacesTo<Rifle>()
            .AsSingle()
            .WithArguments(_shootPoint,_team, _speed, _delay,_damage,_maxAmmoCount);
    }
}
